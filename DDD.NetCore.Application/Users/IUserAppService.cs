using DDD.NetCore.Domain.Customers;

namespace DDD.NetCore.Application.Users
{
    public interface IUserAppService
    {
        void InitialCustomerForUser(string userId);

        Customer GetCustomerByUserId(string userId);
    }
}