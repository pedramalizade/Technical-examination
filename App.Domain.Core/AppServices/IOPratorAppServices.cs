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
    public interface IOPratorAppServices
    {
        public Resultt Login(string username, string password);
        public List<GetListDto> GetList();
        public UserCar GetById(int id);
        public Resultt Confirmation(int id);
        public Resultt Rejected(int id);
    }
}
