using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Database
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<vModel> vModels { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<vModel>()
                .Property(x => x.Gender)
                .HasConversion(new EnumToStringConverter<Gender>());

            modelBuilder.Entity<vModel>()
                .Property(x => x.status)
                .HasConversion(new EnumToStringConverter<Status>());

            base.OnModelCreating(modelBuilder);
        }
    }
}
