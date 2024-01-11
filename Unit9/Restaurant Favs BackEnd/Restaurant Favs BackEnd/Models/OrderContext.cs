using Microsoft.EntityFrameworkCore;
namespace Restaurant_Favs_BackEnd.Models
{
    public class OrderContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=RestaurantFavesDB;Integrated Security=SSPI;");
        }
    }
}
