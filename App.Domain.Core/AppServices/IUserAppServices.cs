using App.Domain.Core.Entities;
using App.Domain.Core.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.AppServices
{
    public interface IUserAppServices
    {
        public Task<Resultt> CreateUserCar(CarOfUser carOfUser, CancellationToken cancellationToken);

    }
}
