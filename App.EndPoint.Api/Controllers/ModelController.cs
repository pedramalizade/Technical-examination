using App.Domain.Core.AppServices;
using App.Domain.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;

namespace App.EndPoints.Api.Car.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ModelController : ControllerBase
    {
        private readonly ICarModelAppServices _CarModelAppServices;



        public ModelController(ICarModelAppServices carModelAppServices)
        {
            _CarModelAppServices = carModelAppServices;

        }
        [HttpGet("[action]")]
        public async Task<List<Model>> GetAll(CancellationToken cancellationToken)
        {
            List<Model> models = await _CarModelAppServices.CarModels(cancellationToken);
            return models;

        }
        [HttpGet("[action]")]
        public async Task<Model> GetById(int id, CancellationToken cancellationToken)
        {
            Model model = await _CarModelAppServices.GetModelById(id, cancellationToken);
            return model;

        }
        [HttpPost("[action]")]
        public async Task<string> Create(Model model, CancellationToken cancellationToken)
        {
            var result = await _CarModelAppServices.CreateModel(model, cancellationToken);
            if (result.IsSuccess)
            {

                return result.IsMessage;


            }
            else
            {
                return result.IsMessage;

            }
        }

        [HttpPost("[action]")]
        public async Task<string> Update(Model model, CancellationToken cancellationToken)
        {
            var result = await _CarModelAppServices.UpdateModel(model, cancellationToken);
            if (result.IsSuccess)
            {
                return result.IsMessage;

            }
            else
            {
                return result.IsMessage;

            }
        }

        [HttpDelete("[action]")]
        public async Task<bool> Delete(int id, CancellationToken cancellationToken)
        {
          await  _CarModelAppServices.DeleteModel(id, cancellationToken);

            return true;
        }
    }
}
