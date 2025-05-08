using System.Collections.Generic;
using System.Linq;
using Search_Engine.Data;
using Search_Engine.Interfaces;
using Search_Engine.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Search_Engine.Repositories
{
    public class SearchRepository : ISearchRepository
    {
        private readonly AppDbContext _context;
        public SearchRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<SearchResultDto>> SearchInvertedIndex(string word, string orderby)
        {
            if (string.IsNullOrWhiteSpace(word))
                return new List<SearchResultDto>();

            var words = word
                .Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                .Select(w => w.ToLower())
                .ToList();


            if (words.Count == 0) return new List<SearchResultDto>();

            if (words.Count == 1)
            {
                var keyword = words[0];

                var result = _context.InvertedIndexes
                    .Include(ii => ii.UrlInfo)
                    .Where(ii => ii.Word == keyword)
                    .Select(ii => new SearchResultDto
                    {
                        UrlName = ii.UrlInfo.UrlName,
                        Pagerank = ii.UrlInfo.rank,
                        FirstWord = keyword,
                        FirstWordCount = ii.Count,
                        SecondWord = null,
                        SecondWordCount = 0
                    });

                return (orderby == "count")
                    ? result.OrderByDescending(r => r.FirstWordCount).ToList()
                    : result.OrderByDescending(r => r.Pagerank).ToList();
            }

            if (words.Count == 2)
            {
                var word1 = words[0];
                var word2 = words[1];

                var results1 =  _context.InvertedIndexes.Include(ii => ii.UrlInfo)
                                .Where(ii => ii.Word == word1).ToList();

                var results2 = _context.InvertedIndexes.Include(ii => ii.UrlInfo)
                                .Where(ii => ii.Word == word2).ToList();

                var allUrls = results1.Select(r => r.UrlInfo.UrlName)
                    .Union(results2.Select(r => r.UrlInfo.UrlName))
                    .Distinct();

                var combinedResults = allUrls.Select(url =>
                {
                    var r1 = results1.FirstOrDefault(r => r.UrlInfo.UrlName == url);
                    var r2 = results2.FirstOrDefault(r => r.UrlInfo.UrlName == url);
                    return new SearchResultDto
                    {
                        UrlName = url,
                        Pagerank = (r1?.UrlInfo.rank ?? r2?.UrlInfo.rank ?? 0),
                        FirstWord = word1,
                        FirstWordCount = r1?.Count ?? 0,
                        SecondWord = word2,
                        SecondWordCount = r2?.Count ?? 0
                    };
                });

                return (orderby == "count")
                    ? combinedResults.OrderByDescending(r => r.FirstWordCount + r.SecondWordCount).ToList()
                    : combinedResults.OrderByDescending(r => r.Pagerank).ToList();
            }

            return new List<SearchResultDto>();
        }
    }
}