using LinqEFNorthwindLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqEFNorthwindLibrary.Controllers
{
    public class OrdersController
    {
        public readonly LinqAppContext _context = null!;

        public OrdersController(LinqAppContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order?> GetByPK(int OrderId)
        {

            return await _context.Orders.FindAsync(OrderId);

        }

        public async Task Update(int OrderId, Order order)
        {
            if(OrderId != order.OrderId)
            {
                throw new ArgumentException("Primary key does not match.");
            }
            _context.Entry(order).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            return;
        }

        public async Task<Order> Insert(Order order)
        {
            if(order.OrderId != 0)
            {
                throw new ArgumentException("Inserting new order requires orderId to be zero.");
            }
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task Delete(int OrderId)
        {
            Order? orderx = await GetByPK(OrderId);
            if (orderx is null)
            {
                throw new Exception("Product not found.");
            }
            _context.Orders.Remove(orderx);
            await _context.SaveChangesAsync();
        }





    }
}
