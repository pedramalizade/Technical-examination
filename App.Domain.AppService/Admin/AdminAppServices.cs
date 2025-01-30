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
    public class AdminAppServices : IAdminAppServices
    {
        private readonly IAdminServices _OPratorServices;

        public AdminAppServices(IAdminServices oPratorServices)
        {
            _OPratorServices = oPratorServices;
        }
        public async Task<Resultt> Confirmation(int id, CancellationToken cancellationToken)
        {
           await _OPratorServices.Confirmation(id, cancellationToken);
            return new Resultt(true, "تایید شد.");
        }

        public async Task<CarOfUser> GetById(int id, CancellationToken cancellationToken)
        {
            return await _OPratorServices.GetById(id, cancellationToken);
        }

        public async Task<List<GetListDto>> GetList(CancellationToken cancellationToken)
        {
            return await _OPratorServices.GetList(cancellationToken);
        }

        public async Task<Resultt> Login(string username, string password, CancellationToken cancellationToken)
        {
            if (await _OPratorServices.Login(username, password, cancellationToken) == null)
            {
                return new Resultt(false, "نام کاربری یا رمز عبور اشتباه است.");
            }
            else
            {
                await _OPratorServices.Login(username, password, cancellationToken);
                return new Resultt(true, "خوش آمدید.");
            }
        }

        public async Task<Resultt> Rejected(int id, CancellationToken cancellationToken)
        {
            await _OPratorServices.Rejected(id, cancellationToken);
            return new Resultt(true, "رد شد.");
        }
    }
}
