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

    public class CustomerRepositoryStub : ICustomerRepository
    {
        public bool IsGoldCustomer { get; set; }

        public void Save(Customer customer)
        {
            throw new System.NotImplementedException();
        }

        public Customer GetById(int id)
        {
            return new Customer {IsGoldCustomer = IsGoldCustomer };
        }
    }

    public class ServiceTests
    {
        private readonly CustomerRepositoryStub _stub;
        private readonly Service _sut;

        public ServiceTests()
        {
            _stub = new CustomerRepositoryStub();
            _sut = new Service(_stub);
        }

        [Fact]
        public void Should_return_discount_of_90_for_gold_customer()
        {
            _stub.IsGoldCustomer = true;
            var customerDiscount = _sut.GetCustomerDiscount(0);
            customerDiscount.ShouldBe(90);
        }

        [Fact]
        public void Should_return_discount_of_0_for_none_gold_customer()
        {
            _stub.IsGoldCustomer = false;
            var customerDiscount = _sut.GetCustomerDiscount(0);
            customerDiscount.ShouldBe(0);
        }
    }
}
