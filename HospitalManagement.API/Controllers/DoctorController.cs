using Microsoft.AspNetCore.Mvc;
using HospitalManagement.Library.Interfaces.Services;
using HospitalManagement.Library.Models;

namespace HospitalManagement.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpPost]

        public async Task<IActionResult> AddDoctor([FromBody] Doctor doctor)
        {
            int result = await _doctorService.AddDoctorAsync(doctor);

            if (result > 0)
            {
                return Ok("Doctor Added Successfully");
            }

            return BadRequest("Failed to add Doctor");
        }



        [HttpGet]
        public async Task<IActionResult> GetAllDoctors()
        {
            var doctor = await _doctorService.GetAllDoctorsAsync();

            return Ok(doctor);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoctorById(int id)
        {
            Doctor? doctor = await _doctorService.GetDoctorByIdAsync(id);

            if (doctor == null)
            {
                return NotFound("Patient Not Found");
            }

            return Ok(doctor);
        }

        [HttpPut]

        public async Task<IActionResult> UpdateDoctor(Doctor doctor)
        {
            int result = await _doctorService.UpdateDoctorAsync(doctor);

            if (result > 0)
            {
                return Ok("Doctor Updated Successfully");
            }

            return BadRequest("Failed to update doctor");
        }


        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteDoctor(int id)
        {
            int result = await _doctorService.DeleteDoctorAsync(id);

            if (result > 0)
            {
                return Ok("Doctor Deleted Successfully");
            }

            return BadRequest("Failed to Delete Record");
        }


        [HttpGet("search")]

        public async Task<IActionResult> SearchDoctor(string searchTerm)
        {
            var doctor = await _doctorService.SearchDoctorAsync(searchTerm);

            return Ok(doctor);
        }

    }
}