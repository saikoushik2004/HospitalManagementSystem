using Microsoft.AspNetCore.Mvc;
using HospitalManagement.MVC.Filters;
using HospitalManagement.MVC.Services;
using HospitalManagement.Library.Repositories;
using HospitalManagement.Library.Models;

namespace HospitalManagement.MVC.Controllers
{
    [LoginAuthorize]
    public class SearchController : Controller
    {
        private readonly ApiService _apiService;

        public SearchController(ApiService apiService) 
        {
            _apiService = apiService;
        }

        [HttpGet]
        public async Task<IActionResult> Search(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return Json(new List<object>());
            }

            var results = await _apiService.SearchAsync(searchTerm);

            return Json(results);
        }
    }
}
