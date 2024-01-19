using CustomerManagement.Common.Models;
using CustomerManagement.Test.Helpers;
using Newtonsoft.Json;
using RestSharp;
using Xunit;

namespace CustomerManagement.Test
{
    public class CustomerControllerTest
    {
        private readonly string _apiBaseUrl = "https://localhost:7165/";
        [Fact]
        public async void Post_Parallel_Customers_And_Verify_By_Getting_Test()
        {
            var customers = DataGenerator.GenerateRandomCustomerObjects(DataGenerator.GenerateFirstName(), DataGenerator.GenerateLastName());

            var responses = new List<Task<RestResponse>>();
            var multipleCustomersInParallel = new List<List<CustomerModel>>
            {
                customers.OrderBy(x => x.Id).Skip(0).Take(2).ToList(),
                customers.OrderBy(x => x.Id).Skip(2).Take(2).ToList(),
                customers.OrderBy(x => x.Id).Skip(4).Take(4).ToList(),
                customers.OrderBy(x => x.Id).Skip(8).Take(2).ToList()
            };

            Parallel.ForEach(multipleCustomersInParallel, c =>
            {
                RestClient restClient = new(_apiBaseUrl);
                RestRequest request = new("Customer", Method.Post);
                request.AddBody(c);
                responses.Add(restClient.ExecuteAsync(request));
            });

            var res = await Task.WhenAll(responses);

            RestClient getRestClient = new(_apiBaseUrl);
            RestRequest getRequest = new("Customer", Method.Get);
            var allRecords = getRestClient.Execute(getRequest);
            var result = allRecords.Content;
            var customersReturnedByServer = JsonConvert.DeserializeObject<List<CustomerModel>>(result);

            customers = customers
                .Where(x => x.Id > 0 && x.Age > 18)
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .ToList();

            if (customersReturnedByServer != null && customersReturnedByServer.Count > 0)
            {
                bool sequenceMatched = true;
                for (int i = 0; i < customers.Count; i++)
                {
                    if (customers[i].Id != customersReturnedByServer[i].Id)
                    {
                        sequenceMatched = false;
                        break;
                    }
                }
                Assert.True(sequenceMatched);
            }
            else
            {
                Assert.True(false);
            }
        }
    }
}
