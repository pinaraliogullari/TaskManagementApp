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

        public async Task<AppUser?> GetByFilter(Expression<Func<AppUser, bool>> filter, bool asNoTracking=true)
        {
            if (asNoTracking)
              return await _context.Users.AsNoTracking().SingleOrDefaultAsync(filter);

            return await _context.Users.SingleOrDefaultAsync(filter);

        }
    }
}
