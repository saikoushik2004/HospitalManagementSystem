using Microsoft.AspNetCore.Mvc;
using HospitalManagement.Library.Interfaces.Services;



namespace HospitalManagement.API.Controllers
{

    [Route("api/[controller]")]
    public class SearchController : Controller
    {
        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        [HttpGet]

        public async Task<IActionResult> Search(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return Ok(new List<object>());
            }

            var results = await _searchService.SearchAsync(searchTerm);

            return Ok(results);
        }
    }
}
