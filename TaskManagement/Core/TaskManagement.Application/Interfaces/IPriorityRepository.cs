using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Interfaces
{
    public interface IPriorityRepository
    {
        Task<List<Priority>> GetAllAsync();
        Task<int> CreateAsync(Priority priority);
    }
}
