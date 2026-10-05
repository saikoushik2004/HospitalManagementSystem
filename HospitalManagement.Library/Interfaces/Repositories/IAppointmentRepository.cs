using System;
using System.Collections.Generic;
using System.Text;
using HospitalManagement.Library.Models;

namespace HospitalManagement.Library.Interfaces.Repositories
{
    public interface IAppointmentRepository
    {
        Task<int> AddAppointmentAsync(Appointment appointment);

        Task<IEnumerable<Appointment>> GetAllAppointmentsAsync();

        Task<Appointment?> GetAppointmentByIdAsync(int id);

        Task<int> UpdateAppointmentAsync(Appointment appointment);

        Task<int> DeleteAppointmentAsync(int id);
    }
}
