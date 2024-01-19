using CustomerManagement.Common.Models;

namespace CustomerManagement.Infrastructure.Services.Customer
{
    public interface ICustomerService : IBaseService<CustomerModel>
    {
        public Task<bool> Post(List<CustomerModel> entities);

    }
}
