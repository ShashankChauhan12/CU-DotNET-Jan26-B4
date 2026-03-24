using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PortfolioManager.Models;

namespace PortfolioManager.Data
{
    public class PortfolioManagerContext : DbContext
    {
        public PortfolioManagerContext (DbContextOptions<PortfolioManagerContext> options)
            : base(options)
        {
        }

        public DbSet<PortfolioManager.Models.Investment> Investment { get; set; } = default!;
    }
}
