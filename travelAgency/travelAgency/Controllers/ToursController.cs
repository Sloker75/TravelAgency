using BLL.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace travelAgency.Controllers
{
    public class ToursController : Controller
    {
        private readonly TourService _tourService;
        private readonly UserService _userService;
        public ToursController(TourService _tourService, UserService _userService)
        {
            this._tourService = _tourService;
            this._userService = _userService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _tourService.GetAllAsync());
        }


        public IActionResult AddTour() => View();

        [HttpPost]
        public async Task<IActionResult> AddTourAsync(Tour tour, int employeeId)
        {
            if (tour != null && employeeId != null)
            {
                await _userService.AddTourAsync(tour, employeeId);
                return View("Index");
            }
            return RedirectToRoute(new { Controller = "Home", Action = "Index" });
        }

        public IActionResult AddExcursion() => View();
        [HttpPost]
        public async Task<IActionResult> AddExcursionAsync(Excursion excursion, int TourId)
        {
            if (excursion != null && TourId != null)
            {
                await _tourService.AddExcursionAsync(excursion, TourId);
                return View("Index");
            }
            return RedirectToRoute(new { Controller = "Home", Action = "Index" });
        }

        public IActionResult AddShowPlace() => View();
        [HttpPost]
        public async Task<IActionResult> AddShowPlaceAsync(ShowPlace showPlace, int excursionId)
        {
            if (showPlace != null && excursionId != null)
            {
                await _tourService.AddShowPlaceAsync(showPlace, excursionId);
                return View("Index");
            }
            return RedirectToRoute(new { Controller = "Home", Action = "Index" });
        }
        public IActionResult AddComment() => View();
        [HttpPost]
        public async Task<IActionResult> AddComment(Comment comment, int tourId, int userId)
        {
            if (comment != null && tourId != null && userId != null)
            {
                await _tourService.AddComenntAsync(comment, tourId, userId);
                return View("Index");
            }
            return RedirectToRoute(new { Controller = "Home", Action = "Index" });
        }




        public IActionResult DeleteTour() => View();
        [HttpPost]
        public async Task<IActionResult> DeleteTourAsync(int remTourId)
        {
            if (remTourId != null)
            {
                await _userService.DeleteTourAsync(remTourId);
                return View("Index");
            }
            return RedirectToRoute(new { Controller = "Home", Action = "Index" });
        }

        public IActionResult DeleteExcursion() => View();
        [HttpPost]
        public async Task<IActionResult> DeleteExcursionAsync(int remExcursionId)
        {
            if (remExcursionId != null)
            {
                await _tourService.DeleteExcursionAsync(remExcursionId);
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
                await _tourService.DeleteShowPlaceAsync(remShowPlaceId);
                return View("Index");
            }
            return RedirectToRoute(new { Controller = "Home", Action = "Index" });
        }

        


        public IActionResult ChangeTour() => View();
        [HttpPost]
        public async Task<IActionResult> ChangeTour(Tour tour, int oldTour)
        {
            if (tour != null && oldTour != null)
            {
                await _userService.ChangeTourAsync(tour, oldTour);
                return View("Index");
            }
            return RedirectToRoute(new { Controller = "Home", Action = "Index" });
        }


    }
}
