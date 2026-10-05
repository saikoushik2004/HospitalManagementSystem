using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySqlConnector;

namespace HospitalManagement.Library.Data
{
    public class DapperContext
    {
        private readonly string _connectionstring;

        public DapperContext(string connectionstring)
        {
            _connectionstring = connectionstring;
        }

        public IDbConnection CreateConnection()
        {
            return new MySqlConnection(_connectionstring);
        }



    }
}
