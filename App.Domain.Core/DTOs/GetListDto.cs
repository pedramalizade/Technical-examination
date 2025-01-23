using App.Domain.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DTOs
{
    public class GetListDto
    {
        public int Id { get; set; }
        public DateTime TechnicalInspection { get; set; }
        public string ModelName { get; set; }
        public UserBrandCarEnum BrandCar { get; set; }
        public string LicensePlateCar { get; set; }
        public int YearOfProduction { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public UserStatusCarEnum Status { get; set; } = UserStatusCarEnum.apending;
    }
}
