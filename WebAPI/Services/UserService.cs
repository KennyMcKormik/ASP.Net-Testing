using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;

        public UserService(DataContext context) { _context = context; }

        public async Task<List<User>> AddUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            var result = await _context.Users.ToListAsync();

            return result;
        }

        public async Task<List<User>?> DeleteUser(int id)
        {
            var result = await _context.Users.FindAsync(id);

            if (result is null)
                return null;

            _context.Users.Remove(result);
            await _context.SaveChangesAsync();

            return await _context.Users.ToListAsync();

        }

        public async Task<List<User>> GetAllUsers()
        {
            var result = await _context.Users.ToListAsync();
            return result;
        }

        public async Task<User?> GetUser(int id)
        {
            var result = await _context.Users.FindAsync(id);

            if (result is null)
                return null; 

            return result;
        }

        public async Task<List<User>?> UpdateUser(int id, User user)
        {
            var result = await _context.Users.FindAsync(id);

            if (result is null)
                return null;

            result.Username = user.Username;
            result.Password = user.Password;
            result.Token = user.Token;

            await _context.SaveChangesAsync();

            return await _context.Users.ToListAsync();
        }
    }
}
