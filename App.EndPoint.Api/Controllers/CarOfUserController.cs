using App.Domain.Core.AppServices;
using App.Domain.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

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
        public async Task<string> Create(CarOfUser model, CancellationToken cancellationToken)
        {

            var result =await _UserAppServices.CreateUserCar(model, cancellationToken);
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
