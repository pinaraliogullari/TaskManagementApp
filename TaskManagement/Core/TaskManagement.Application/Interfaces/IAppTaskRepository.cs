using TaskManagement.Application.Dtos;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Interfaces
{
    public interface IAppTaskRepository
    {
        Task<PagedData<AppTask>> GetAllAsync(int activePage, int pageSize = 10);
    }
}
