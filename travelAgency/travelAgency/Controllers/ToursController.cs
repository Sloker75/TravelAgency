using Microsoft.AspNetCore.Mvc;

namespace travelAgency.Controllers
{
    public class ToursController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
