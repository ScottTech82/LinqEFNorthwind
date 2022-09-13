using LinqEFNorthwindLibrary.Models;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqEFNorthwindLibrary.Controllers
{
    public class OrderDetailsController
    {

        public readonly LinqAppContext _context = null!;

        public OrderDetailsController(LinqAppContext context)
        {
            _context = context;
        }

        public IEnumerable<OrderDetail> GetAll()
        {
            return _context.OrderDetails;
        }
                        //2 PK's so both have to be entered. They both equal the PK.
        public OrderDetail? GetByPK(int OrderId, int ProductId)
        {
            return _context.OrderDetails.Find(OrderId, ProductId);
        }

        public void Update(int OrderId, int ProductId, OrderDetail orderdetail)
        {
            if(OrderId != orderdetail.OrderId || ProductId != orderdetail.ProductId)
            {
                throw new ArgumentException("The OrderId does not match");
            }
            _context.Entry(orderdetail).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return;
        }

        public OrderDetail Insert(OrderDetail orderdetail)
        {
                //checking to see if the product already exists, if so cannot add again due to PKs
                //we want to update the quantity instead.
            OrderDetail? od = GetByPK(orderdetail.OrderId, orderdetail.ProductId);
            if(od is not null)
            {
                throw new Exception("Product already exists on the order.");
            }
            _context.OrderDetails.Add(orderdetail);
            _context.SaveChanges();
            return orderdetail;
        }

        public void Delete(int OrderId, int ProductId)
        {
            OrderDetail? orderDetail = GetByPK(OrderId, ProductId);
            if(orderDetail is null)
            {
                throw new Exception("The OrderDetail is not found");
            }
            _context.OrderDetails.Remove(orderDetail);
            _context.SaveChanges();

        }



    }
}
