using Microsoft.AspNetCore.Mvc;

namespace OrdersService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public OrdersController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> Get(string orderId)
        {
            var response = await _httpClient.GetAsync(
                "http://inventory-service:8080/api/inventory/P001");

            var content = await response.Content.ReadAsStringAsync();

            return Ok(new
            {
                OrderId = orderId,
                Inventory = content,
                Server = Environment.MachineName
            });
        }
    }
}
