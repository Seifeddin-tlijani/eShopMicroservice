using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using OrderWebApi.Models;

namespace OrderWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMongoCollection<Order> _orderCollection;

        public OrderController(IMongoDatabase database)
        {
            _orderCollection = database.GetCollection<Order>("Orders");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetAllOrders()
        {
            var orders = await _orderCollection.Find(_ => true).ToListAsync();
            return Ok(orders);
        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Order>> GetOrderById(string id)
        {
            var order = await _orderCollection.Find(o => o.OrderId == id).FirstOrDefaultAsync();

            if (order == null)
                return NotFound();

            return Ok(order);
        }

        [HttpPost]
        public async Task<ActionResult> CreateOrder([FromBody] Order order)
        {
            await _orderCollection.InsertOneAsync(order);
            return CreatedAtAction(nameof(GetOrderById), new { id = order.OrderId }, order);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> UpdateOrder(string id, [FromBody] Order order)
        {
            var result = await _orderCollection.ReplaceOneAsync(o => o.OrderId == id, order);

            if (result.MatchedCount == 0)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> DeleteOrder(string id)
        {
            var result = await _orderCollection.DeleteOneAsync(o => o.OrderId == id);

            if (result.DeletedCount == 0)
                return NotFound();

            return NoContent();
        }

    }
}
