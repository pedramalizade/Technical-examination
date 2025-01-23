using App.Domain.Core.AppServices;
using App.Domain.Core.Entities;
using App.Domain.Core.Result;
using App.Domain.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppService.CarModel
{
    public class CarModelAppServices : ICarModelAppServices
    {
        private readonly ICarModelServices _CarModelServices;

        public CarModelAppServices(ICarModelServices carModelServices)
        {
            _CarModelServices = carModelServices;
        }
        public List<Model> CarModels()
        {
            return _CarModelServices.CarModels();
        }

        public Resultt CreateModel(Model model)
        {
            if (_CarModelServices.GetCModel(model.Title))
            {
                return new Resultt(false, "مدل خودرو موجود می باشد.");

            }

            else
            {
                var model1 = new Model
                {
                    Id = model.Id,
                    Title = model.Title,

                };
                _CarModelServices.CreateModel(model1);
                return new Resultt(true, "مدل خودرو با موفقیت اضافه شد.");
            }
        }

        public bool DeleteModel(int id)
        {
            return _CarModelServices.DeleteModel(id);
        }

        public Model GetModelById(int id)
        {
            return _CarModelServices.GetModelById(id);
        }

        public Resultt UpdateModel(Model model)
        {
            if (_CarModelServices.GetCModel(model.Title))
            {
                return new Resultt(false, "مدل خودرو موجود می باشد.");

            }

            else
            {
                _CarModelServices.UpdateModel(model);
                return new Resultt(true, "ویرایش با موفقیت انجام شد.");
            }
        }
    }
}
