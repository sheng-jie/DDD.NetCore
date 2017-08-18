using DDD.NetCore.Domain.Authorization;
using DDD.NetCore.Domain.Customers;
using DDD.NetCore.Domain.Uow;

namespace DDD.NetCore.Application.Users
{
    public interface IUserAppService
    {
        void InitialCustomerForUser(string userId);

        Customer GetCustomerByUserId(string userId);
    }

    public class UserAppService : IUserAppService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserAppService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void InitialCustomerForUser(string userId)
        {
            throw new System.NotImplementedException();
        }

        public Customer GetCustomerByUserId(string userId)
        {
            throw new System.NotImplementedException();
        }
    }
}