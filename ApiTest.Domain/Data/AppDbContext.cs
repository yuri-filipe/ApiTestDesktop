using ApiTest.Domain.Data.Models;
using Microsoft.EntityFrameworkCore;
using Parameter = ApiTest.Domain.Data.Models.Parameter;

namespace ApiTest.Domain.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Configuration> Configuration { get; set; }
        public DbSet<Parameter> Parameter { get; set; }
        public DbSet<Header> Header { get; set; }
        public DbSet<Test> Test { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Configuration>()
            .HasMany(c => c.Parameters)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Configuration>()
                .HasMany(c => c.Headers)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Test>()
                .HasOne(t => t.Configuration)
                .WithMany()
                .HasForeignKey(t => t.ConfigurationId);
        }
    }

}
