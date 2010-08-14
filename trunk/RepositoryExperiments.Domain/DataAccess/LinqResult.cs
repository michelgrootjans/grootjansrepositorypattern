using System.Collections.Generic;
using System.Linq;

namespace RepositoryExperiments.Domain.DataAccess
{
    public class LinqResult<T> : IQueryResult<T>
    {
        private readonly IQueryable<T> query;

        public LinqResult(IQueryable<T> query)
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