using MediatR;
using TaskManagement.Application.Dtos;

namespace TaskManagement.Application.Requests
{
    public record AppTaskListRequest() : IRequest<Result<List<AppTaskListDto>>>;
}
