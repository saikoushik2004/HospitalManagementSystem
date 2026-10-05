using System;
using System.Collections.Generic;
using System.Text;
using HospitalManagement.Library.Models;

namespace HospitalManagement.Library.Interfaces.Services
{
    public interface IPatientService
    {
        Task<int> AddPatientAsync(Patient patient);

        Task<IEnumerable<Patient>> GetAllPatientsAsync();

        Task<Patient?> GetPatientByIdAsync(int patientId);

        Task<int> UpdatePatientAsync(Patient patient); 


        Task<int> DeletePatientAsync(int patientId);

        Task<IEnumerable<Patient>> SearchPatientAsync(string searchTerm);
    }
}
