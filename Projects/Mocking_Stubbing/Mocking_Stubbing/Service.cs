using System.Collections.Generic;
using System.Linq;
using Shouldly;
using Xunit;

namespace Mocking_Stubbing
{
    public class Service
    {
        private readonly ICustomerRepository _repository;

        public Service(ICustomerRepository repository)
        {
            _repository = repository;
        }

        // TODO TEST
        public void AddCustomer(Customer customer)
        {
            // Some Business Logic
            _repository.Save(customer);
        }

        // TODO TEST
        public int GetCustomerDiscount(int id)
        {
            var customer = _repository.GetById(id);

            if (customer.IsGoldCustomer)
                return 90;
            return 0;
        }
    }


    class CustomerRepositoryGold : ICustomerRepository
    {
        public void Save(Customer customer)
        {
        }

        public Customer GetById(int id)
        {
            return new Customer() { IsGoldCustomer = true };
        }
    }

    class CustomerRepositoryNonGold : ICustomerRepository
    {
        public void Save(Customer customer)
        {
        }

        public Customer GetById(int id)
        {
            return new Customer() { IsGoldCustomer = false };
        }
    }

    class CustomerRepositorySaveCustomerCalled : ICustomerRepository
    {
        public List<Customer> SavedCustomers { get; set; } = new List<Customer>();
        public void Save(Customer customer)
        {
            SavedCustomers.Add(customer);
        }

        public Customer GetById(int id)
        {
            throw new System.NotImplementedException();
        }
    }

    public class ServiceTests
    {
        [Fact]
        public void GetCustomerDiscountShouldReturnNinetyForGoldCustomer()
        {
            var customerRepositoryGold = new CustomerRepositoryGold();
            var service = new Service(customerRepositoryGold);

            service.GetCustomerDiscount(0).ShouldBe(90);
        }

        [Fact]
        public void GetCustomerDiscountShouldReturnZeroForNonGoldCustomer()
        {
            var customerRepositoryNonGold = new CustomerRepositoryNonGold();
            var service = new Service(customerRepositoryNonGold);

            service.GetCustomerDiscount(0).ShouldBe(0);
        }

        [Fact]
        public void AddCustomerShouldCallSave()
        {
            var repositorySaveCustomerCalled = new CustomerRepositorySaveCustomerCalled();
            var service = new Service(repositorySaveCustomerCalled);

            var customer = new Customer();
            service.AddCustomer(customer);
            repositorySaveCustomerCalled.SavedCustomers.Count.ShouldBe(1);
            repositorySaveCustomerCalled.SavedCustomers.First().ShouldBe(customer);
        }
    }
}
