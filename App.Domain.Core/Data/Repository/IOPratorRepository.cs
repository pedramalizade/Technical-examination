using App.Domain.Core.DTOs;
using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Data.Repository
{
    public interface IOPratorRepository
    {
        public OperatorCar Login(string username, string password);
        public List<GetListDto> GetList();
        public UserCar GetById(int id);
        public bool Confirmation(int id);
        public bool Rejected(int id);
    }
}
