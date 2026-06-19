using System.Collections.Generic;

namespace TestTask.Infrastructure.Repository
{
    public interface IRepository<T> where T : class
    {
        IList<T> GetAll();
        void Save(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
