﻿using Microsoft.AspNetCore.Mvc;

namespace GKBInternational.Controllers
{
    public class ServicesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
