using NHibernate;
using RepositoryExperiments.Domain.DataAccess;

namespace RepositoryExperiments.Domain.Queries
{
    public class GetAll<T> : IQuery<T> where T : class
    {
        public IQueryResult<T> Execute(ISession session)
        {
            return new CriteriaResult<T>(session.CreateCriteria<T>());
        }
    }
}