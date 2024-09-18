using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public async Task<IActionResult> List(string? s, int activePage = 1)
        {
            ViewBag.s = s;
            ViewBag.Active = "AppTask";
            var result = await _mediator.Send(new AppTaskListRequest(activePage, s));
            return View(result);
        }

        public async Task<IActionResult> Create()
        {
            var result = await _mediator.Send(new PriorityListRequest());
            ViewBag.Priorities = new List<SelectListItem>(result.Data.Select(x => new SelectListItem(x.Definition, x.Id.ToString())));
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AppTaskCreateRequest request)
        {
            var result= await _mediator.Send(request);
            ViewBag.Priorities = new List<SelectListItem>(result.Data.Priorities.Select(x => new SelectListItem(x.Definition, x.Id.ToString())));
            if (result.IsSuccess)
            {
                return RedirectToAction("List");
            }
              
            else
            {
                if (result.Errors?.Count > 0)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    }
                }
                else
                {
                    ModelState.AddModelError("",result.ErrorMessage??"An error occured. Please contact with your service provider");
                }
            }
            return View(request);
        }
    }
}
