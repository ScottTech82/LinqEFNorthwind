using LinqEFNorthwindLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqEFNorthwindLibrary.Controllers
{
    public class ProductsController
    {
        public readonly LinqAppContext _context = null!;

        public ProductsController(LinqAppContext context) { _context = context; }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products; //could do an order by here
        }

        public Product? GetByPK(int ProductId)
        {
            return _context.Products.Find(ProductId);
        }

        public void Update(int ProductId, Product product)
        {
            if (ProductId != product.ProductId)
            {
                throw new ArgumentException("The ProductID does not match!");
            }
            //the only way EntityFramework can see the changes have been done.
            _context.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return;
        }

        public Product Insert(Product product)
        {
            if (product.ProductId != 0)
            {
                throw new ArgumentException("ProductId must be set to 0");
            }
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;

        }

        public void Delete(int ProductId)
        {
            Product? prod = GetByPK(ProductId);
            if (prod is null)
            {
                throw new Exception("Product not found.");
            }
            _context.Products.Remove(prod);
            _context.SaveChanges();
        }


    }
}
