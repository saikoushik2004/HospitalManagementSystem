using System;
using System.Collections.Generic;
using System.Text;
using HospitalManagement.Library.Models;
using HospitalManagement.Library.Models.HospitalManagement.Library.Models;

namespace HospitalManagement.Library.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetUserByUserNameAsync(string username);
    }
}
