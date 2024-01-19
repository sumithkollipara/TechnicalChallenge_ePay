using CustomerManagement.Common.Models;
using CustomerManagement.Infrastructure.Services.Customer;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerService _customerService;

        public CustomerController(ILogger<CustomerController> logger, ICustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }

        [HttpPost()]
        public async Task<ActionResult> Post([FromBody] List<CustomerModel> model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var res = await _customerService.Post(model);

            return Ok(res);
        }

        [HttpGet()]
        public async Task<ActionResult> Get()
        {
            var res = _customerService.GetAll(null).Result;
            return Ok(res);
        }
    }
}
