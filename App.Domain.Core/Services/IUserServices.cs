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
        public Task<CarOfUser> GetByLicensePlateCar(string licensePlateCarId, CancellationToken cancellationToken);
        public Task<bool> CreateUserCar(CarOfUser carOfUser, CancellationToken cancellationToken);
        public Task<bool> GetStatus(string licensePlateCarId, CancellationToken cancellationToken);
        public Task<bool> CreateLogUserCar(LogTable logUserCar, CancellationToken cancellationToken);
    }
}
