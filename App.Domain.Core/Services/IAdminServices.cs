using App.Domain.Core.DTOs;
using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Services
{
    public interface IAdminServices
    {
        public Task<Admin> Login(string username, string password, CancellationToken cancellationToken);
        public Task<List<GetListDto>> GetList(CancellationToken cancellationToken);
        public Task<CarOfUser> GetById(int id, CancellationToken cancellationToken);
        public Task<bool> Confirmation(int id, CancellationToken cancellationToken);
        public Task<bool> Rejected(int id, CancellationToken cancellationToken);
    }
}
