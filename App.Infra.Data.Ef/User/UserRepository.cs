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
        public async Task<bool> CreateLogUserCar(LogTable logUserCar, CancellationToken cancellationToken)
        {
           await _appDbContext.LogTables.AddAsync(logUserCar);
            await _appDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CreateUserCar(CarOfUser userCar, CancellationToken cancellationToken)
        {
            await _appDbContext.CarOfUsers.AddAsync(userCar);
            await _appDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<CarOfUser> GetByLicensePlateCar(string licensePlateCarId, CancellationToken cancellationToken)
        {
            return await _appDbContext.CarOfUsers.AsNoTracking().FirstOrDefaultAsync(x => x.LicensePlateCar == licensePlateCarId);
        }

        public async Task<bool> GetStatus(string licensePlateCarId, CancellationToken cancellationToken)
        {
            return await _appDbContext.CarOfUsers.AsNoTracking().AnyAsync(x => x.LicensePlateCar == licensePlateCarId && x.Status == UserStatusCarEnum.aproved);
        }
    }
}
