using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ISetupRepository
    {
        Task<Configuration?> GetByParam(Expression<Func<Domain.Entities.Configuration, bool>> obj);

    }
}
