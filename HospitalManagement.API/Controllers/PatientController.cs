using Microsoft.AspNetCore.Mvc;
using HospitalManagement.Library.Interfaces.Services;
using HospitalManagement.Library.Models;

namespace HospitalManagement.API.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : Controller
    {

        private readonly IPatientService _patientservice;

        public PatientController(IPatientService patientservice)
        {
            _patientservice = patientservice;
        }


        [HttpPost]

        public async Task<IActionResult> AddPatient([FromBody] Patient patient)
        {
            int result = await _patientservice.AddPatientAsync(patient);

            if (result > 0)
            {
                return Ok("Patient Added Successfully");
            }

            return BadRequest("Failed to add patient");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPatients()
        {
            var patient = await _patientservice.GetAllPatientsAsync();

            return Ok(patient);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatientById(int id)
        {
            Patient? patient = await _patientservice.GetPatientByIdAsync(id);

            if(patient == null)
            {
                return NotFound("Patient Not Found");
            }

            return Ok(patient);
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchPatients(string searchTerm)
        {
            var patients = await _patientservice.SearchPatientAsync(searchTerm);

            return Ok(patients);
        }

        [HttpPut]

        public async Task<IActionResult> UpdatePatient(Patient patient)
        {
            int result = await _patientservice.UpdatePatientAsync(patient);

            if(result > 0)
            {
                return Ok("Patient Updated Successfully");
            }

            return BadRequest("Failed to Update Patient");
        }
    
        [HttpDelete("{id}")]

        public async Task<IActionResult> DeletePatient(int id )
        {
            int result = await _patientservice.DeletePatientAsync(id);

            if(result > 0)
            {
                return Ok("Patient Deleted Successfully");
            }

            return BadRequest("Failed to delete Patient");

        }




    }
}