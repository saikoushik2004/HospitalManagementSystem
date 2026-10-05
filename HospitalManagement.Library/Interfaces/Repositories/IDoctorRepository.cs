using HospitalManagement.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagement.Library.Interfaces.Repositories
{
    public interface IDoctorRepository
    {
        Task<int> AddDoctorAsync(Doctor doctor);

        Task<IEnumerable<Doctor>> GetAllDoctorsAsync();

        Task<Doctor?> GetDoctorByIdAsync(int id);

        Task<int> UpdateDoctorAsync(Doctor doctor);

        Task<int> DeleteDoctorAsync(int doctorId);

        Task<IEnumerable<Doctor>> SearchDoctorAsync(string searchTerm);

    }
}
