using System.Linq;
using NUnit.Framework;
using RepositoryExperiments.Domain.Entities;
using RepositoryExperiments.Domain.Queries;

namespace RepositoryExperiments.UnitTests
{
    public class CustomerQueryTests : InMemoryDataAccessTest
    {
        private const string customerName = "customer 1";

        protected override void PrepareData()
        {
            repository.Add(new Customer(customerName));
            repository.Add(new Customer("customer 2"));
            repository.Add(new Customer("customer 3"));
        }

        [Test]
        public void should_be_able_to_get_all_customers()
        {
            var customers = repository.Query(new GetAll<ICustomer>()).List();
            Assert.That(customers.Count(), Is.EqualTo(3));
        }

        [Test]
        public void should_be_able_to_get_an_existing_customer_with_criteria()
        {
            var customer = repository.Query(new GetCustomerByName_Criteria(customerName)).UniqueResult();
            Assert.That(customer, Is.Not.Null);
            Assert.That(customer.Name, Is.EqualTo(customerName));
        }

        [Test]
        public void should_be_able_to_get_an_existing_customer_with_query()
        {
            var customer = repository.Query(new GetCustomerByName_Query(customerName)).UniqueResult();
            Assert.That(customer, Is.Not.Null);
            Assert.That(customer.Name, Is.EqualTo(customerName));
        }

        [Test]
        public void should_be_able_to_get_an_existing_customer_with_linq()
        {
            var customer = repository.Query(new GetCustomerByName_LINQ(customerName)).UniqueResult();
            Assert.That(customer, Is.Not.Null);
            Assert.That(customer.Name, Is.EqualTo(customerName));
        }


        [Test]
        public void should_not_be_able_to_get_a_deleted_customer()
        {
            var customer = repository.Query(new GetCustomerByName_Criteria(customerName)).UniqueResult();
            repository.Remove(customer);
            FlushAndClear();

            var customer2 = repository.Query(new GetCustomerByName_Criteria(customerName)).UniqueResult();
            Assert.That(customer2, Is.Null);
        }

    }
}