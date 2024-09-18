using Microsoft.EntityFrameworkCore;
using TaskManagement.Application.Dtos;
using TaskManagement.Application.Interfaces;
using TaskManagement.Domain.Entities;
using TaskManagement.Persistence.Context;
using TaskManagement.Persistence.Extensions;

namespace TaskManagement.Persistence.Repositories
{
    public class AppTaskRepository : IAppTaskRepository
    {
        private readonly TaskManagementDbContext _context;

        public AppTaskRepository(TaskManagementDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateAsync(AppTask appTask)
        {
            await _context.Tasks.AddAsync(appTask);
            return await _context.SaveChangesAsync();
        }

        public async Task<PagedData<AppTask>> GetAllAsync(int activePage, string? s = null, int pageSize = 10)
        {
            var query = _context.Tasks.AsQueryable();
            if (!string.IsNullOrEmpty(s))
            {
                query = query.Where(x => x.Title.ToLower().Contains(s.ToLower()));
            }
            var list = await query.Include(x => x.Priority).AsNoTracking().ToPagedAsync(activePage, pageSize);
            return list;
        }

    }
}
