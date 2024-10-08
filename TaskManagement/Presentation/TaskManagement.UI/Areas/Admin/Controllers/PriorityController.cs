﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Requests;

namespace TaskManagement.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class PriorityController : Controller
    {
        private readonly IMediator _mediator;

        public PriorityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> List()
        {
            ViewBag.Active = "Priority";
            var result = await _mediator.Send(new PriorityListRequest());
            return View(result.Data);
        }

        public IActionResult Create()
        {
            ViewBag.Active = "Priority";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PriorityCreateRequest request)
        {
            ViewBag.Active = "Priority";
            var result = await _mediator.Send(request);
            if (result.IsSuccess)
                return RedirectToAction("List");
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
                    ModelState.AddModelError("", result.ErrorMessage ?? "Unknown error occured. Please contact with your service provider");
                }
                return View(request);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            ViewBag.Active = "Priority";
            await _mediator.Send(new PriorityDeleteRequest(id));
            return RedirectToAction("List");
        }

        public async Task<IActionResult> Update(int id)
        {
            ViewBag.Active = "Priority";
            var result = await _mediator.Send(new PriorityGetByIdRequest(id));
            if (result.IsSuccess)
            {
                var requestModel = new PriorityUpdateRequest(result.Data.Id, result.Data.Definition);
                return View(requestModel);
            }
            else
            {
                ModelState.AddModelError("", result.ErrorMessage ?? "Unknown error occured. Please contact with your service provider");
                var requestModel = new PriorityUpdateRequest(0, null);
                return View(requestModel);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Update(PriorityUpdateRequest request)
        {
            ViewBag.Active = "Priority";
            var result = await _mediator.Send(request);
            if (result.IsSuccess)
                return RedirectToAction("List");
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
                    ModelState.AddModelError("", result.ErrorMessage ?? "Unknown error occured. Please contact with your service provider");
                }
                return View(request);
            }
        }
    }
}
