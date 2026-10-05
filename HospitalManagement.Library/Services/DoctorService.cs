using HospitalManagement.Library.Interfaces.Repositories;
using HospitalManagement.Library.Interfaces.Services;
using HospitalManagement.Library.Models;
using HospitalManagement.Library.Repositories;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace HospitalManagement.Library.Services
{
    public class DoctorService : IDoctorService
    {

        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task<int> AddDoctorAsync(Doctor doctor)
        {
            return await _doctorRepository.AddDoctorAsync(doctor);
        }

        public async Task<IEnumerable<Doctor>> GetAllDoctorsAsync()
        {
            return await _doctorRepository.GetAllDoctorsAsync();
        }

        public async Task<Doctor?> GetDoctorByIdAsync(int id)
        {
            return await _doctorRepository.GetDoctorByIdAsync(id);
        }

        public async Task<int> UpdateDoctorAsync(Doctor doctor)
        {
            return await _doctorRepository.UpdateDoctorAsync(doctor);
        }


        public async Task<int> DeleteDoctorAsync(int doctorId)
        {
            return await _doctorRepository.DeleteDoctorAsync(doctorId);
        }

        public async Task<IEnumerable<Doctor>> SearchDoctorAsync(string searchTerm)
        {
            return await _doctorRepository.SearchDoctorAsync(searchTerm);
        }
    }
}
