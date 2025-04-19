using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IUsuarioRepository
    {
      Task Create(Users objeto);
      Task<Users?> GetByParam(Expression<Func<Domain.Entities.Users, bool>> obj);

    }
}
