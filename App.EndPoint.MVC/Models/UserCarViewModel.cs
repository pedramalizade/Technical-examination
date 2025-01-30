using App.Domain.Core.Entities;

namespace App.EndPoint.MVC.Models
{
    public class UserCarViewModel
    {
        public CarOfUser CarModel { get; set; }
        public List<Model>? Models { get; set; }
    }
}
