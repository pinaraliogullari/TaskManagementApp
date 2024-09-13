using MediatR;
using TaskManagement.Application.Dtos;
using TaskManagement.Application.Interfaces;
using TaskManagement.Application.Requests;

namespace TaskManagement.Application.Handlers
{
    public class PriorityGetByIdHandler : IRequestHandler<PriorityGetByIdRequest, Result<PriorityListDto>>
    {
        private readonly IPriorityRepository _priorityRepository;

        public PriorityGetByIdHandler(IPriorityRepository priorityRepository)
        {
            _priorityRepository = priorityRepository;
        }

        public async Task<Result<PriorityListDto>> Handle(PriorityGetByIdRequest request, CancellationToken cancellationToken)
        {
            var priority = await _priorityRepository.GetByFilterAsync(x => x.Id == request.Id);
            if (priority is null)
                return new Result<PriorityListDto>(new PriorityListDto(0, ""), false, "No priority found", null);
            return new Result<PriorityListDto>(new PriorityListDto(priority.Id, priority.Definition), true, null, null);
        }
    }
}
