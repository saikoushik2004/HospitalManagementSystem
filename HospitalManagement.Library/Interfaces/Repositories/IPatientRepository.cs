using HospitalManagement.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagement.Library.Interfaces.Repositories
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> GetAllPatientsAsync();

        Task<Patient?> GetPatientByIdAsync(int patientId);

        Task<int> AddPatientAsync (Patient patient);

        Task<int> UpdatePatientAsync(Patient patient);

        Task<int> DeletePatientAsync(int patientId);

        Task<IEnumerable<Patient>> SearchPatientAsync(string searchTerm);
    }
}
