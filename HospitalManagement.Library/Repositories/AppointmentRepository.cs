using System;
using System.Collections.Generic;
using System.Text;
using HospitalManagement.Library.Models;
using HospitalManagement.Library.Interfaces.Repositories;
using HospitalManagement.Library.Data;
using Dapper;

namespace HospitalManagement.Library.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly DapperContext _dapperContext;

        public AppointmentRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<int> AddAppointmentAsync(Appointment appointment)
        {
            using var connection = _dapperContext.CreateConnection();

            string query = @"Insert into Appointments(AppointmentNumber,
PatientId,
DoctorId,
AppointmentDate,
Status) Values (
@AppointmentNumber,
@PatientId,
@DoctorId,
@AppointmentDate,
@Status);";

            return await connection.ExecuteAsync(query, appointment);
        }


        public async Task<IEnumerable<Appointment>> GetAllAppointmentsAsync()
        {
            using var connection = _dapperContext.CreateConnection();

            string query = @"Select AppointmentId, AppointmentNumber,
PatientId,
DoctorId,
AppointmentDate,
Status from Appointments";

            return await connection.QueryAsync<Appointment>(query);
        }

        public async Task<Appointment?> GetAppointmentByIdAsync(int id)
        {
            using var connection = _dapperContext.CreateConnection();

            string query = @"Select AppointmentId,
AppointmentNumber,
PatientId,
DoctorId,
AppointmentDate,
Status from Appointments where AppointmentId = @AppointmentId";

            return await connection.QueryFirstOrDefaultAsync<Appointment>(query, new { AppointmentId = id });
        }

        public async Task<int> UpdateAppointmentAsync(Appointment appointment)
        {
            using var connection = _dapperContext.CreateConnection();

            string query = @"Update Appointments Set 
AppointmentNumber = @AppointmentNumber,
PatientId = @PatientId,
DoctorId = @DoctorId,
AppointmentDate = @AppointmentDate,
Status = @Status where AppointmentId = @AppointmentId";

            return await connection.ExecuteAsync(query, appointment);
        }


        public async Task<int> DeleteAppointmentAsync(int id)
        {
            using var connection = _dapperContext.CreateConnection();

            string query = @"Delete From Appointments where AppointmentId = @AppointmentId";

            return await connection.ExecuteAsync(query, new { AppointmentId = id });
        }


    }
}
