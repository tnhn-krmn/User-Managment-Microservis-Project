using Database.Microservice.Entities;
using Microsoft.EntityFrameworkCore;

namespace Database.Microservice.Repository.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-A5RCAJ3;Database=Microservice;Trusted_Connection=True; TrustServerCertificate=True;");
        }

        public DbSet<User> Users { get; set; }
    }
}
