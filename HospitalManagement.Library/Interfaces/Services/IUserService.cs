using HospitalManagement.Library.Models.HospitalManagement.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagement.Library.Interfaces.Services
{
    public interface IUserService
    {
        Task<User?> GetUserByUserNameAsync(string username);
    }
}
