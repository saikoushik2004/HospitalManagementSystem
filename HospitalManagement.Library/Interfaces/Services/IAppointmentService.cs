using HospitalManagement.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagement.Library.Interfaces.Services
{
    public interface IAppointmentService
    {
        Task<int> AddAppointmentAsync(Appointment appointment);

        Task<IEnumerable<Appointment>> GetAllAppointmentsAsync();

        Task<Appointment?> GetAppointmentByIdAsync(int id);

        Task<int> UpdateAppointmentAsync(Appointment appointment);

        Task<int> DeleteAppointmentAsync(int id);

    }
}
