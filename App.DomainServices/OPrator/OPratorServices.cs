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
    public class OPratorServices : IOPratorServices
    {
        private readonly IOPratorRepository _OPratorRepository;

        public OPratorServices(IOPratorRepository oPratorRepository)
        {
            _OPratorRepository = oPratorRepository;
        }
        public bool Confirmation(int id)
        {
            return _OPratorRepository.Confirmation(id);
        }

        public UserCar GetById(int id)
        {
            return _OPratorRepository.GetById(id);
        }

        public List<GetListDto> GetList()
        {
            return _OPratorRepository.GetList();
        }

        public OperatorCar Login(string username, string password)
        {
            return _OPratorRepository.Login(username, password);
        }

        public bool Rejected(int id)
        {
            return _OPratorRepository.Rejected(id);
        }
    }
}
