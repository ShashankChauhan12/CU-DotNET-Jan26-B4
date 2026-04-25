
using FluentValidation;
using FluentValidation.AspNetCore;
using LoanAPIUpdate.Data;
using LoanAPIUpdate.Mappings;
using LoanAPIUpdate.Middleware;
using LoanAPIUpdate.Repositories;
using LoanAPIUpdate.Services;
using LoanAPIUpdate.Validators;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace LoanAPIUpdate
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            builder.Host.UseSerilog();

            builder.Services.AddControllers();

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite(
                        builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<ILoanRepository, LoanRepository>();
            builder.Services.AddScoped<ILoanService, LoanService>();

            builder.Services.AddAutoMapper(typeof(LoanProfile));

            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddValidatorsFromAssemblyContaining<CreateLoanValidator>();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
