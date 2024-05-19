using Microsoft.EntityFrameworkCore;
using PatoShopping.API.Model.Base;

namespace PatoShopping.API.Model.Context
{
    public class DbContextApp : DbContext
    {
        public DbContextApp(DbContextOptions<DbContextApp> options) : base(options)
        {
            
        }
        public DbContextApp()
        {
            
        }
    }
}
