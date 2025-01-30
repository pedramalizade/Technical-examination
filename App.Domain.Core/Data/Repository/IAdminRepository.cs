using App.Domain.Core.DTOs;
using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Data.Repository
{
    public interface IAdminRepository
    {
        public Admin Login(string username, string password);
        public List<GetListDto> GetList();
        public CarOfUser GetById(int id);
        public bool Confirmation(int id);
        public bool Rejected(int id);
    }
}
