using System.ComponentModel.DataAnnotations;

namespace Search_Engine.Models
{
    public class UrlInfo
    {
        [Key]
        public int UrlId { get; set; }
       
        public string UrlName { get; set; }
        public double rank { get; set; }
        

       
    }
}