using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LinqEFNorthwindLibrary.Models
{
    public class OrderDetail
    {
        public int OrderId { get; set; }  //PK & FK
        public int ProductId { get; set; }//PK & FK
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }

        public override string ToString()
        {
            return $"Order Detail: {OrderId} | {ProductId} | {UnitPrice} | {Quantity} | {Discount}";
        }

    }
}
