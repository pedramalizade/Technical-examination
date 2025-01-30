using App.Domain.Core.AppServices;
using App.Domain.Core.Confrig;
using App.Domain.Core.Entities;
using App.Domain.Core.Enums;
using App.Domain.Core.Result;
using App.Domain.Core.Services;
using App.Infra.Data.SqlServer.Ef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppService.User
{
    public class UserAppServices : IUserAppServices
    {
        private readonly IUserServices _UserServices;
        private readonly SettingsSite _SiteSettings;


        public UserAppServices(IUserServices userServices, SettingsSite siteSettings)
        {
            _UserServices = userServices;
            _SiteSettings = siteSettings;
        }
        public async Task<Resultt> CreateUserCar(CarOfUser carOfUser, CancellationToken cancellationToken)
        {
            if (await _UserServices.GetByLicensePlateCar(carOfUser.LicensePlateCar, cancellationToken) != null && await _UserServices.GetStatus(carOfUser.LicensePlateCar, cancellationToken) && carOfUser.TechnicalInspection.AddDays(365) >= DateTime.Now)
            {
                return new Resultt(false, "خودرو شما کمتر از یکسال،معاینه فنی رو دریافت کرده است.");
            }
            if (carOfUser.YearOfProduction + 5 < DateTime.Now.Year)
            {
                var log = new LogTable()
                {
                    Id = carOfUser.Id,
                    FirstName = carOfUser.FirstName,
                    LastName = carOfUser.LastName,
                    NationalCode = carOfUser.NationalCode,
                    Mobile = carOfUser.Mobile,
                    LicensePlateCar = carOfUser.LicensePlateCar,
                    YearOfProduction = carOfUser.YearOfProduction,
                    Address = carOfUser.Address,
                    TechnicalInspection = carOfUser.TechnicalInspection,
                    BrandCar = carOfUser.BrandCar,
                    ModelId = carOfUser.ModelId,
                    Status = carOfUser.Status,
                    LoggedAt = DateTime.Now

                };
                await _UserServices.CreateLogUserCar(log, cancellationToken);
                return new Resultt(false, "سال تولید خودرو شما بیش از 5 سال است.");

            }
            if (carOfUser.TechnicalInspection.Day % 2 == 0 && carOfUser.BrandCar != UserBrandCarEnum.IranKhodro)
            {
                return new Resultt(false, "در روزهای زوج فقط ایران خودرو رزرو دارد");
            }
            if (carOfUser.TechnicalInspection.Day % 2 != 0 && carOfUser.BrandCar != UserBrandCarEnum.Saipa)
            {
                return new Resultt(false, "در روزهای فرد فقط سایپا رزرو دارد");
            }
            if (carOfUser.TechnicalInspection.Day % 2 == 0 && MemoryDb.EvenDayRequests >= _SiteSettings.Limitation.Irankhodro)
            {
                return new Resultt(false, "ظرفیت ایران خودرو به پایان رسیده است.");
            }
            if (carOfUser.TechnicalInspection.Day % 2 != 0 && MemoryDb.OddDayRequests >= _SiteSettings.Limitation.Saipa)
            {
                return new Resultt(false, "ظرفیت سایپا به پایان رسیده است.");
            }
            else
            {
                var carOfUser1 = new CarOfUser()
                {
                    Id = carOfUser.Id,
                    FirstName = carOfUser.FirstName,
                    LastName = carOfUser.LastName,
                    NationalCode = carOfUser.NationalCode,
                    Mobile = carOfUser.Mobile,
                    LicensePlateCar = carOfUser.LicensePlateCar,
                    YearOfProduction = carOfUser.YearOfProduction,
                    Address = carOfUser.Address,
                    TechnicalInspection = carOfUser.TechnicalInspection,
                    BrandCar = carOfUser.BrandCar,
                    ModelId = carOfUser.ModelId,
                    Status = carOfUser.Status

                };
                await _UserServices.CreateUserCar(carOfUser1, cancellationToken);
                if (carOfUser.TechnicalInspection.Day % 2 == 0)
                {
                    MemoryDb.EvenDayRequests++;
                }
                else if (carOfUser.TechnicalInspection.Day % 2 != 0)
                {
                    MemoryDb.OddDayRequests++;
                }
                return new Resultt(true, "تاریخ معاینه فنی خودرو شما با موفقیت ثبت شد.");
            }
        }
    }
}
