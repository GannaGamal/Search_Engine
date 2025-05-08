using Microsoft.AspNetCore.Mvc;
using Search_Engine.Interfaces;

namespace Search_Engine.Controllers
{
    public class SearchController : Controller
    {
        private readonly ISearchRepository _searchRepository;
        public SearchController(ISearchRepository searchRepository)
        {
            _searchRepository = searchRepository;
        }

        [HttpGet]
        public async Task<IActionResult> SearchInvertedIndex(string word, string orderby)
        {
            var result = await _searchRepository.SearchInvertedIndex(word, orderby);
            return View(result);
        }
    }
}
