using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LoanManagWebAPI.Model;

namespace LoanManagWebAPI.Data
{
    public class LoanManagWebAPIContext : DbContext
    {
        public LoanManagWebAPIContext (DbContextOptions<LoanManagWebAPIContext> options)
            : base(options)
        {
        }

        public DbSet<LoanManagWebAPI.Model.Loan> Loan { get; set; } = default!;
    }
}
