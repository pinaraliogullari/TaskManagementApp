using MediatR;
using TaskManagement.Application.Dtos;
using TaskManagement.Application.Interfaces;
using TaskManagement.Application.Requests;

namespace TaskManagement.Application.Handlers
{
    public class PriorityListHandler : IRequestHandler<PriorityListRequest, Result<List<PriorityListDto>>>
    {
        private readonly IPriorityRepository _priorityRepository;

        public PriorityListHandler(IPriorityRepository priorityRepository)
        {
            _priorityRepository = priorityRepository;
        }

        public async Task<Result<List<PriorityListDto>>> Handle(PriorityListRequest request, CancellationToken cancellationToken)
        {
            var result = await _priorityRepository.GetAllAsync();
            var mappedResult = result.Select(x => new PriorityListDto(x.Id, x.Definition)).ToList();

            return new Result<List<PriorityListDto>>(mappedResult, true,null,null);
        }
    }
}
