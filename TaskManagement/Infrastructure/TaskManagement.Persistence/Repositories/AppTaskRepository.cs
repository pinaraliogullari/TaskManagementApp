using Microsoft.EntityFrameworkCore;
using TaskManagement.Application.Interfaces;
using TaskManagement.Domain.Entities;
using TaskManagement.Persistence.Context;

namespace TaskManagement.Persistence.Repositories
{
    public class AppTaskRepository : IAppTaskRepository
    {
        private readonly TaskManagementDbContext _context;

        public AppTaskRepository(TaskManagementDbContext context)
        {
            _context = context;
        }

        public async Task<List<AppTask>> GetAllAsync()=>
            await _context.Tasks.Include(x=>x.Priority).AsNoTracking().ToListAsync();
        
    }
}
