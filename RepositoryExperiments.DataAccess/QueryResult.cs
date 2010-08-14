using System.Collections.Generic;
using NHibernate;

namespace RepositoryExperiments.DataAccess
{
    public class QueryResult<T> : IQueryResult<T>
    {
        private readonly IQuery query;

        public QueryResult(IQuery query)
        {
            this.query = query;
        }

        public T UniqueResult()
        {
            return query.UniqueResult<T>();
        }

        public IEnumerable<T> List()
        {
            return query.List<T>();
        }
    }
}