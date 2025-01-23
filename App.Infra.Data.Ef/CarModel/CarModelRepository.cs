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
        public List<Model> CarModels()
        {
            return _appDbContext.Models.AsNoTracking().ToList();
        }

        public bool CreateModel(Model model)
        {
            _appDbContext.Models.Add(model);
            _appDbContext.SaveChanges();
            return true;
        }

        public bool DeleteModel(int id)
        {
            var model = _appDbContext.Models.FirstOrDefault(x => x.Id == id);
            _appDbContext.Models.Remove(model);
            _appDbContext.SaveChanges();
            return true;
        }

        public bool GetCModel(string modelTitle)
        {
            return _appDbContext.Models.AsNoTracking().Any(t => t.Title == modelTitle);
        }

        public Model GetModelById(int id)
        {
            return _appDbContext.Models.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public bool UpdateModel(Model model)
        {
            var model1 = _appDbContext.Models.FirstOrDefault(x => x.Id == model.Id);
            model1.Id = model.Id;
            model1.Title = model.Title;
            _appDbContext.SaveChanges();
            return true;
        }
    }
}
