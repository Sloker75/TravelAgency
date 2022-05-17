using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace travelAgency.Controllers
{
    public class ToursController : Controller
    {
        private readonly TourService _tourService;
        public ToursController(TourService _tourService)
        {
            this._tourService = _tourService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
