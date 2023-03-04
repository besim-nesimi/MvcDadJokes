using Microsoft.EntityFrameworkCore;
using MvcDadJokes.Api;
using MvcDadJokes.Data;
using MvcDadJokes.Services;

namespace MvcDadJokes
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //ApiInitializer.httpClient.BaseAddress = new Uri("https://icanhazdadjoke.com/api/");
            ApiInitializer.httpClient.DefaultRequestHeaders.Clear();
            ApiInitializer.httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var connectionString = builder.Configuration.GetConnectionString("JokeDbConnection");
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

            // Dependency injection
            builder.Services.AddScoped<IJokeRepo, JokeRepoDeluxe>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}