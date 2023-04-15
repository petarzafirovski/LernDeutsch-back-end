using LernDeutsch_Backend.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LernDeutsch_Backend.Data
{
    public class ApplicationDatabaseContext : IdentityDbContext<BaseUser>
    {
        public DbSet<Student> students { get; set; }
        public DbSet<Tutor> tutors { get; set; }

        public ApplicationDatabaseContext(DbContextOptions<ApplicationDatabaseContext> options) 
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);       
        }
    }
}
