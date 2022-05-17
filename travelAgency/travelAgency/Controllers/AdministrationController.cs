using Microsoft.AspNetCore.Mvc;

namespace travelAgency.Controllers
{
    public class Administration : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
