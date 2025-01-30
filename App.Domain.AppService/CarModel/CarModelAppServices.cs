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
        public async Task<List<Model>> CarModels(CancellationToken cancellationToken)
        {
            return await _CarModelServices.CarModels(cancellationToken);
        }

        public async Task<Resultt> CreateModel(Model model, CancellationToken cancellationToken)
        {
            if (await _CarModelServices.GetCModel(model.Title, cancellationToken))
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
                await _CarModelServices.CreateModel(model1, cancellationToken);
                return new Resultt(true, "مدل خودرو با موفقیت اضافه شد.");
            }
        }

        public async Task<bool> DeleteModel(int id, CancellationToken cancellationToken)
        {
            return await _CarModelServices.DeleteModel(id, cancellationToken);
        }

        public async Task<Model> GetModelById(int id, CancellationToken cancellationToken)
        {
            return await _CarModelServices.GetModelById(id, cancellationToken);
        }

        public async Task<Resultt> UpdateModel(Model model, CancellationToken cancellationToken)
        {
            if (await _CarModelServices.GetCModel(model.Title, cancellationToken))
            {
                return new Resultt(false, "مدل خودرو موجود می باشد.");

            }

            else
            {
               await _CarModelServices.UpdateModel(model, cancellationToken);
                return new Resultt(true, "ویرایش با موفقیت انجام شد.");
            }
        }
    }
}
