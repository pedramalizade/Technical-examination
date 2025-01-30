using App.Domain.Core.DTOs;
using App.Domain.Core.Entities;
using App.Domain.Core.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.AppServices
{
    public interface IAdminAppServices
    {
        public Task<Resultt> Login(string username, string password, CancellationToken cancellationToken);
        public Task<List<GetListDto>> GetList(CancellationToken cancellationToken);
        public Task<CarOfUser> GetById(int id, CancellationToken cancellationToken);
        public Task<Resultt> Confirmation(int id, CancellationToken cancellationToken);
        public Task<Resultt> Rejected(int id, CancellationToken cancellationToken);
    }
}
