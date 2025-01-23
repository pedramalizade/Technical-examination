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
    public class OPratorRepository : IOPratorRepository
    {
        private readonly AppDbContext _appDbContext;

        public OPratorRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public bool Confirmation(int id)
        {
            var car = _appDbContext.UserCars.Where(x => x.Id == id).FirstOrDefault();
            car.Status = UserStatusCarEnum.aproved;
            _appDbContext.SaveChanges();
            return true;
        }

        public UserCar GetById(int id)
        {
            return _appDbContext.UserCars.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public List<GetListDto> GetList()
        {
            return _appDbContext.UserCars.AsNoTracking().OrderBy(x => x.TechnicalInspection)
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

                           }).ToList();
        }

        public OperatorCar Login(string username, string password)
        {
            return _appDbContext.OperatorCars.AsNoTracking().FirstOrDefault(x => x.UserName == username && x.Password == password);
        }

        public bool Rejected(int id)
        {
            var car = _appDbContext.UserCars.Where(x => x.Id == id).FirstOrDefault();
            car.Status = UserStatusCarEnum.Rejected;
            _appDbContext.SaveChanges();
            return true;
        }
    }
}
