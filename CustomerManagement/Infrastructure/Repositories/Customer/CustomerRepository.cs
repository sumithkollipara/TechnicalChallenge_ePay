using CustomerManagement.Common.Models;
using Newtonsoft.Json;

namespace CustomerManagement.Infrastructure.Repositories.Customer
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly string _filePath;
        private readonly ILogger<CustomerRepository> _logger;
        public CustomerRepository(ILogger<CustomerRepository> logger)
        {
            _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ePayCustomerData.json");
            _logger = logger;
        }
        SortedList<string, CustomerModel>? IBaseRepository<SortedList<string, CustomerModel>>.Read
        {
            get
            {
                try
                {
                    return JsonConvert.DeserializeObject<SortedList<string, CustomerModel>>(File.ReadAllText(_filePath));

                }
                catch (Exception)
                {
                    _logger.LogError($"Unable to read JSON file from {_filePath}");
                }
                return null;
            }
        }

        public void Write(SortedList<string, CustomerModel> data)
        {
            File.WriteAllText(_filePath, JsonConvert.SerializeObject(data));
        }
    }
}
