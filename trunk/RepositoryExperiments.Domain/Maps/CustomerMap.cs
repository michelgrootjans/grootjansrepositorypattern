using FluentNHibernate.Mapping;
using RepositoryExperiments.Domain.Entities;

namespace RepositoryExperiments.Domain.Maps
{
    public class CustomerMap : ClassMap<Customer>
    {
        public CustomerMap()
        {
            Id(c => c.Id);
            Map(c => c.Name);
        }
    }
}