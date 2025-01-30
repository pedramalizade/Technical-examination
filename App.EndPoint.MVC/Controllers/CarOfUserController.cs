using App.Domain.Core.AppServices;
using App.Domain.Core.Entities;
using App.EndPoint.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoint.MVC.Controllers
{
    public class CarOfUserController : Controller
    {
        private readonly IUserAppServices _UserAppServices;
        private readonly ICarModelAppServices _CarModelAppServices;
        public CarOfUserController(IUserAppServices userAppServices, ICarModelAppServices carModelAppServices)
        {
            _UserAppServices = userAppServices;
            _CarModelAppServices = carModelAppServices;
        }


        [HttpGet]
        public IActionResult Create()
        {
            var models = _CarModelAppServices.CarModels();


            var viewModel = new UserCarViewModel
            {
                CarModel = new CarOfUser(),
                Models = models
            };

            return View(viewModel);


        }
        [HttpPost]
        public IActionResult Create(UserCarViewModel model)
        {


            if (ModelState.IsValid)
            {

                var result = _UserAppServices.CreateUserCar(model.CarModel);
                if (result.IsSuccess)
                {
                    ViewBag.SuccessMessage = result.IsMessage;

                }
                else
                {
                    ViewBag.ErrorMessage = result.IsMessage;
                }


            }



            var models = _CarModelAppServices.CarModels();
            var viewModel = new UserCarViewModel
            {
                CarModel = new CarOfUser(),
                Models = models
            };

            return View(viewModel);

        }

    }
}
