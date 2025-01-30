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
        public async Task<bool> CreateLogUserCar(LogTable logUserCar, CancellationToken cancellationToken)
        {
            return await _UserRepository.CreateLogUserCar(logUserCar, cancellationToken);
        }

        public async Task<bool> CreateUserCar(CarOfUser carOfUser, CancellationToken cancellationToken)
        {
            return await _UserRepository.CreateUserCar(carOfUser, cancellationToken);
        }

        public async Task<CarOfUser> GetByLicensePlateCar(string licensePlateCarId, CancellationToken cancellationToken)
        {
            return await _UserRepository.GetByLicensePlateCar(licensePlateCarId, cancellationToken);
        }

        public async Task<bool> GetStatus(string licensePlateCarId, CancellationToken cancellationToken)
        {
            return await _UserRepository.GetStatus(licensePlateCarId, cancellationToken);
        }
    }
}
