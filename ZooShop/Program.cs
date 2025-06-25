using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using ExceptionsLibrary.Interfaces;
using ExceptionsLibrary.Middleware;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ZooShop.Application.Extensions;
using ZooShop.Application.Interfaces;
using ZooShop.Application.Mapping;
using ZooShop.Infrastructure.Data.Configurations;
using ZooShop.Infrastructure.Repositories.Extensions;
using ZooShop.Middleware;
using ZooShop.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var jwtSecurityScheme = new OpenApiSecurityScheme
    {
        BearerFormat = "JWT",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        Description = "Введите JWT токен в формате **Bearer {token}**",

        Reference = new OpenApiReference
        {
            Id = "Bearer",
            Type = ReferenceType.SecurityScheme
        }
    };
    options.AddSecurityDefinition("Bearer", jwtSecurityScheme);

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            jwtSecurityScheme,
            []
        }
    });
});
builder.Services.AddControllers()
    .AddJsonOptions(c => c.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
builder.Services.Configure<ZooShopOptions>(builder.Configuration.GetSection(nameof(ZooShopOptions)));
builder.Services.AddSingleton<IGlobalExceptionMapper, GlobalExceptionMapper>();
builder.Services.RegisterApplication();
builder.Services.RegisterRepositories(builder.Configuration);
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<IdentityDbContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(nameof(JwtOptions)));

var jwtOptions = builder.Configuration.GetSection(nameof(JwtOptions)).Get<JwtOptions>() ??
                 throw new ArgumentNullException(nameof(JwtOptions));

builder.Services.AddAuthentication(c =>
{
    c.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    c.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(c =>
{
    c.RequireHttpsMetadata = true;
    c.SaveToken = true;
    c.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtOptions.Issuer,
        ValidAudience = jwtOptions.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Secret)),
        ClockSkew = TimeSpan.Zero
    };
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ImageMiddleware>();

app.UseMiddleware<GlobalExceptionMiddleware>();

app.MapControllers();

app.UseHttpsRedirection();

app.Lifetime.ApplicationStarted.Register(async () =>
{
    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<ZooShopContext>();
        var identityContext = scope.ServiceProvider.GetRequiredService<IdentityDbContext>();
        var hashService = scope.ServiceProvider.GetRequiredService<IHashService>();
        var productRepository = scope.ServiceProvider.GetRequiredService<IConsultantRepository>();

        await context.Database.MigrateAsync();
        await identityContext.Database.MigrateAsync();
        await identityContext.SeedIdentityDataAsync(scope.ServiceProvider, productRepository, hashService);
    }
});

app.Run();