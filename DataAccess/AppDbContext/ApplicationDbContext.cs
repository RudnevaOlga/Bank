using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.AppDbContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
        {
            
        }

        public DbSet<Card> card {  get; set; }

        public DbSet<Operation> operation { get; set; }

        public DbSet<DescriptionOfOperation> descriptionOfOperation { get; set; }
    }
}
