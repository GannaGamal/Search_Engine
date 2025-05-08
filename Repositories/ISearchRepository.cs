using System.Collections.Generic;

using Search_Engine.Dtos;

namespace Search_Engine.Interfaces
{
    public interface ISearchRepository
    {
        Task<List<SearchResultDto>> SearchInvertedIndex(string word, string orderby);
    }
}