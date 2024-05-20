

using Microsoft.EntityFrameworkCore;

namespace PatoShopping.API.Model.Context
{
    public class DbContextApp : DbContext
    {
        public DbContextApp(DbContextOptions<DbContextApp> options) : base(options)
        {
            
        }
        public DbSet<Product> Products { get; set; }
    }
}
