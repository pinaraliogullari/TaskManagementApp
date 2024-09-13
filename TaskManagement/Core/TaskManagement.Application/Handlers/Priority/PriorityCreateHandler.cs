using MediatR;
using TaskManagement.Application.Dtos;
using TaskManagement.Application.Extensions;
using TaskManagement.Application.Interfaces;
using TaskManagement.Application.Requests;
using TaskManagement.Application.Validators;

namespace TaskManagement.Application.Handlers
{
    public class PriorityCreateHandler : IRequestHandler<PriorityCreateRequest, Result<NoData>>
    {
        private readonly IPriorityRepository _priorityRepository;

        public PriorityCreateHandler(IPriorityRepository priorityRepository)
        {
            _priorityRepository = priorityRepository;
        }

        public async Task<Result<NoData>> Handle(PriorityCreateRequest request, CancellationToken cancellationToken)
        {
            var validator = new PriorityCreateRequestValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.IsValid)
            {
                var rowCount = await _priorityRepository.CreateAsync(request.ToMap());
                if (rowCount > 0)
                    return new Result<NoData>(new NoData(), true, null, null);
                return new Result<NoData>(new NoData(), false, "An error occured. Please contact with your service provider.", null);
            }
            else
            {
                var errors = validationResult.Errors.ToMap();
                return new Result<NoData>(new NoData(), false, null, errors);
            }

        }
    }
}
