﻿using Microsoft.AspNetCore.Mvc;

namespace TaskManagement.UI.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

    }
}
