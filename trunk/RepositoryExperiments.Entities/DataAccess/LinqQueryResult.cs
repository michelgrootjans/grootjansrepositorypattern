using System.Collections.Generic;
using System.Linq;

namespace RepositoryExperiments.Domain.DataAccess
{
    public class LinqQueryResult<T> : IQueryResult<T>
    {
        private readonly IQueryable<T> query;

        public LinqQueryResult(IQueryable<T> query)
        {
            this.query = query;
        }

        public T UniqueResult()
        {
            return query.First();
        }

        public IEnumerable<T> List()
        {
            return query;
        }
    }
}