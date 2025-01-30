using App.Domain.Core.AppServices;
using App.Domain.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.Api.Car.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CarOfUserController : ControllerBase
    {
        private readonly IUserAppServices _UserAppServices;
        // private readonly ICarModelAppServices _CarModelAppServices;
        public CarOfUserController(IUserAppServices userAppServices)
        {
            _UserAppServices = userAppServices;
            // _CarModelAppServices = carModelAppServices;
        }
        [HttpPost("[action]")]
        public string Create(CarOfUser model)
        {

            var result = _UserAppServices.CreateUserCar(model);
            if (result.IsSuccess)
            {

                return result.IsMessage;


            }
            else
            {
                return result.IsMessage;

            }


        }
    }
}
