using MediatR;
using TaskManagement.Application.Dtos;
using static TaskManagement.Application.Dtos.PriorityDtos;

namespace TaskManagement.Application.Requests
{
    public class PriorityRequests
    {
        public record PriorityListRequest():IRequest<Result<List<PriorityListDto>>>;
        public record PriorityGetByIdRequest(int Id):IRequest<Result<PriorityListDto>>;
        public record PriorityUpdateRequest(int Id,string Definition):IRequest<Result<NoData>>;
        public record PriorityCreateRequest(string Definition) :IRequest<Result<NoData>>;
        public record PriorityDeleteRequest(int Id) :IRequest<Result<NoData>>;
           
    }
}
