using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Travel.API.Data;
using Travel.API.Middleware;
using Travel.API.Repositories;

namespace Travel.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<TravelAPIContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("TravelAPIContext") ?? throw new InvalidOperationException("Connection string 'TravelAPIContext' not found.")));

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddScoped<IDestinationRepository, DestinationRepository>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseMiddleware<ExceptionMiddleware>();



            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
