using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Data.Repository
{
    public interface ICarModelRepository
    {
        public Task<List<Model>> CarModels(CancellationToken cancellationToken);
        public Task<bool> CreateModel(Model model, CancellationToken cancellationToken);
        public Task<Model> GetModelById(int id, CancellationToken cancellationToken);
        public Task<bool> DeleteModel(int id, CancellationToken cancellationToken);
        public Task<bool> UpdateModel(Model model, CancellationToken cancellationToken);
        public Task<bool> GetCModel(string modelTitle, CancellationToken cancellationToken);
    }
}
