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
        private readonly SiteSettings _SiteSettings;


        public UserAppServices(IUserServices userServices, SiteSettings siteSettings)
        {
            _UserServices = userServices;
            _SiteSettings = siteSettings;
        }
        public Resultt CreateUserCar(UserCar userCar)
        {
            if (_UserServices.GetByLicensePlateCar(userCar.LicensePlateCar) != null && _UserServices.GetStatus(userCar.LicensePlateCar) && userCar.TechnicalInspection.AddDays(365) >= DateTime.Now)
            {
                return new Resultt(false, "خودرو شما کمتر از یکسال،معاینه فنی رو دریافت کرده است.");
            }
            if (userCar.YearOfProduction + 5 < DateTime.Now.Year)
            {
                var log = new LogTable()
                {
                    Id = userCar.Id,
                    FirstName = userCar.FirstName,
                    LastName = userCar.LastName,
                    NationalCode = userCar.NationalCode,
                    Mobile = userCar.Mobile,
                    LicensePlateCar = userCar.LicensePlateCar,
                    YearOfProduction = userCar.YearOfProduction,
                    Address = userCar.Address,
                    TechnicalInspection = userCar.TechnicalInspection,
                    BrandCar = userCar.BrandCar,
                    ModelId = userCar.ModelId,
                    Status = userCar.Status,
                    LoggedAt = DateTime.Now

                };
                _UserServices.CreateLogUserCar(log);
                return new Resultt(false, "سال تولید خودرو شما بیش از 5 سال است.");

            }
            if (userCar.TechnicalInspection.Day % 2 == 0 && userCar.BrandCar != UserBrandCarEnum.IranKhodro)
            {
                return new Resultt(false, "در روزهای زوج فقط ایران خودرو رزرو دارد");
            }
            if (userCar.TechnicalInspection.Day % 2 != 0 && userCar.BrandCar != UserBrandCarEnum.Saipa)
            {
                return new Resultt(false, "در روزهای فرد فقط سایپا رزرو دارد");
            }
            if (userCar.TechnicalInspection.Day % 2 == 0 && MemoryDb.EvenDayRequests >= _SiteSettings.Limitation.Irankhodro)
            {
                return new Resultt(false, "ظرفیت ایران خودرو به پایان رسیده است.");
            }
            if (userCar.TechnicalInspection.Day % 2 != 0 && MemoryDb.OddDayRequests >= _SiteSettings.Limitation.Saipa)
            {
                return new Resultt(false, "ظرفیت سایپا به پایان رسیده است.");
            }
            else
            {
                var usercar1 = new UserCar()
                {
                    Id = userCar.Id,
                    FirstName = userCar.FirstName,
                    LastName = userCar.LastName,
                    NationalCode = userCar.NationalCode,
                    Mobile = userCar.Mobile,
                    LicensePlateCar = userCar.LicensePlateCar,
                    YearOfProduction = userCar.YearOfProduction,
                    Address = userCar.Address,
                    TechnicalInspection = userCar.TechnicalInspection,
                    BrandCar = userCar.BrandCar,
                    ModelId = userCar.ModelId,
                    Status = userCar.Status

                };
                _UserServices.CreateUserCar(usercar1);
                if (userCar.TechnicalInspection.Day % 2 == 0)
                {
                    MemoryDb.EvenDayRequests++;
                }
                else if (userCar.TechnicalInspection.Day % 2 != 0)
                {
                    MemoryDb.OddDayRequests++;
                }
                return new Resultt(true, "تاریخ معاینه فنی خودرو شما با موفقیت ثبت شد.");
            }
        }
    }
}
