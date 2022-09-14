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

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products.ToListAsync(); //could do an order by here
        }

        public async Task<Product?> GetByPK(int ProductId)
        {
            return await _context.Products.FindAsync(ProductId);
        }

        public async Task Update(int ProductId, Product product)
        {
            if (ProductId != product.ProductId)
            {
                throw new ArgumentException("The ProductID does not match!");
            }
            //the only way EntityFramework can see the changes have been done.
            _context.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            return;
        }

        public async Task<Product> Insert(Product product)
        {
            if (product.ProductId != 0)
            {
                throw new ArgumentException("ProductId must be set to 0");
            }
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;

        }

        public async Task Delete(int ProductId)
        {
            Product? prod = await GetByPK(ProductId);
            if (prod is null)
            {
                throw new Exception("Product not found.");
            }
            _context.Products.Remove(prod);
            await _context.SaveChangesAsync();
        }


    }
}
