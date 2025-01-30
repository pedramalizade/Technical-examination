using App.Domain.Core.AppServices;
using App.Domain.Core.Entities;
using App.EndPoint.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace App.EndPoints.Mvc.Car.Controllers
{
    public class UserCarController : Controller
    {
        private readonly IUserAppServices _UserAppServices;
        private readonly ICarModelAppServices _CarModelAppServices;
        public UserCarController(IUserAppServices userAppServices, ICarModelAppServices carModelAppServices)
        {
            _UserAppServices = userAppServices;
            _CarModelAppServices = carModelAppServices;
        }


        [HttpGet]
        public async Task<IActionResult> Create(CancellationToken cToken)
        {
            var models = await _CarModelAppServices.CarModels(cToken);


            var viewModel = new UserCarViewModel
            {
                CarModel = new CarOfUser(),
                Models = models
            };

            return View(viewModel);


        }
        [HttpPost]
        public async Task<IActionResult> Create(UserCarViewModel model, CancellationToken cToken)
        {


            if (ModelState.IsValid)
            {

                var result = await _UserAppServices.CreateUserCar(model.CarModel, cToken);
                if (result.IsSuccess)
                {
                    ViewBag.SuccessMessage = result.IsMessage;

                }
                else
                {
                    ViewBag.ErrorMessage = result.IsMessage;
                }


            }



            var models = await _CarModelAppServices.CarModels(cToken);
            var viewModel = new UserCarViewModel
            {
                CarModel = new CarOfUser(),
                Models = models
            };

            return View(viewModel);

        }

    }
}