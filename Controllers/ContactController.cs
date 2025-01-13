using Microsoft.AspNetCore.Mvc;

namespace GKBInternational.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
