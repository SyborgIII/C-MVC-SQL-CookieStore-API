using System.ComponentModel.DataAnnotations;
namespace CookieStore.Api.Models

{
    public class CookieModel
    {
        public int Id { get; set; }
        
        [Required]  
        public string Name { get; set; }
       
        [Required]
        public string description { get; set; }
    }
}
