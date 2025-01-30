using App.Domain.Core.Data.Repository;
using App.Domain.Core.Entities;
using App.Infra.Data.SqlServer.Ef.ApplicationDBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Ef.CarModel
{
    public class CarModelRepository : ICarModelRepository
    {
        private readonly AppDbContext _appDbContext;

        public CarModelRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<List<Model>> CarModels(CancellationToken cancellationToken)
        {
            return await _appDbContext.Models.AsNoTracking().ToListAsync();
        }

        public async Task<bool> CreateModel(Model model, CancellationToken cancellationToken)
        {
            await _appDbContext.Models.AddAsync(model);
            await _appDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteModel(int id, CancellationToken cancellationToken)
        {
            var model = await _appDbContext.Models.FirstOrDefaultAsync(x => x.Id == id);
            _appDbContext.Models.Remove(model);
            _appDbContext.SaveChanges();
            return true;
        }

        public async Task<bool> GetCModel(string modelTitle, CancellationToken cancellationToken)
        {
            return await _appDbContext.Models.AsNoTracking().AnyAsync(t => t.Title == modelTitle);
        }

        public async Task<Model> GetModelById(int id, CancellationToken cancellationToken)
        {
            return await _appDbContext.Models.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> UpdateModel(Model model, CancellationToken cancellationToken)
        {
            var model1 = await _appDbContext.Models.FirstOrDefaultAsync(x => x.Id == model.Id);
            model1.Id = model.Id;
            model1.Title = model.Title;
            _appDbContext.SaveChanges();
            return true;
        }
    }
}
