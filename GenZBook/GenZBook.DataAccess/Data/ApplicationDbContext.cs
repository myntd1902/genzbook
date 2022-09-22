using GenZBook.Models;
using Microsoft.EntityFrameworkCore;

namespace GenZBook.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
                
        }

        public DbSet<Category> Categories  { get; set; }
    }
}
