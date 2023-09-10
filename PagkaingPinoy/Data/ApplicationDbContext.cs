using Microsoft.EntityFrameworkCore;
using PagkaingPinoy.Models;

namespace PagkaingPinoy.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {
            
        }

        public DbSet<Menu> Menus { get; set; } 

        public DbSet<Cart> Carts { get; set; }

        public DbSet<OrderHistory> OrderHistories { get; set; }
    }
}
