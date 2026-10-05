using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Dapper;
using HospitalManagement.Library.Data;
using HospitalManagement.Library.Interfaces.Repositories;
using HospitalManagement.Library.Models;

namespace HospitalManagement.Library.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly DapperContext _dapperContext;

        public PatientRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<int> AddPatientAsync(Patient patient)
        {
             using var connection = _dapperContext.CreateConnection();

            string query = @"Insert into Patients
(
PatientNumber,
FullName,
Gender,
Age,
PhoneNumber,
Address,
CreatedDate)
Values(
@PatientNumber,
@FullName,
@Gender,
@Age,
@PhoneNumber,
@Address,
@CreatedDate);";

            return await connection.ExecuteAsync(query, patient);

                }

        public async Task<int> DeletePatientAsync(int patientId)
        {
            using var connection = _dapperContext.CreateConnection();

            string query = @"Delete from Patients where PatientId = @PatientId ";

            return await connection.ExecuteAsync(query, new
            {
                PatientId = patientId
            });
        }

        public async Task<IEnumerable<Patient>> GetAllPatientsAsync()
        {
            using var connection = _dapperContext.CreateConnection();

            string query = @"Select 
                            PatientId,
                            PatientNumber,
                            FullName,
                            Gender,
                            Age,
                            PhoneNumber,
                            Address,
                            CreatedDate
                            From Patients";

            return await connection.QueryAsync<Patient>(query);
        }

        public async Task<Patient?> GetPatientByIdAsync(int patientId)
        {
            using var connection = _dapperContext.CreateConnection();

            string query = @"select 
                            PatientId,
                            PatientNumber,
                            FullName,
                            Gender,
                            Age,
                            PhoneNumber,
                            Address,
                            CreatedDate
                            From Patients
                            where PatientId = @PatientId";

            return await connection.QueryFirstOrDefaultAsync<Patient>(query, new {PatientId = patientId});
        }

        public async Task<IEnumerable<Patient>> SearchPatientAsync(string searchTerm)
        {
            using var connection = _dapperContext.CreateConnection();

            string query = @"Select 
PatientId,
PatientNumber,
FullName,
Gender,
Age,
PhoneNumber,
Address,
CreatedDate
From Patients
Where FullName Like @SearchTerm";

            return await connection.QueryAsync<Patient>(query, new { SearchTerm = "%" + searchTerm + "%" });
        }

        public async Task<int> UpdatePatientAsync(Patient patient)
        {
            using var connection = _dapperContext.CreateConnection();

            string query = @"Update Patients set 
PatientNumber = @PatientNumber,
FullName = @FullName,
Gender = @Gender,
Age = @Age,
PhoneNumber = @PhoneNumber,
Address = @Address Where PatientId = @PatientId";

            return await connection.ExecuteAsync(query, patient);
        }
    }
}
