using Microsoft.EntityFrameworkCore;
using MPSPDotNetTraining.EFCoreExample.Models;
using System.Collections.Generic;

namespace MPSPDotNetTraining.EFCoreExample.DataAccess
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=.;Database=MPSPDotNetTraining;User Id=sa;Password=sasa@123;TrustServerCertificate=True;"
            );
        }

        public DbSet<TblEmployee> TblEmployees { get; set; }
    }
}