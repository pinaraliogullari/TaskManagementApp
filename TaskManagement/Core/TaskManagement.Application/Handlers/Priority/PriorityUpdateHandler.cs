using MediatR;
using TaskManagement.Application.Dtos;
using TaskManagement.Application.Extensions;
using TaskManagement.Application.Interfaces;
using TaskManagement.Application.Requests;
using TaskManagement.Application.Validators.Priority;

namespace TaskManagement.Application.Handlers.Priority
{
    public class PriorityUpdateHandler : IRequestHandler<PriorityUpdateRequest, Result<NoData>>
    {
        private readonly IPriorityRepository _priorityRepository;

        public PriorityUpdateHandler(IPriorityRepository priorityRepository)
        {
            _priorityRepository = priorityRepository;
        }

        public async Task<Result<NoData>> Handle(PriorityUpdateRequest request, CancellationToken cancellationToken)
        {
            PriorityUpdateRequestValidator validator = new();
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.IsValid)
            {
                var updatedEntity = await _priorityRepository.GetByFilterAsync(x => x.Id == request.Id);
                if (updatedEntity is null)
                    return new Result<NoData>(new NoData(), false, "No priority found.", null);

                updatedEntity.Definition = request.Definition ?? "";
                await _priorityRepository.SaveChangesAsync();

                return new Result<NoData>(new NoData(), true, null, null);
            }
            else
            {
                var errors = validationResult.Errors.ToMap();
                return new Result<NoData>(new NoData(), false, null, errors);
            }




        }
    }
}
