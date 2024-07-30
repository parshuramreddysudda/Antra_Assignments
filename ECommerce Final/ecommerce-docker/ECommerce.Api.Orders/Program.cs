using System.Text;
using ApplicationCore.Constants;
using ApplicationCore.Entities.ApplicationUser;
using ApplicationCore.Helpers;
using ApplicationCore.Repository;
using ApplicationCore.RepositoryContracts;
using ApplicationCore.ServiceContracts;
using ECommerce.Api.Orders.Interfaces;
using ECommerce.Api.Orders.Services;
using Hangfire;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers().AddNewtonsoftJson((options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

}));
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
    });
builder.Services.AddDbContext<ECommerenceDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ECommerceDB"));
});
builder.Services.AddScoped<IOrderRepositoryAsync,OrderRepository >();
builder.Services.AddScoped<IOrderServiceAsync,OrderServiceAsync>();
builder.Services.AddScoped<IRabbitMQProducer>(_=>new RabbitMqProducer( Constants.ORDER_QUEUE_HOST_NAME,Constants.ORDER_QUEUE_USER_NAME,Constants.ORDER_QUEUE_PASSWORD,Constants.ORDER_QUEUE_NAME));
builder.Services.AddIdentity<ApplicationUser,IdentityRole>()
    .AddEntityFrameworkStores<ECommerenceDbContext>().AddDefaultTokenProviders();
builder.Services.AddHealthChecks();
builder.Services.AddMvc();
builder.Services.AddCors((options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
    });
}));
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddHangfire((configuration =>
{
    configuration.UseSqlServerStorage(builder.Configuration.GetConnectionString("HangfireDB"));
}));

var key = Encoding.ASCII.GetBytes(Constants.JSON_SECRET_KEY);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = Constants.ISSUER,
        ValidAudience = Constants.AUDIENCE,
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

var app = builder.Build();
app.UseHangfireServer();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHangfireDashboard("/hangfire");
app.UseHttpsRedirection();
app.UseRouting();
app.UseCors();
app.UseEndpoints(options =>
{
    options.MapControllers();
    options.MapHealthChecks("/health");
    options.MapHangfireDashboard();
});
app.Run();;