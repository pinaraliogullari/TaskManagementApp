using MediatR;
using TaskManagement.Application.Dtos;

namespace TaskManagement.Application.Requests
{
    public record LoginRequest(string Username, string Password):IRequest<Result<LoginResponseDto?>>;
}
