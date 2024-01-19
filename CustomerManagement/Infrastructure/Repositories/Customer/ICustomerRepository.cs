using CustomerManagement.Common.Models;

namespace CustomerManagement.Infrastructure.Repositories.Customer
{
    public interface ICustomerRepository : IBaseRepository<SortedList<string, CustomerModel>>
    {
    }
}
