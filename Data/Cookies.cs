using System.Data.Common;

namespace CookieStore.Api.Data
{
    public class Cookies
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        
        public string description { get; set; } 
    }
}
