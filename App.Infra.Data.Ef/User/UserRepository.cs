using App.Domain.Core.Data.Repository;
using App.Domain.Core.Entities;
using App.Domain.Core.Enums;
using App.Infra.Data.SqlServer.Ef.ApplicationDBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Ef.User
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;
        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public bool CreateLogUserCar(LogTable logUserCar)
        {
            _appDbContext.LogTables.Add(logUserCar);
            _appDbContext.SaveChanges();
            return true;
        }

        public bool CreateUserCar(UserCar userCar)
        {
            _appDbContext.UserCars.Add(userCar);
            _appDbContext.SaveChanges();
            return true;
        }

        public UserCar GetByLicensePlateCar(string licensePlateCarId)
        {
            return _appDbContext.UserCars.AsNoTracking().FirstOrDefault(x => x.LicensePlateCar == licensePlateCarId);
        }

        public bool GetStatus(string licensePlateCarId)
        {
            return _appDbContext.UserCars.AsNoTracking().Any(x => x.LicensePlateCar == licensePlateCarId && x.Status == UserStatusCarEnum.aproved);
        }
    }
}
