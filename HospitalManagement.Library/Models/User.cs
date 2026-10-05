using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagement.Library.Models
{
    namespace HospitalManagement.Library.Models
    {
        public class User
        {
            public int UserId { get; set; }

            public string Username { get; set; } = string.Empty;

            public string PasswordHash { get; set; } = string.Empty;

            public string FullName { get; set; } = string.Empty;

            public DateTime CreatedDate { get; set; }
        }
    }
}
