using Microsoft.EntityFrameworkCore;

namespace CookieStore.Api.Data
{
    public class CookieStoreContext : DbContext 
    {
        public CookieStoreContext(DbContextOptions<CookieStoreContext> options)
            : base(options) 
        {
            
        }

        public DbSet<Cookies> Cookies { get; set; }

      
    }
}
