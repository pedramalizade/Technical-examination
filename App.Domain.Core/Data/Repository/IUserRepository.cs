using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Data.Repository
{
    public interface IUserRepository
    {
        public CarOfUser GetByLicensePlateCar(string licensePlateCarId);
        public bool GetStatus(string licensePlateCarId);
        public bool CreateUserCar(CarOfUser carOfUser);
        public bool CreateLogUserCar(LogTable logUserCar);
    }
}
