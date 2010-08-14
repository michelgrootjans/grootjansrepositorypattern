using System.Linq;
using NHibernate;
using NHibernate.Linq;
using RepositoryExperiments.Domain.DataAccess;
using RepositoryExperiments.Domain.Entities;

namespace RepositoryExperiments.Domain.Queries
{
    public class GetCustomerByName_LINQ : IQuery<Customer>
    {
        private readonly string name;

        public GetCustomerByName_LINQ(string name)
        {
            this.name = name;
        }

        public IQueryResult<Customer> Execute(ISession session)
        {
            var query = session.Linq<Customer>().Where(c => c.Name == name);
            return new LinqResult<Customer>(query);
        }
    }
}