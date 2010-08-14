using NHibernate;

namespace RepositoryExperiments.Domain.DataAccess
{
    public class NHibernateRepository : IRepository
    {
        public void Add<T>(T entity)
        {
            CurrentSession.Save(entity);
        }

        public void Remove<T>(T entity)
        {
            CurrentSession.Delete(entity);
        }

        public IQueryResult<T> Query<T>(IQuery<T> query)
        {
            return query.Execute(CurrentSession);
        }

        private static ISession CurrentSession
        {
            get { return NHibernateHelper.GetCurrentSession(); }
        }
    }
}