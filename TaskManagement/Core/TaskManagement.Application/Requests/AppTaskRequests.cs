﻿using MediatR;
using TaskManagement.Application.Dtos;

namespace TaskManagement.Application.Requests
{
    public record AppTaskListRequest : PagedRequest, IRequest<PagedResult<AppTaskListDto>>
    {
        public AppTaskListRequest(int activePage,string s) : base(activePage)
        {
            S = s;
        }
        public string? S {  get; set; }
    }
}
