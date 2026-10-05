using Dapper;
using HospitalManagement.Library.Data;
using HospitalManagement.Library.Interfaces.Repositories;
using HospitalManagement.Library.Models.HospitalManagement.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagement.Library.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DapperContext _dapperContext;

        public UserRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<User?> GetUserByUserNameAsync(string username)
        {
            using var connection = _dapperContext.CreateConnection();

            string query = @"Select UserId,
Username,
PasswordHash,
FullName,
CreatedDate
From Users
Where Username = @Username;";

            return await connection.QueryFirstOrDefaultAsync<User>(query, new { Username = username });

        }
    }
}
