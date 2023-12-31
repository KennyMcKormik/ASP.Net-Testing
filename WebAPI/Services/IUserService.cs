﻿using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Services
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();
        Task<User?> GetUser(int id);
        Task<List<User>> AddUser(User user);
        Task<List<User>?> UpdateUser(int id,User user);
        Task<List<User>?> DeleteUser(int id);
    }
}
