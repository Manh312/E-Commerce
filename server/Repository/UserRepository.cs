using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Entities;

namespace server.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AuthContext _context;
        public UserRepository(AuthContext context)
        {
            this._context = context;
        }
        public async Task<bool> AddUser(User user)
        {
            await this._context.users.AddAsync(user);
            return await this._context.SaveChangesAsync() > 0 ? true : false;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await this._context.users.ToListAsync();
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            return await this._context.users.Where(u => u.Email == email).SingleOrDefaultAsync();
        }
    }
}
