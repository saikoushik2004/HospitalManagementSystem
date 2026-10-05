using System;
using System.Collections.Generic;
using System.Text;
using HospitalManagement.Library.Interfaces.Repositories;
using HospitalManagement.Library.Interfaces.Services;
using HospitalManagement.Library.Models;

namespace HospitalManagement.Library.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<int> AddPatientAsync(Patient patient)
        {
            return await _patientRepository.AddPatientAsync(patient);
        }

        public async Task<int> DeletePatientAsync(int patientId)
        {
            return await _patientRepository.DeletePatientAsync(patientId);
        }

        public async Task<IEnumerable<Patient>> GetAllPatientsAsync()
        {
            return await _patientRepository.GetAllPatientsAsync();
        }

        public async Task<Patient?> GetPatientByIdAsync(int patientId)
        {
            return await _patientRepository.GetPatientByIdAsync(patientId);
        }

        public async Task<IEnumerable<Patient>> SearchPatientAsync(string searchTerm)
        {
            return await _patientRepository.SearchPatientAsync(searchTerm);
        }

        public async Task<int> UpdatePatientAsync(Patient patient)
        {
            return await _patientRepository.UpdatePatientAsync(patient);
        }



    }
    
}
