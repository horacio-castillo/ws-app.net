using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using wsApp.Application.Interfaces;
using wsApp.Application.UseCases;
using wsApp.Infrastructure.Persistence;
using wsApp.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<RegisterUserUseCase>();

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
    app.MapScalarApiReference();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
