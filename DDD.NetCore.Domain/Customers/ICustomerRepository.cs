namespace DDD.NetCore.Domain.Customers
{
    public interface ICustomerRepository
    {
        void Add(Customer customer);

        Customer GetCustomerByUserId(string userId);

        void Update(Customer customer);
    }
}