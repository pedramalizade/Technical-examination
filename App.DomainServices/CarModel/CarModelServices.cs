using App.Domain.Core.Data.Repository;
using App.Domain.Core.Entities;
using App.Domain.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DomainServices.CarModel
{
    public class CarModelServices : ICarModelServices
    {
        ICarModelRepository _CarModelRepository;

        public CarModelServices(ICarModelRepository carModelRepository)
        {
            _CarModelRepository = carModelRepository;
        }
        public List<Model> CarModels()
        {
            return _CarModelRepository.CarModels();
        }

        public bool CreateModel(Model model)
        {
            return _CarModelRepository.CreateModel(model);
        }

        public bool DeleteModel(int id)
        {
            return _CarModelRepository.DeleteModel(id);
        }

        public bool GetCModel(string modelTitle)
        {
            return _CarModelRepository.GetCModel(modelTitle);
        }

        public Model GetModelById(int id)
        {
            return _CarModelRepository.GetModelById(id);
        }

        public bool UpdateModel(Model model)
        {
            return _CarModelRepository.UpdateModel(model);
        }
    }
}
