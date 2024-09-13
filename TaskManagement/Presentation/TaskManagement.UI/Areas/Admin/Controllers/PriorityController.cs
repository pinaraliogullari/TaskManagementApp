using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Requests;

namespace TaskManagement.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class PriorityController : Controller
    {
        private readonly IMediator _mediator;

        public PriorityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> List()
        {
            var result = await _mediator.Send(new PriorityListRequest());
            return View(result.Data);
        }
    }
}
