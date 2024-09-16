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



        public async Task<PagedData<AppTask>> GetAllAsync(int activePage, int pageSize = 10) =>
            await _context.Tasks.Include(x => x.Priority).AsNoTracking().ToPagedAsync(activePage, pageSize);

    }
}
