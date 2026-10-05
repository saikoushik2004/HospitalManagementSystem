using HospitalManagement.Library.Interfaces.Services;
using HospitalManagement.Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpPost]
        public async Task<IActionResult> AddAppointment([FromBody] Appointment appointment)
        {
            int result = await _appointmentService.AddAppointmentAsync(appointment);

            if(result > 0)
            {
                return Ok("Appointment Added Successfully");
            }

            return BadRequest("Appointment Failed ");

        }

        [HttpGet]

        public async Task<IActionResult> GetAllAppointments()
        {
            var appointment = await _appointmentService.GetAllAppointmentsAsync();

            return Ok(appointment);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllAppointmentsById(int id)
        {
            var appointment = await _appointmentService.GetAppointmentByIdAsync(id);

            return Ok(appointment);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAppointment(Appointment appointment)
        {
            int result = await _appointmentService.UpdateAppointmentAsync(appointment);

            if(result > 0)
            {
                return Ok("Appointment Updated Successfully");
            }

            return BadRequest("Failed to Update Appointment");
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            int result = await _appointmentService.DeleteAppointmentAsync(id);

            if(result > 0)
            {
                return Ok("Appointment deleted successfully");
            }

            return BadRequest("Failed to delete Appointment");
        }

    }
}






