using MediatR;
using TaskManagement.Application.Dtos;
using TaskManagement.Application.Extensions;
using TaskManagement.Application.Interfaces;
using TaskManagement.Application.Requests;
using TaskManagement.Application.Validators;

namespace TaskManagement.Application.Handlers.AppTask
{
    public class AppTaskCreateHandler : IRequestHandler<AppTaskCreateRequest, Result<AppTaskDto>>
    {
        private readonly IAppTaskRepository _appTaskRepository;
        private readonly IPriorityRepository _priorityRepository;

        public AppTaskCreateHandler(IAppTaskRepository appTaskRepository, IPriorityRepository priorityRepository)
        {
            _appTaskRepository = appTaskRepository;
            _priorityRepository = priorityRepository;
        }

        public async Task<Result<AppTaskDto>> Handle(AppTaskCreateRequest request, CancellationToken cancellationToken)
        {
            var priorities=await  _priorityRepository.GetAllAsync();
            var priorityDtoList = priorities.Select(x => new PriorityListDto(x.Id, x.Definition)).ToList();

            AppTaskCreateRequestValidator validator = new();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.IsValid)
            {
                var rows = await _appTaskRepository.CreateAsync(request.ToMap());
                if (rows > 0)
                    return new Result<AppTaskDto>(new AppTaskDto(priorityDtoList), true, null, null);
                return new Result<AppTaskDto>(new AppTaskDto(priorityDtoList), false, "An error occured", null);
            }
            else
            {
                return new Result<AppTaskDto>(new AppTaskDto(priorityDtoList), false, null, validationResult.Errors.ToMap());
            }
        }
    }
}
