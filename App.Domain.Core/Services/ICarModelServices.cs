using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Services
{
    public interface ICarModelServices
    {
        public List<Model> CarModels();
        public bool CreateModel(Model model);
        public Model GetModelById(int id);
        public bool DeleteModel(int id);
        public bool UpdateModel(Model model);
        public bool GetCModel(string modelTitle);
    }
}
