using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Services
{
    public interface IUserServices
    {
        public UserCar GetByLicensePlateCar(string licensePlateCarId);
        public bool CreateUserCar(UserCar userCar);
        public bool GetStatus(string licensePlateCarId);
        public bool CreateLogUserCar(LogTable logUserCar);
    }
}
