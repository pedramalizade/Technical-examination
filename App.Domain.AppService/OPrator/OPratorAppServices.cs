using App.Domain.Core.AppServices;
using App.Domain.Core.DTOs;
using App.Domain.Core.Entities;
using App.Domain.Core.Result;
using App.Domain.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppService.OPrator
{
    public class OPratorAppServices : IOPratorAppServices
    {
        private readonly IOPratorServices _OPratorServices;

        public OPratorAppServices(IOPratorServices oPratorServices)
        {
            _OPratorServices = oPratorServices;
        }
        public Resultt Confirmation(int id)
        {
            _OPratorServices.Confirmation(id);
            return new Resultt(true, "تایید شد.");
        }

        public UserCar GetById(int id)
        {
            return _OPratorServices.GetById(id);
        }

        public List<GetListDto> GetList()
        {
            return _OPratorServices.GetList();
        }

        public Resultt Login(string username, string password)
        {
            if (_OPratorServices.Login(username, password) == null)
            {
                return new Resultt(false, "نام کاربری یا رمز عبور اشتباه است.");
            }
            else
            {
                _OPratorServices.Login(username, password);
                return new Resultt(true, "خوش آمدید.");
            }
        }

        public Resultt Rejected(int id)
        {
            _OPratorServices.Rejected(id);
            return new Resultt(true, "رد شد.");
        }
    }
}
