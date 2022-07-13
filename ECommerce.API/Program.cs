using ECommerce.API.Authorization;
using ECommerce.API.Data;
using ECommerce.API.Data.Repositories;
using ECommerce.API.Helpers;
using ECommerce.API.Interfaces;
using ECommerce.API.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ECommerceDbContext>(options => options.UseSqlServer("Data Source=DESKTOP-FNO20ES\\SQLEXPRESS;Initial Catalog=ECommerceDb;Integrated Security=True"));
builder.Services.AddScoped<IImageRepository, ImageRepository>();
builder.Services.AddScoped<IVegetableRepository, VegetableRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRatingRepository, RatingRepository>();

// Add AutoMapper
{
    var services = builder.Services;
    var env = builder.Environment;

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();

    services.AddDbContext<ECommerceDbContext>(options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

    services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    services.AddCors();
    services.AddControllers().AddJsonOptions(x =>
    {
        // Serialize enums as strings in api responses (e.g. Role)
        x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

    // Configure strongly typed settings object
    services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

    // Configure DI for application services
    services.AddScoped<IJwtUtils, JwtUtils>();
    services.AddScoped<IAuthenticateService, UserService>();
}

var app = builder.Build();

// Configure HTTP request pipeline
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    // Global cors policy
    app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()); // allow credentials

    // Global error handler
    app.UseMiddleware<ErrorHandlerMiddleware>();

    // Custom jwt auth middleware
    app.UseMiddleware<JwtMiddleware>();

    app.MapControllers();
}

app.Run();
