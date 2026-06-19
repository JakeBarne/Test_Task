using NHibernate;

namespace TestTask.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ISessionFactory _sessionFactory;

        public Repository(ISessionFactory sessionFactory)
            => _sessionFactory = sessionFactory;

        public IList<T> GetAll()
        {
            using var session = _sessionFactory.OpenSession();
            return session.Query<T>().ToList();
        }

        public void Save(T entity)
        {
            using var session = _sessionFactory.OpenSession();
            using var tx = session.BeginTransaction();
            session.Save(entity);
            tx.Commit();
        }

        public void Update(T entity)
        {
            using var session = _sessionFactory.OpenSession();
            using var tx = session.BeginTransaction();
            session.Merge(entity);
            tx.Commit();
        }

        public void Delete(T entity)
        {
            using var session = _sessionFactory.OpenSession();
            using var tx = session.BeginTransaction();
            session.Delete(session.Merge(entity));
            tx.Commit();
        }
    }
}
