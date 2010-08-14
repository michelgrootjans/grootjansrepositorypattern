using NHibernate;
using RepositoryExperiments.Domain.DataAccess;
using RepositoryExperiments.Domain.Entities;

namespace RepositoryExperiments.Domain.Queries
{
    public class GetCustomerByName_Query : IQuery<Customer>
    {
        private readonly string name;

        public GetCustomerByName_Query(string name)
        {
            this.name = name;
        }

        public IQueryResult<Customer> Execute(ISession session)
        {
            var query = session.CreateQuery("from Customer where Name=:name")
                .SetString("name", name);
            return new QueryResult<Customer>(query);
        }
    }
}