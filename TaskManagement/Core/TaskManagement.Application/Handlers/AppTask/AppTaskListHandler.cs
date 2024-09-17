using MediatR;
using TaskManagement.Application.Dtos;
using TaskManagement.Application.Interfaces;
using TaskManagement.Application.Requests;

namespace TaskManagement.Application.Handlers
{
    public class AppTaskListHandler : IRequestHandler<AppTaskListRequest, PagedResult<AppTaskListDto>>
    {
        private readonly IAppTaskRepository _appTaskRepository;

        public AppTaskListHandler(IAppTaskRepository appTaskRepository)
        {
            _appTaskRepository = appTaskRepository;
        }

        public async Task<PagedResult<AppTaskListDto>> Handle(AppTaskListRequest request, CancellationToken cancellationToken)
        {
            var list = await _appTaskRepository.GetAllAsync(activePage:request.ActivePage,s:request.S,pageSize:7);
            var result = new List<AppTaskListDto>();

            foreach (var appTask in list.Data)
            {
                var dto = new AppTaskListDto(appTask.Id, appTask.Title, appTask.Description, appTask.Priority?.Definition, appTask.State);
                result.Add(dto);
            }

            return new PagedResult<AppTaskListDto>(result, request.ActivePage, list.PageSize, list.TotalPages);
        }
    }
}
