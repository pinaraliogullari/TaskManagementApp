using MediatR;
using System.IO.Pipes;
using TaskManagement.Application.Dtos;
using TaskManagement.Application.Interfaces;
using TaskManagement.Application.Requests;

namespace TaskManagement.Application.Handlers.Priority
{
    public class PriorityDeleteHandler : IRequestHandler<PriorityDeleteRequest, Result<NoData>>
    {
        private readonly IPriorityRepository _priorityRepository;

        public PriorityDeleteHandler(IPriorityRepository priorityRepository)
        {
            _priorityRepository = priorityRepository;
        }

        public async Task<Result<NoData>> Handle(PriorityDeleteRequest request, CancellationToken cancellationToken)
        {
            var deletedEntity = await _priorityRepository.GetByFilterAsync(x => x.Id == request.Id);
            if (deletedEntity is not null)
            {
                await _priorityRepository.DeleteAsync(deletedEntity);
                return new Result<NoData>(new NoData(), true, null, null);
            }

            return new Result<NoData>(new NoData(), false, "No deleted priority found.", null);
        }
    }
}
