using App.Domain.Core.Entities;

namespace App.EndPoint.MVC.Models
{
    public class UserCarViewModel
    {
        public UserCar CarModel { get; set; }
        public List<Model>? Models { get; set; }
    }
}
