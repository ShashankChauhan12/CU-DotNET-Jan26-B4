using CarManagementApp.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CarManagementApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            //builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
            //    .AddEntityFrameworkStores<ApplicationDbContext>();
            //builder.Services.AddControllersWithViews();

            builder.Services.AddDefaultIdentity<IdentityUser>(
                    options => options.SignIn.RequireConfirmedAccount = false)
                 .AddRoles<IdentityRole>()
                 .AddEntityFrameworkStores<ApplicationDbContext>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
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
                pattern: "{controller=Cars}/{action=Index}/{id?}");
            app.MapRazorPages();

            using (var scope = app.Services.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

                // 1. Create the Role if it doesn't exist
                if (!await roleManager.RoleExistsAsync("Admin"))
                {
                    await roleManager.CreateAsync(new IdentityRole("Admin"));
                }
                

                // 2. Assign the Role to a specific user by Email
                var user = await userManager.FindByEmailAsync("admin1@test.com");
                if (user != null && !await userManager.IsInRoleAsync(user, "Admin"))
                {
                    await userManager.AddToRoleAsync(user, "Admin");
                }


                if (!await roleManager.RoleExistsAsync("Customer"))
                {
                    await roleManager.CreateAsync(new IdentityRole("Customer"));
                }
 
                var user1 = await userManager.FindByEmailAsync("customer1@test.com");
                if (user1 != null && !await userManager.IsInRoleAsync(user1, "Customer"))
                {
                    await userManager.AddToRoleAsync(user1, "Customer");
                }


                if (!await roleManager.RoleExistsAsync("User"))
                {
                    await roleManager.CreateAsync(new IdentityRole("User"));
                }
                var user2 = await userManager.FindByEmailAsync("user1@test.com");
                if (user2 != null && !await userManager.IsInRoleAsync(user2, "User"))
                {
                    await userManager.AddToRoleAsync(user2, "User");
                }
            }

            app.Run();
        }
    }
}
