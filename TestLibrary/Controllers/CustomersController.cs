using LinqEFNorthwindLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqEFNorthwindLibrary.Controllers
{
    public class CustomersController
    {

        private readonly LinqAppContext _context = null!;



        public CustomersController(LinqAppContext context)
        {
            _context = context;
        }
               //made the method asynchronous return await with .ToListAsync() at the end.
        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            return await _context.Customers.OrderBy(c => c.CompanyName).ToListAsync();
        }

        public async Task<Customer?> GetByPK(string CustomerId)
        {
            //Customer? empl = await _context.Customers.SingleorDefaultAsync(e => e.CustomerId == customerId);
           return await _context.Customers.FindAsync(CustomerId);
        }

        public async Task Update(string CustomerId, Customer customer)
        {
            if(CustomerId != customer.CustomerId)
            {
                throw new ArgumentException("The CustomerID does not match!");
            }
                    //the only way EntityFramework can see the changes have been done.
            _context.Entry(customer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<Customer> Insert(Customer customer)
        {
            if (customer.CustomerId.Length != 5)
            {
                throw new ArgumentException("CustomerId cannot exceed five characters");
            }
            _context.Customers.Add(customer); //cache not async
            await _context.SaveChangesAsync();
            return customer;

        }
            //instead of return type void, you return Task.
        public async Task Delete(string CustomerId)
        {
            Customer? cust = await GetByPK(CustomerId);
            if(cust is null)
            {
                throw new Exception("Customer not found.");
            }
            _context.Customers.Remove(cust); //only taking it out of local cache, not hitting database
            await _context.SaveChangesAsync(); //this hits the database and needs async.
        }

    }
}
