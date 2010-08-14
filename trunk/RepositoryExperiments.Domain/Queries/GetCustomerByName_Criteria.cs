using NHibernate;
using NHibernate.Criterion;
using RepositoryExperiments.Domain.DataAccess;
using RepositoryExperiments.Domain.Entities;

namespace RepositoryExperiments.Domain.Queries
{
    public class GetCustomerByName_Criteria : IQuery<Customer>
    {
        private readonly string name;

        public GetCustomerByName_Criteria(string name)
        {
            this.name = name;
        }

        public IQueryResult<Customer> Execute(ISession session)
        {
            var criteria = session.CreateCriteria<Customer>().Add(Restrictions.Eq("Name", name));
            return new CriteriaResult<Customer>(criteria);
        }
    }
}