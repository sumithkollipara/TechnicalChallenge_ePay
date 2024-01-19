using CustomerManagement.Common.Models;
using CustomerManagement.Infrastructure.Repositories.Customer;

namespace CustomerManagement.Infrastructure.Services.Customer
{
    public class CustomerService : ICustomerService, IBaseService<CustomerModel>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ILogger<CustomerModel> _logger;
        private static SortedList<string, CustomerModel> _customerList = new SortedList<string, CustomerModel>();
        private static bool _isInitialized = false;
        object obj = new();
        public CustomerService(ILogger<CustomerModel> logger, ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
            _logger = logger;
            if (!_isInitialized)
            {
                var previousData = _customerRepository.Read;
                if (previousData != null) //Only look for past data just once during lifetime of server running
                {
                    _customerList = previousData;
                }
                _isInitialized = true;
            }
        }
        public async Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CustomerModel>> GetAll(int? parentId)
        {
            return _customerList.Values.ToList();
        }

        public async Task<CustomerModel> GetById(int resourceId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Post(CustomerModel entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Post(List<CustomerModel> entities)
        {

            lock (obj)
            {
                Parallel.ForEach(entities, entity =>
                {
                    if (IsUnique(entity))
                    {
                        _customerList.Add($"{entity.LastName}{entity.FirstName}", entity);
                    }
                    else
                    {
                        _logger.LogWarning($"Unable to add record with Id : {entity.Id} because it already exists in the system");
                    }
                });
                _customerRepository.Write(_customerList);
            }
            return true;
        }

        public async Task<CustomerModel> Put(int id, CustomerModel entity)
        {
            throw new NotImplementedException();
        }
        private bool IsUnique(CustomerModel model)
        {
            bool isUnique = true;

            foreach (var key in _customerList.Keys)
            {
                CustomerModel item;
                if (_customerList.TryGetValue(key, out item))
                {
                    if (item.Id == model.Id)
                    {
                        isUnique = false;
                        break;
                    }
                }

            }
            return isUnique;
        }
    }
}
