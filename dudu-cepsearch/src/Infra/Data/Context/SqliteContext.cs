using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data.Context
{
    public class SqliteContext : DbContext
    {
        public virtual DbSet<CepModel> Users { get; set; }

        private readonly IConfiguration _configuration;

        public SqliteContext(DbContextOptions options, IConfiguration configuration) : base(options)
            => _configuration = configuration;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SqliteContext).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
                optionsBuilder
                    .EnableSensitiveDataLogging()
                    .UseSqlite(_configuration.GetSection("ConnectionStrings").GetSection("CEPSearchConnection").Value);
        }
    }
}
