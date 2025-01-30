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
        public async Task<bool> Confirmation(int id, CancellationToken cancellationToken)
        {
            return await _OPratorRepository.Confirmation(id,cancellationToken);
        }

        public async Task<CarOfUser> GetById(int id, CancellationToken cancellationToken)
        {
            return await _OPratorRepository.GetById(id, cancellationToken);
        }

        public async Task<List<GetListDto>> GetList(CancellationToken cancellationToken)
        {
            return await _OPratorRepository.GetList(cancellationToken);
        }

        public async Task<Admin> Login(string username, string password, CancellationToken cancellationToken)
        {
            return await _OPratorRepository.Login(username, password, cancellationToken);
        }

        public async Task<bool> Rejected(int id, CancellationToken cancellationToken)
        {
            return await _OPratorRepository.Rejected(id, cancellationToken);
        }
    }
}
