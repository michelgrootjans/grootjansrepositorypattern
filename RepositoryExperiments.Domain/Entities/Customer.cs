using System;

namespace RepositoryExperiments.Domain.Entities
{
    public interface ICustomer
    {
        string Name { get; }
    }

    public class Customer : ICustomer
    {
        protected Customer()
        {
        }

        public Customer(string name)
        {
            Name = name;
        }

        public virtual Guid Id { get; private set; }

        public virtual string Name { get; private set; }
    }
}