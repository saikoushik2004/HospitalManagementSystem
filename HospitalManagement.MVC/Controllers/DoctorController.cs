using HospitalManagement.Library.Models;
using HospitalManagement.MVC.Filters;
using HospitalManagement.MVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.MVC.Controllers
{
    [LoginAuthorize]
    public class DoctorController : Controller
    {
        private readonly ApiService _apiService;

        public DoctorController(ApiService apiService)
        {
            _apiService = apiService;
        }

        [HttpGet]
        public IActionResult Create()
        {   
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(Doctor doctor)
        {
            if (!ModelState.IsValid)
            {
                return View(doctor);
            }

            bool result = await _apiService.AddDoctorAsync(doctor);

            if (result)
            {
                TempData["Success"] = "Doctor Added Successfully";
                return RedirectToAction(nameof(TotalDoctors));
            }

            ViewBag.Error = "Failed to add Doctor";

            return View(doctor);
        }

        [HttpGet]

        public async Task<IActionResult> TotalDoctors(string? searchTerm)
        {
            var doctors = await _apiService.GetAllDoctorAsync();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                doctors = doctors.Where(d => d.FullName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return View(doctors);
        }

        [HttpGet]

        public async Task<IActionResult> SingleDoctor(int id)
        {
            Doctor? doctor = await _apiService.GetDoctorByIdAsync(id);

            if(doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        [HttpGet]

        public async Task<IActionResult> Edit(int id)
        {
            Doctor? doctor = await _apiService.GetDoctorByIdAsync(id);

            if(doctor == null)
            {
                return NotFound();
            }

            return View(doctor);

        }

        [HttpPost]

        public async Task<IActionResult> Edit(Doctor doctor)
        {
            if (!ModelState.IsValid)
            {
                return View(doctor);
            }

            bool result = await _apiService.UpdateDoctorAsync(doctor);

            if (result)
            {
                TempData["Success"] = "Doctor updated Successfully";
                return RedirectToAction(nameof(TotalDoctors));
            }

            ViewBag.Error = "Failed to update doctor";
            return View(doctor);
        }

        [HttpPost]

        public async Task<IActionResult> Delete(int id)
        {
            bool result = await _apiService.DeleteDoctorAsync(id);

            if (result)
            {
                TempData["Success"] = "Doctor deleted Successfully";
            }
            else
            {
                TempData["Error"] = "Failed to Delete doctor";
            }

            return RedirectToAction(nameof(TotalDoctors));
        }

        [HttpGet]


        public async Task<IActionResult> SearchDoctor(string searchTeam)
        {
            if (string.IsNullOrWhiteSpace(searchTeam))
            {
                return Json(new List<Doctor>());
            }

            var doctor = await _apiService.SearchDoctorAsync(searchTeam);

            return Json(doctor);
        }
            
    }
}
