using BLL.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Domain.Models.ViewModels;

namespace travelAgency.Controllers
{
    public class AdminController : Controller
    {
        private readonly TourService _tourService;
        private readonly UserService _userService;
        //private static readonly IdentityExtensions _identity;
        public AdminController(TourService _tourService, UserService _userService)
        {
            this._tourService = _tourService;
            this._userService = _userService;
        }
        public async Task<IActionResult> Index()
        {
            var email = this.User.FindFirstValue(ClaimTypes.Email);
            var user = (await _userService.FindByConditionAsync(x => x.Email == email)).First();
            var userVieModel = new UserViewModels() { Name = user.Name, Email = user.Email, PhoneNumber = user.PhoneNumber, PhotoPath = user.PhotoPath };
            return View(userVieModel);
        }
        public IActionResult AddEmployeeAsync() => View();

        [HttpPost]
        public async Task<IActionResult> AddEmployeeAsync(string Email)
        {
            var user = (await _userService.FindByConditionAsync(x => x.Email == Email)).First();
            await _userService.AddEmployeeAsync(user.Id);
            return RedirectToRoute(new { Controller = "Home", Action = "Index" });
        }


    }
}
