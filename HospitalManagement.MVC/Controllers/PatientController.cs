using HospitalManagement.Library.Models;
using HospitalManagement.MVC.Filters;
using HospitalManagement.MVC.Services;
using Microsoft.AspNetCore.Mvc;


namespace HospitalManagement.MVC.Controllers
{
    [LoginAuthorize]
    public class PatientController : Controller
    {
        private readonly ApiService _apiservice;

        public PatientController(ApiService apiService)
        {
            _apiservice = apiService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]

        public async Task<IActionResult> Create(Patient patient)
        {
            if (!ModelState.IsValid)
            {
                return View(patient);
            }

            bool result = await _apiservice.AddPatientAsync(patient);

            if (result)
            {
                TempData["Success"] = "Patient Added Successfully";
                return RedirectToAction(nameof(TotalPatients));

            }

            ViewBag.Error = "Failed to add patient";

            return View(patient);
        }

        [HttpGet]

        [HttpGet]
        public async Task<IActionResult> TotalPatients(string? searchTerm)
        {
            var patients = await _apiservice.GetAllPatientAsync();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                patients = patients
                    .Where(p => p.FullName.Contains(
                        searchTerm,
                        StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            return View(patients);
        }


        [HttpGet]

        public async Task<IActionResult> SinglePatient(int id)
        {
            Patient? patient = await _apiservice.GetPatientByIdAsync(id);

            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        [HttpGet]

        public async Task<IActionResult> Edit(int id)
        {
            Patient? patient = await _apiservice.GetPatientByIdAsync(id);

            if(patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        [HttpPost]

        public async Task<IActionResult> Edit(Patient patient)
        {
            if (!ModelState.IsValid)
            {
                return View(patient);
            }

            bool result = await _apiservice.UpdatePatientAsync(patient);

            if(result)
            {
                TempData["Success"] = "Patient Updated Successfully";
                return RedirectToAction(nameof(TotalPatients));
            }

            ViewBag.Error = "Failed to Update patient";
            return View(patient);
        }

        [HttpPost]

        public async Task<IActionResult> Delete(int id)
        {
            bool result = await _apiservice.DeletePatientAsync(id);

            if (result)
            {
                TempData["Succcess"] = "Patient Deleted Successsfully";
            }
            else
            {
                TempData["Error"] = "Failed to delete patient";
            }

            return RedirectToAction(nameof(TotalPatients));
        }

        [HttpGet]

        public async Task<IActionResult> SearchPatients(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return Json(new List<Patient>());               
            }
            var patients = await _apiservice.SearchPatientAsync(searchTerm);

            return Json(patients);
        }

    }
}
