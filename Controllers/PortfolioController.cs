using Microsoft.AspNetCore.Mvc;

namespace GKBInternational.Controllers
{
    public class PortfolioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Electronics()
        {
            return View("Products/Electronics"); // Specify subfolder
        }

        public IActionResult Construction()
        {
            return View("Products/Construction");
        }

        public IActionResult Machinery()
        {
            return View("Products/Machinery");
        }

        public IActionResult RawMaterials()
        {
            return View("Products/RawMaterials");
        }
    }
}
