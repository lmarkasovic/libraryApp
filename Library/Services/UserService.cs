﻿using Library.Models;
using Library.Models.ViewModels;
using Library.Repository;

namespace Library.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepo;
        public UserService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public UserViewModel GetUserDetails(int id)
        {
            var user = _userRepo.GetUserDetails(id);
            var result = new UserViewModel()
            {
                Name = user.Name,
                Surname = user.Surname
            };
            return result;
        }
    }
}