using LinqEFNorthwindLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqEFNorthwindLibrary.Controllers
{
    public class EmployeesController
    {
            //read only, take value of _context
        private readonly LinqAppContext _context = null!;

            //take that value and pass it into variable context.
            //constructor.
        public EmployeesController(LinqAppContext context)
        {
            _context = context;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _context.Employees.OrderBy(e => e.LastName);
        }

        public Employee? GetByPK(int employeeId)
        {
            //Employee? empl = _context.Employees.SingleOrDefault(e => e.EmployeeId == employeeId);
            return _context.Employees.Find(employeeId);
        }

        public IEnumerable<Employee> GetByLastNamePartial(string subString)
        {
            //can use query syntax or method syntax
            IEnumerable<Employee> employees = from e in _context.Employees
                                              where e.LastName.Contains(subString)
                                              orderby e.LastName
                                              select e;
            return employees;
        }




        public void Update(int employeeId, Employee employee)
        {
            if(employeeId != employee.EmployeeId)
            {
                throw new ArgumentException("Employee Id does not match employee instance!");
            }
            _context.Entry(employee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return;
        }

        public Employee Insert(Employee employee)
        {
          if(employee.EmployeeId != 0) 
          {
             throw new ArgumentException("Inserting a new employee requires the employeeId be set to zero!");
          }
                //adding the new insert employee to cache and saving changes.
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return employee;
        }

        public void Delete(int employeeId)
        {
           //Make a call to the GetByPk
           Employee? empl = GetByPK(employeeId);
            if(empl is null)
            {
                throw new Exception("Employee Not Found");
            }
                    //remove removes it from the cache, save changes removes from database.
            _context.Remove(empl);
            _context.SaveChanges();
        }

        
    }
}
