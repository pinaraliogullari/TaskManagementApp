using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Priority>> GetAllAsync() =>
             await _context.Priorities.AsNoTracking().ToListAsync();

    }
}
