using System.Text;
using ApplicationCore.Constants;
using ApplicationCore.Entities.ApplicationUser;
using ApplicationCore.Helpers;
using ApplicationCore.Repository;
using ApplicationCore.RepositoryContracts;
using ApplicationCore.ServiceContracts;
using ECommerce.Api.Orders.Interfaces;
using ECommerce.Api.Orders.Services;
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
builder.Services.AddScoped<IRabbitMQProducer>(_=>new RabbitMqProducer( "localhost","guest","guest","orderservice"));
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
        ValidIssuer = Constants.Issuer,
        ValidAudience = Constants.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseRouting();
app.UseCors();
app.UseEndpoints(options =>
{
    options.MapControllers();
    options.MapHealthChecks("/health");
});
app.Run();;