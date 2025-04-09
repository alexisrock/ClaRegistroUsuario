using System.Linq.Expressions;


namespace Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {



        Task<List<T>> GetAll();
        Task<T?> GetById(object id);
        Task Insert(T obj);
        Task InsertRange(T[] obj);
        Task Update(T obj);
        Task Delete(object id);
        Task DeleteRange(T[] obj);
        Task Save();
        Task<T?> GetByParam(Expression<Func<T, bool>> obj);
        Task<List<T>> GetListByParam(Expression<Func<T, bool>> obj);
        Task<List<T>> GetAllByParamIncluding(Expression<Func<T, bool>> obj, params Expression<Func<T, object>>[] includeProperties);

    }
}
