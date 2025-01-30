using App.Domain.Core.AppServices;
using App.Domain.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System;

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
        public List<Model> GetAll()
        {
            List<Model> models = _CarModelAppServices.CarModels();
            return models;

        }
        [HttpGet("[action]")]
        public Model GetById(int id)
        {
            Model model = _CarModelAppServices.GetModelById(id);
            return model;

        }
        [HttpPost("[action]")]
        public string Create(Model model)
        {
            var result = _CarModelAppServices.CreateModel(model);
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
        public string Update(Model model)
        {
            var result = _CarModelAppServices.UpdateModel(model);
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
        public bool Delete(int id)
        {
            _CarModelAppServices.DeleteModel(id);

            return true;
        }
    }
}
