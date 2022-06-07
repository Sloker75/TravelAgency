using BLL.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace travelAgency.Controllers
{
    public class ExcursionController : Controller
    {
        private readonly ExcursionService _excursionService;
        public ExcursionController(ExcursionService excursionService)
        {
            this._excursionService = excursionService;
        }
        public async Task<IActionResult> Index(int ExcursionId)
        {
            return View(await _excursionService.FindByConditionAsync(x => x.Id == ExcursionId));
        }


        public IActionResult AddShowPlace() => View();
        [HttpPost]
        public async Task<IActionResult> AddShowPlaceAsync(ShowPlace showPlace, int excursionId)
        {
            if (showPlace != null && excursionId != null)
            {
                await _excursionService.AddShowPlaceAsync(showPlace, excursionId);
                return View("Index");
            }
            return RedirectToRoute(new { Controller = "Home", Action = "Index" });
        }


        public IActionResult DeleteShowPlace() => View();
        [HttpPost]
        public async Task<IActionResult> DeleteShowPlaceAsync(int remShowPlaceId)
        {
            if (remShowPlaceId != null)
            {
                await _excursionService.DeleteShowPlaceAsync(remShowPlaceId);
                return View("Index");
            }
            return RedirectToRoute(new { Controller = "Home", Action = "Index" });
        }
    }
}
