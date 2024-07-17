using System.Text;
using ApplicationCore.Constants;
using ApplicationCore.Entities.ApplicationUser;
using ApplicationCore.Entities.Product;
using ApplicationCore.RepositoryContracts;
using ApplicationCore.ServiceContracts;
using ECommerce.Api.Products.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using Prometheus;

var builder = WebApplication.CreateBuilder(args);

static IEdmModel GetEdmModel()
{
    var builder = new ODataConventionModelBuilder();
    builder.EntitySet<Product>("Products");
    return builder.GetEdmModel();
}

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDbContext<ECommerenceDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ECommerceDB"));
});
builder.Services.AddIdentity<ApplicationUser,IdentityRole>()
    .AddEntityFrameworkStores<ECommerenceDbContext>().AddDefaultTokenProviders();
builder.Services.AddControllers().AddOData((options =>
{
    options.Select()
        .Filter()
        .Expand()
        .OrderBy()
        .Count()
        .SetMaxTop(10)
        .AddRouteComponents("odata", GetEdmModel());
}));
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policyBuilder =>
    {
        policyBuilder.AllowAnyHeader();
        policyBuilder.AllowAnyMethod();
        policyBuilder.AllowAnyOrigin();
    });
});
builder.Services.AddScoped<IProductServiceAsync,ProductServiceAsync >();
builder.Services.AddScoped<IProductRepositoryAsync,ProductRepositoryAsync>();
builder.Services.AddAutoMapper(typeof(Program));
// Inside ConfigureServices method
var key = Encoding.ASCII.GetBytes(Constants.JSON_SECRET_KEY); // Use the same secret key for signing the token
builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
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
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(options =>
{
    options.MapControllers();
    options.MapMetrics();
});
app.Run();