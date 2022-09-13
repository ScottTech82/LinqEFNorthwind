using LinqEFNorthwindLibrary.Models;
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

        public IEnumerable<Order> GetAll()
        {
            return _context.Orders;
        }

        public Order? GetByPK(int OrderId)
        {

            return _context.Orders.Find(OrderId);

        }

        public void Update(int OrderId, Order order)
        {
            if(OrderId != order.OrderId)
            {
                throw new ArgumentException("Primary key does not match.");
            }
            _context.Entry(order).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return;
        }

        public Order Insert(Order order)
        {
            if(order.OrderId != 0)
            {
                throw new ArgumentException("Inserting new order requires orderId to be zero.");
            }
            _context.Orders.Add(order);
            _context.SaveChanges();
            return order;
        }

        public void Delete(int OrderId)
        {
            Order? orderx = GetByPK(OrderId);
            if (orderx is null)
            {
                throw new Exception("Product not found.");
            }
            _context.Orders.Remove(orderx);
            _context.SaveChanges();
        }






    }
}
