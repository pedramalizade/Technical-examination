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
        public async Task<List<Model>> CarModels(CancellationToken cancellationToken)
        {
            return await _CarModelRepository.CarModels(cancellationToken);
        }

        public async Task<bool> CreateModel(Model model, CancellationToken cancellationToken)
        {
            return await _CarModelRepository.CreateModel(model, cancellationToken);
        }

        public async Task<bool> DeleteModel(int id, CancellationToken cancellationToken)
        {
            return await _CarModelRepository.DeleteModel(id, cancellationToken);
        }

        public async Task<bool> GetCModel(string modelTitle, CancellationToken cancellationToken)
        {
            return await _CarModelRepository.GetCModel(modelTitle, cancellationToken);
        }

        public async Task<Model> GetModelById(int id, CancellationToken cancellationToken)
        {
            return await _CarModelRepository.GetModelById(id, cancellationToken);
        }

        public async Task<bool> UpdateModel(Model model, CancellationToken cancellationToken)
        {
            return await _CarModelRepository.UpdateModel(model, cancellationToken);
        }
    }
}
