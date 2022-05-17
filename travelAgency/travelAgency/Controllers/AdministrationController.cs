using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace travelAgency.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly UserService _userService;
        public AdministrationController(UserService _userService)
        {
            this._userService = _userService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
