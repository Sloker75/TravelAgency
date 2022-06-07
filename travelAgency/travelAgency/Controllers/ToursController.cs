using BLL.Services;
using Domain.Models;
using Domain.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace travelAgency.Controllers
{
    public class ToursController : Controller
    {
        private readonly TourService _tourService;
        private readonly UserService _userService;
        private readonly IHostingEnvironment _environment;
        public ToursController(TourService tourService, UserService userService, IHostingEnvironment environment)
        {
            this._tourService = tourService;
            this._userService = userService;
            this._environment = environment;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _tourService.GetAllAsync());
        }

        public async Task<IActionResult> Details(int tourId)
        {
            return View((await _tourService.FindByConditionAsync(x => x.Id == tourId)).First());
        }

        public IActionResult AddTour() => View();

        [HttpPost]
        public async Task<IActionResult> AddTourAsync(TourViewModel TourInfo)
        {

            //string wwwPath = this._environment.WebRootPath;
            //string contentPath = this._environment.ContentRootPath;

            //string path = Path.Combine(this._environment.WebRootPath, "Images");

            ////if (!Directory.Exists(path))
            ////{
            ////    Directory.CreateDirectory(postedFiles);
            ////}

            //foreach (IFormFile postedFile in postedFiles)
            //{
            //    string fileName = Path.GetFileName(postedFile.FileName);
            //    using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
            //    {
            //        postedFile.CopyTo(stream);
            //    }
            //    var fullPath = Path.Combine(path, fileName);
            //}


            //var rootPath = _environment.WebRootPath;
            //rootPath = Path.Combine(rootPath, "Images");
            //var savepath = Path.Combine(rootPath, Request.Form.Files[0].FileName);
            //Request.Form.Files[0].CopyTo(System.IO.File.Create(savepath));
            //var path = Path.Combine("~/Images", Request.Form.Files[0].FileName);

            var email = this.User.FindFirstValue(ClaimTypes.Email);
            var employee = await _userService.GetEmployeeByUserEmailAsync(email);
            var tour = new Tour()
            {
                Duration = TourInfo.Duration,
                Price = TourInfo.Price,
                TypeTransport = TourInfo.TypeTransport,
                CountPeople = TourInfo.CountPeople,
                Rating = TourInfo.TourRating,
                IsHotTour = TourInfo.IsHotTour,
                Hotel = new Hotel()
                {
                    Name = TourInfo.Name,
                    Description = TourInfo.Description,
                    Rating = TourInfo.HotelRating,
                    TypeFood = TourInfo.TypeFood,
                    TypeBeach = TourInfo.TypeBeach,
                    HotelAddress = new HotelAddress()
                    {
                        Country = TourInfo.Country,
                        City = TourInfo.City,
                        Street = TourInfo.Street,
                    },
                    //PhotoPath = new List<Image>()
                    //{
                    //    new Image() { Photo = path}
                    //}
                }
            };
            await _userService.AddTourAsync(tour, employee.Id);
            return View("Index", await _tourService.GetAllAsync());
        }

        public IActionResult AddComment() => View();
        [HttpPost]
        public async Task<IActionResult> AddCommentAsync(string text, int tourId)
        {
            var comment = new Comment();
            comment.Caption = "Vlad";
            comment.Content = text;
            comment.SendingTime = DateTime.Now;

            var email = this.User.FindFirstValue(ClaimTypes.Email);
            var user = (await _userService.FindByConditionAsync(x => x.Email == email)).First();

            await _tourService.AddComenntAsync(comment, tourId, user.Id);
            return View("Index", await _tourService.GetAllAsync());
        }

        public IActionResult AddExcursion(int TourId) => View(new Excursion() { TourId = TourId });
        [HttpPost]
        public async Task<IActionResult> AddExcursionAsync(Excursion excursion)
        {
            await _tourService.AddExcursionAsync(excursion, excursion.TourId);
            return View("Details", (await _tourService.FindByConditionAsync(x => x.Id == excursion.TourId)).First());
        }


        public async Task<IActionResult> DeleteTourAsync(int remTourId)
        {
            await _userService.DeleteTourAsync(remTourId);
            return View("Index", await _tourService.GetAllAsync());
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
