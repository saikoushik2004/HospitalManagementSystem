using HospitalManagement.Library.Interfaces.Repositories;
using HospitalManagement.Library.Interfaces.Services;
using HospitalManagement.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagement.Library.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task<int> AddAppointmentAsync(Appointment appointment)
        {
            return await _appointmentRepository.AddAppointmentAsync(appointment);
        }

        public async Task<IEnumerable<Appointment>> GetAllAppointmentsAsync()
        {
            return await _appointmentRepository.GetAllAppointmentsAsync();
        }

        public async Task<Appointment?> GetAppointmentByIdAsync(int id)
        {
            return await _appointmentRepository.GetAppointmentByIdAsync(id);
        }

        public async Task<int> UpdateAppointmentAsync(Appointment appointment)
        {
            return await _appointmentRepository.UpdateAppointmentAsync(appointment);
        }

        public async Task<int> DeleteAppointmentAsync(int id)
        {
            return await _appointmentRepository.DeleteAppointmentAsync(id);
        }
    }
}
