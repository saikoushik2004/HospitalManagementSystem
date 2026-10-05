using HospitalManagement.Library.Models;
using HospitalManagement.MVC.Filters;
using HospitalManagement.MVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.MVC.Controllers
{
    [LoginAuthorize]
    public class AppointmentController : Controller
    {
        private readonly ApiService _apiService;


        public AppointmentController(ApiService apiService)
        {
            _apiService = apiService;
        }

        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(Appointment appointment)
        {
            if (!ModelState.IsValid)
            {
                return View(appointment);
            }

            bool result = await _apiService.AddAppointmentAsync(appointment);

            if (result)
            {
                TempData["Success"] = "Appointment Deatils Added Successfully";
                return RedirectToAction(nameof(TotalAppointments));
            }
            ViewBag.Error = "Failed to add appointment details";

            return View(appointment);
        }

        [HttpGet]

        public async Task<IActionResult> TotalAppointments(string? searchTerm)
        {
            var appointments = await _apiService.GetAllAppointmentsAsync();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                appointments = appointments.Where(a => a.AppointmentNumber.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return View(appointments);
        }

        [HttpGet]

        public async Task<IActionResult> SingleAppointment(int id)
        {
            Appointment? appointment = await _apiService.GetAppointmentByIdAsync(id);

            if(appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }


        [HttpGet]

        public async Task<IActionResult> Edit(int id)
        {
            Appointment? appointment = await _apiService.GetAppointmentByIdAsync(id);

            if(appointment == null)
            {
                return NotFound();

            }
            return View(appointment);
        }

        [HttpPost]
        
        public async Task<IActionResult> Edit(Appointment appointment)
        {
            if (!ModelState.IsValid)
            {
                return View(appointment);
            }

            bool result = await _apiService.UpdateAppointmentAsync(appointment);

            if (result)
            {
                TempData["Success"] = "Appointment Updated Succcessfully";
                return RedirectToAction(nameof(TotalAppointments));
            }

            ViewBag.Error = "Failed to Update Appointment";
            return View(appointment);
        }


        [HttpPost]

        public async Task<IActionResult> Delete(int id)
        {
            bool result = await _apiService.DeleteAppointmentAsync(id);

            if (result)
            {
                TempData["Success"] = "Appointment deleted Successfully";
            }
            else
            {
                TempData["Error"] = "Failed to Delete Appointment";
            }

            return RedirectToAction(nameof(TotalAppointments));
        }
    }
}



