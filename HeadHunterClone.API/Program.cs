using HeadHunterClone.API.Repositories;
using HeadHunterClone.Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Local_HHCloneDB;Trusted_Connection=True;MultipleActiveResultSets=true");
        });

        // TODO: Дополнить Identity
        builder.Services.AddDefaultIdentity<>();

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // Аутентификация
        // ==============
        // JWT-token
        // Cookie

        builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
        // Авторизация
        builder.Services.AddAuthorization();

        // Регистрация сервиса
        builder.Services.AddScoped<VacancyRepository>();

        // Scoped 
        // Transiet


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseStaticFiles();

        app.MapControllers();

        app.Run();
    }
}