using App.Domain.Core.Entities;
using App.Domain.Core.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.AppServices
{
    public interface ICarModelAppServices
    {
        public Task<List<Model>> CarModels(CancellationToken cancellationToken);
        public Task<Resultt> CreateModel(Model model, CancellationToken cancellationToken);
        public Task<Model> GetModelById(int id, CancellationToken cancellationToken);
        public Task<bool> DeleteModel(int id, CancellationToken cancellationToken);
        public Task<Resultt> UpdateModel(Model model, CancellationToken cancellationToken);
    }
}
