using System;
using System.Collections.Generic;
using System.Text;
using HospitalManagement.Library.Models;
using HospitalManagement.Library.Interfaces.Repositories;
using HospitalManagement.Library.Data;
using Dapper;


namespace HospitalManagement.Library.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {

        private readonly DapperContext _dapperContext;

        public DoctorRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<int> AddDoctorAsync(Doctor doctor)
        {
            using var connection = _dapperContext.CreateConnection();

            string query = @"Insert into Doctors(
DoctorNumber,
FullName,
Specialization,
PhoneNumber,
ConsultationFee,
CreatedDate)
values(
@DoctorNumber,
@FullName,
@Specialization,
@PhoneNumber,
@ConsultationFee,
@CreatedDate);";
            return await connection.ExecuteAsync(query, doctor);
        }


        public async Task<IEnumerable<Doctor>> GetAllDoctorsAsync()
        {
            using var connection = _dapperContext.CreateConnection();

            string query = @"Select DoctorId,    
DoctorNumber,
FullName,
Specialization,
PhoneNumber,
ConsultationFee,
CreatedDate
from Doctors";

            return await connection.QueryAsync<Doctor>(query);
        }

        public async Task<Doctor?> GetDoctorByIdAsync(int id)
        {
            using var connection = _dapperContext.CreateConnection();

            string query = @"Select DoctorId,
DoctorNumber,
FullName,
Specialization,
PhoneNumber,
ConsultationFee,
CreatedDate
from Doctors where DoctorId = @DoctorId";

            return await connection.QueryFirstOrDefaultAsync<Doctor>(query, new { DoctorId = id });
        }

        public async Task<int> UpdateDoctorAsync(Doctor doctor)
        {
            using var connection = _dapperContext.CreateConnection();

            string query = @"Update Doctors Set
DoctorNumber = @DoctorNumber,
FullName = @FullName,
Specialization = @Specialization,
PhoneNumber = @PhoneNumber,
ConsultationFee = @ConsultationFee,
CreatedDate = @CreatedDate
where DoctorId = @DoctorId";

            return await connection.ExecuteAsync(query, doctor);
        }


        public async Task<int> DeleteDoctorAsync(int doctorId)
        {
            using var connection = _dapperContext.CreateConnection();

            string query = @"Delete from Doctors where DoctorId = @DoctorId";

            return await connection.ExecuteAsync(query, new {DoctorId = doctorId });
        }

        public async Task<IEnumerable<Doctor>> SearchDoctorAsync(string searchTerm)
        {
            using var connection = _dapperContext.CreateConnection();

            string query = @"Select 
DoctorNumber,
FullName,
Specialization,
PhoneNumber,
ConsultationFee,
CreatedDate
From Doctors
Where FullName Like @SearchTerm";

            return await connection.QueryAsync<Doctor>(query, new { SearchTerm = "%" + searchTerm + "%" });
        }
    }
}
