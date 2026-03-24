using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PortfolioManager.Data;
namespace PortfolioManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<PortfolioManagerContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("PortfolioManagerContext") ?? throw new InvalidOperationException("Connection string 'PortfolioManagerContext' not found.")));

            // Add services to the container.
            builder.Services.AddControllersWithViews();

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
                pattern: "{controller=Investments}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
