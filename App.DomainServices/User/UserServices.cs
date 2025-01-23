using App.Domain.Core.Data.Repository;
using App.Domain.Core.Entities;
using App.Domain.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DomainServices.User
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _UserRepository;

        public UserServices(IUserRepository userRepository)
        {
            _UserRepository = userRepository;
        }
        public bool CreateLogUserCar(LogTable logUserCar)
        {
            return _UserRepository.CreateLogUserCar(logUserCar);
        }

        public bool CreateUserCar(UserCar userCar)
        {
            return _UserRepository.CreateUserCar(userCar);
        }

        public UserCar GetByLicensePlateCar(string licensePlateCarId)
        {
            return _UserRepository.GetByLicensePlateCar(licensePlateCarId);
        }

        public bool GetStatus(string licensePlateCarId)
        {
            return _UserRepository.GetStatus(licensePlateCarId);
        }
    }
}
