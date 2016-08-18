namespace Mocking_Stubbing
{
    public interface ICustomerRepository
    {
        void Save(Customer customer);
        Customer GetById(int id);
    }
}