using App.Domain.Core.Data.Repository;
using App.Domain.Core.DTOs;
using App.Domain.Core.Entities;
using App.Domain.Core.Enums;
using App.Infra.Data.SqlServer.Ef.ApplicationDBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Ef.OPrator
{
    public class AdminRepository : IAdminRepository
    {
        private readonly AppDbContext _appDbContext;

        public AdminRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<bool> Confirmation(int id, CancellationToken cancellationToken)
        {
            var car = await _appDbContext.CarOfUsers.Where(x => x.Id == id).FirstOrDefaultAsync();
            car.Status = UserStatusCarEnum.aproved;
            _appDbContext.SaveChanges();
            return true;
        }

        public async Task<CarOfUser> GetById(int id, CancellationToken cancellationToken)
        {
            return await _appDbContext.CarOfUsers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<GetListDto>> GetList(CancellationToken cancellationToken)
        {
            return await _appDbContext.CarOfUsers.AsNoTracking().OrderBy(x => x.TechnicalInspection)
                           .Select(x => new GetListDto()
                           {
                               Id = x.Id,
                               TechnicalInspection = x.TechnicalInspection,
                               ModelName = x.Model.Title,
                               BrandCar = x.BrandCar,
                               LicensePlateCar = x.LicensePlateCar,
                               YearOfProduction = x.YearOfProduction,
                               FirstName = x.FirstName,
                               LastName = x.LastName,
                               NationalCode = x.NationalCode,
                               Mobile = x.Mobile,
                               Address = x.Address,
                               Status = x.Status

                           }).ToListAsync();
        }

        public async Task<Admin> Login(string username, string password, CancellationToken cancellationToken)
        {
            return await _appDbContext.Admins.AsNoTracking().FirstOrDefaultAsync(x => x.UserName == username && x.Password == password);
        }

        public async Task<bool> Rejected(int id, CancellationToken cancellationToken)
        {
            var car = await _appDbContext.CarOfUsers.Where(x => x.Id == id).FirstOrDefaultAsync();
            car.Status = UserStatusCarEnum.Rejected;
            _appDbContext.SaveChanges();
            return true;
        }
    }
}
