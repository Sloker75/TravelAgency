using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using travelAgency.Models;

namespace travelAgency.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TourService _tourService;

        public HomeController(ILogger<HomeController> logger, TourService tourService)
        {
            _logger = logger;
            this._tourService = tourService;
        }

        public async Task<IActionResult> Index()
        {
            return View( await _tourService.FindByConditionAsync(x=>x.Id<10));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}