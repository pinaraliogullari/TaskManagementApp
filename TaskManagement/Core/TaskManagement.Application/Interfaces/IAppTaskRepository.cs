using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Interfaces
{
    public interface IAppTaskRepository
    {
        Task<List<AppTask>> GetAllAsync();
    }
}
