using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using KinoCatalog.Models;

namespace KinoCatalog.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<KinoCatalog.Models.Actor> Actor { get; set; } = default!;
        public DbSet<KinoCatalog.Models.Country> Country { get; set; } = default!;
        public DbSet<KinoCatalog.Models.Film> Film { get; set; } = default!;
        public DbSet<KinoCatalog.Models.Genre> Genre { get; set; } = default!;
        public DbSet<KinoCatalog.Models.ProductionStudio> ProductionStudio { get; set; } = default!;
    }
}
