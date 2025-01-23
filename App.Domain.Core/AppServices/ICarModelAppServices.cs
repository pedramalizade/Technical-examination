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
        public List<Model> CarModels();
        public Resultt CreateModel(Model model);
        public Model GetModelById(int id);
        public bool DeleteModel(int id);
        public Resultt UpdateModel(Model model);
    }
}
