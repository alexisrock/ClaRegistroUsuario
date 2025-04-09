

using System.Linq.Expressions;
using Domain.Interfaces;

namespace Infrastructure.Persistence
{
    public class SetupRepository: ISetupRepository
    {

        private readonly IRepository<Domain.Entities.Configuration> repository;

        public SetupRepository(IRepository<Domain.Entities.Configuration> repository)
        {
            this.repository = repository;
        }

        public async Task<Domain.Entities.Configuration?> GetByParam(Expression<Func<Domain.Entities.Configuration, bool>> obj)
        {
            return await repository.GetByParam(obj);
        }
    }
}
