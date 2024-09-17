using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Requests;

namespace TaskManagement.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AppTaskController : Controller
    {
        private readonly IMediator _mediator;

        public AppTaskController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> List(string? s,int activePage = 1)
        {
            ViewBag.s = s;
            ViewBag.Active = "AppTask";
            var result = await _mediator.Send(new AppTaskListRequest(activePage,s));
            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
