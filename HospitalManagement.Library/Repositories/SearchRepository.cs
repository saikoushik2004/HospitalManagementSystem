using HospitalManagement.Library.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using HospitalManagement.Library.Models;
using HospitalManagement.Library.Data;

namespace HospitalManagement.Library.Repositories
{
    public class SearchRepository : ISearchRepository
    {
        private readonly DapperContext _dapperContext;

        public SearchRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<IEnumerable<SearchResult>> SearchAsync(string searchTerm)
        {
            using var connection = _dapperContext.CreateConnection();

            string query = @"Select PatientId as Id,
FullName as Name,

'Patient' as Type,
PatientNumber as Number
From Patients
Where FullName Like @SearchTerm
or PatientNumber Like @SearchTerm

UNION ALL

Select
DoctorId as Id,
FullName as Name,
'Doctor' As Type,
DoctorNumber As Number
From Doctors
Where FullName Like @SearchTerm
or DoctorNumber Like @SearchTerm

Union All

Select 
AppointmentId as Id ,
AppointmentNumber As Name,
'Appointment' As Type,
AppointmentNumber as Number
From Appointments
Where AppointmentNumber Like @SearchTerm;";

            return await connection.QueryAsync<SearchResult>(query, new
            {
                SearchTerm = "%" + searchTerm + "%"
            });
        }
    }
}
