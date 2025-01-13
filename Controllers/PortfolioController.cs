using Microsoft.AspNetCore.Mvc;

namespace GKBInternational.Controllers
{
    public class PortfolioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
