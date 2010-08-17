namespace RepositoryExperiments.Domain.Entities
{
    public class Customer : Entity, ICustomer
    {
        protected Customer()
        {
        }

        public Customer(string name)
        {
            Name = name;
        }

        public virtual string Name { get; private set; }
    }
}