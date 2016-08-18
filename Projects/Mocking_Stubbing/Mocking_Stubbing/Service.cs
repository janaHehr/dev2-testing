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
}
