using System.ComponentModel.DataAnnotations;

namespace Search_Engine.Dtos
{
    public class SearchResultDto
    {
        public string UrlName { get; set; }
        public double Pagerank { get; set; }

        public string FirstWord { get; set; }
        public int FirstWordCount { get; set; }

        public string SecondWord { get; set; }
        public int SecondWordCount { get; set; }
    }
}