using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using Scalar.AspNetCore;
using System.Text;
using wsApp.Application.Interfaces;
using wsApp.Application.UseCases;
using wsApp.Infrastructure.Persistence;
using wsApp.Infrastructure.Repositories;
using wsApp.Infrastructure.Security;


var builder = WebApplication.CreateBuilder(args);

 

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();



builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddScoped<IHashService, HashService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<RegisterUserUseCase>();
builder.Services.AddScoped<LoginUserUseCase>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])
            )
        };
    });

builder.Services.AddOpenApi(options =>
{
    options.AddDocumentTransformer((document, context, ct) =>
    {
        document.Components ??= new();
        document.Components.SecuritySchemes ??= new Dictionary<string, IOpenApiSecurityScheme>();
        document.Components.SecuritySchemes.Add("Bearer", new OpenApiSecurityScheme
        {
            Type = SecuritySchemeType.Http,
            Scheme = "bearer",
            BearerFormat = "JWT"
        });
        return Task.CompletedTask;
    });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy => policy
            .WithOrigins(
                "http://localhost:4200",
                "https://gray-wave-0ea61b210.2.azurestaticapps.net"
            )
            .AllowAnyHeader()
            .AllowAnyMethod());
});

var app = builder.Build();

//PRUEBA VALIDAR CONEXION
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    try
    {
        db.Database.OpenConnection();
        Console.WriteLine("Conexión exitosa");
        db.Database.CloseConnection();
    }
    catch (Exception ex)
    {
        Console.WriteLine("Error conexión: " + ex.Message);
    }
}

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options.WithPreferredScheme("Bearer")
               .WithHttpBearerAuthentication(bearer => bearer.Token = "");
    });
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseCors("AllowAngular");
 

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
