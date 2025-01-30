using App.Domain.Core.Data.Repository;
using App.Domain.Core.DTOs;
using App.Domain.Core.Entities;
using App.Domain.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DomainServices.OPrator
{
    public class AdminServices : IAdminServices
    {
        private readonly IAdminRepository _OPratorRepository;

        public AdminServices(IAdminRepository oPratorRepository)
        {
            _OPratorRepository = oPratorRepository;
        }
        public bool Confirmation(int id)
        {
            return _OPratorRepository.Confirmation(id);
        }

        public CarOfUser GetById(int id)
        {
            return _OPratorRepository.GetById(id);
        }

        public List<GetListDto> GetList()
        {
            return _OPratorRepository.GetList();
        }

        public Admin Login(string username, string password)
        {
            return _OPratorRepository.Login(username, password);
        }

        public bool Rejected(int id)
        {
            return _OPratorRepository.Rejected(id);
        }
    }
}
