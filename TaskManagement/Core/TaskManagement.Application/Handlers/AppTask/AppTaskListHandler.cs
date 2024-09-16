using MediatR;
using TaskManagement.Application.Dtos;
using TaskManagement.Application.Interfaces;
using TaskManagement.Application.Requests;

namespace TaskManagement.Application.Handlers
{
    public class AppTaskListHandler : IRequestHandler<AppTaskListRequest, Result<List<AppTaskListDto>>>
    {
        private readonly IAppTaskRepository _appTaskRepository;

        public AppTaskListHandler(IAppTaskRepository appTaskRepository)
        {
            _appTaskRepository = appTaskRepository;
        }

        public async Task<Result<List<AppTaskListDto>>> Handle(AppTaskListRequest request, CancellationToken cancellationToken)
        {
            var list = await _appTaskRepository.GetAllAsync();
            var result= new List<AppTaskListDto>();

            foreach (var appTask in list) 
            { 
                var dto= new AppTaskListDto(appTask.Id,appTask.Title,appTask.Description,appTask.Priority?.Definition,appTask.State);
                result.Add(dto);
            }

            return new Result<List<AppTaskListDto>>(result,true,null,null);
        }
    }
}
