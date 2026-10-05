using HospitalManagement.Library.Interfaces.Repositories;
using HospitalManagement.Library.Interfaces.Services;
using HospitalManagement.Library.Models.HospitalManagement.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagement.Library.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User?> GetUserByUserNameAsync(string username)
        {
            return await _userRepository.GetUserByUserNameAsync(username);
        }
    }
}
