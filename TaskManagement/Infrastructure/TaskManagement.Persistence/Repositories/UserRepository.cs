using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TaskManagement.Application.Interfaces;
using TaskManagement.Domain.Entities;
using TaskManagement.Persistence.Context;

namespace TaskManagement.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TaskManagementDbContext _context;

        public UserRepository(TaskManagementDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateUserAsync(AppUser user)
        {
            _context.Users.Add(user);
            return await _context.SaveChangesAsync();
        }

        public async Task<AppUser?> GetByFilterAsync(Expression<Func<AppUser, bool>> filter, bool asNoTracking=true)
        {
            if (asNoTracking)
              return await _context.Users.AsNoTracking().SingleOrDefaultAsync(filter);

            return await _context.Users.SingleOrDefaultAsync(filter);

        }
    }
}
