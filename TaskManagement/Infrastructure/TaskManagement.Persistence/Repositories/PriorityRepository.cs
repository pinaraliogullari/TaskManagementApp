using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TaskManagement.Application.Interfaces;
using TaskManagement.Domain.Entities;
using TaskManagement.Persistence.Context;

namespace TaskManagement.Persistence.Repositories
{
    public class PriorityRepository : IPriorityRepository
    {
        private readonly TaskManagementDbContext _context;

        public PriorityRepository(TaskManagementDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateAsync(Priority priority)
        {
            await _context.Priorities.AddAsync(priority);
            return await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Priority priority)
        {
            _context.Priorities.Remove(priority);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Priority>> GetAllAsync() =>
             await _context.Priorities.AsNoTracking().ToListAsync();

        public async Task<Priority?> GetByFilterAsync(Expression<Func<Priority, bool>> predicate) =>
            await _context.Priorities.SingleOrDefaultAsync(predicate);


        public async Task<Priority?> GetByFilterAsNoTrackingAsync(Expression<Func<Priority, bool>> predicate) =>
             await _context.Priorities.AsNoTracking().SingleOrDefaultAsync(predicate);

        public async Task<int> SaveChangesAsync() =>
            await _context.SaveChangesAsync();

    }
}
