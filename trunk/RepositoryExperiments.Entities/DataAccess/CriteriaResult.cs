using System.Collections.Generic;
using NHibernate;

namespace RepositoryExperiments.Domain.DataAccess
{
    public class CriteriaResult<T> : IQueryResult<T>
    {
        private readonly ICriteria criteria;

        public CriteriaResult(ICriteria criteria)
        {
            this.criteria = criteria;
        }

        public T UniqueResult()
        {
            return criteria.UniqueResult<T>();
        }

        public IEnumerable<T> List()
        {
            return criteria.List<T>();
        }
    }
}