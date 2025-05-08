namespace Search_Engine.Models
{
    public class InvertedIndex
    {
        public string Word { get; set; }
        public int UrlId { get; set; }
        public virtual UrlInfo UrlInfo { get; set; }
        public int Count { get; set; }
        public int FirstPosition { get; set; }
        
        
    }
}