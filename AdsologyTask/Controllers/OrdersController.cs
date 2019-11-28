using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdsologyTask.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdsologyTask.Models;

namespace AdsologyTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrdersDBContext _context;

        public OrdersController(OrdersDBContext context)
        {
            _context = context;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrder()
        {
            return await _context.Orders.ToListAsync();
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(long id)
        {
            var Order = await _context.Orders.FindAsync(id);

            if (Order == null)
            {
                return NotFound();
            }

            return Order;
        }

        //POST: api/Orders
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder([FromBody]Order order)
        {
            _context.Orders.Add(order);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                if (OrderExists(order.OxId))
                {
                    return Conflict();
                }
                else
                {
                    throw e;
                }
            }

            return CreatedAtAction("GetOrder", new { id = order.OxId }, order);
        }

        [HttpPost]
        [Route("PostMultiple")]
        public async Task<IActionResult> PostOrders(Orders orders)
        {
            foreach (Order order in orders.OrderList)
            {
                _context.Orders.Add(order);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    if (OrderExists(order.OxId))
                    {
                        return Conflict();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return Ok();
        }


        [HttpGet]
        [Route("Filter")]
        public List<Order> Filter(string filter)
        {
            IQueryable<Order> query = _context.Orders.AsQueryable();

            var filterBy = filter.Trim().ToLowerInvariant();
            if (!string.IsNullOrEmpty(filterBy))
            {
                query = query
                        .Where(x => x.OxId.ToString().Contains(filterBy));
            }

            return query.ToList();
        }

        [HttpPost]
        [Route("SetStatus")]
        public async Task<ActionResult<Order>> SetStatus(long id, string newStatus)
        {
            Order order = await _context.Orders.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            OrderStatuses currentStatus = await _context.OrderStatuses.FirstOrDefaultAsync(x=>x.Name == newStatus);

            if (currentStatus == null)
            {
                return base.NotFound("This status does not exist in db");
            }

            order.OrderStatus = currentStatus.Id;

            await _context.SaveChangesAsync();

            return order;
        }

        [HttpPost]
        [Route("SetInvoice")]
        public async Task<ActionResult<Order>> SetInvoice(long id, int newInvoice)
        {
            Order order = await _context.Orders.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            order.InvoiceNumber = newInvoice;

            await _context.SaveChangesAsync();

            return order;
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Order>> DeleteOrder(long id)
        {
            var Order = await _context.Orders.FindAsync(id);
            if (Order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(Order);
            await _context.SaveChangesAsync();

            return Order;
        }

        private bool OrderExists(long id)
        {
            return _context.Orders.Any(e => e.OxId == id);
        }
    }
}
