
using LinqEFNorthwindLibrary.Controllers;
using LinqEFNorthwindLibrary.Models;

Console.WriteLine("Northwind Linq EF Library");




LinqAppContext _context = new();


EmployeesController emplCtrl = new(_context);
CustomersController custCtrl = new(_context);
ProductsController prodCtrl = new(_context);
OrdersController ordCtrl = new(_context);
OrderDetailsController ordDetailCtrl = new(_context);

//On Order Detail I overrode ToString.  Not on the others.

#region Customer GetAll Async
//put await on there to show it as async.  customers now shows IEnumberable, not task.
//var customers = await custCtrl.GetAllCustomers();
//foreach(Customer c in customers)
//{
//    Print(c.CompanyName);
//}
#endregion


var customer1 = await custCtrl.GetByPK("Bottx");

Print(customer1?.CompanyName ?? "Customer not found");

#region Customer Update
//Customer? x5 = custCtrl.GetByPK("XXXXX");
//x5.ContactName = "Noah Phence";
//
//custCtrl.Update(x5.CustomerId, x5);
//Print(x5);
#endregion

#region Customer Insert
// //Insert
//Customer cust = new()
//{
//    CustomerId = "XXXXX",
//    CompanyName = "Xtreme"
//};
//
//custCtrl.Insert(cust);
#endregion

#region Customer GetByPK
//Customer? customer = custCtrl.GetByPK("Bottm");
//Print(customer.CompanyName);
#endregion

#region GetAll Customers 2-different ways
//List<Customer> customers = custCtrl.GetAllCustomers().ToList();
//foreach(var customer in customers)
//{
//    Print(customer.CompanyName);
//}

//one way to do it, or the above.
//var customers = _context.Customers.ToList();
//foreach(var customer in customers)
//{
//    Print(customer.CompanyName);    
//}
#endregion

///////////

#region Employee Partial Name Search
//var empls = emplCtrl.GetByLastNamePartial("ll");
//
//foreach(Employee emp in empls)
//{
//    Print(emp);
//}

//emplCtrl.Delete(10);
#endregion

#region Insert New Employee
//Employee? newEmpl = new()
//{
//    EmployeeId = 0,
//    LastName = "Phence",
//    FirstName = "Fred",
//    Title = "Joker",
//    TitleOfCourtesy = "Mr.",
//    BirthDate = new DateTime(1995, 02, 06),
//    HireDate = new DateTime(2010, 1, 1),
//    Address = "1 Main Home Lane",
//
//};
//
//emplCtrl.Insert(newEmpl);
//Print(newEmpl);
#endregion

#region GetByPK Employee
//   //reading employee id 1
//Employee? empl1 = emplCtrl.GetByPK(1);
//
//empl1.TitleOfCourtesy = "Ms.";
//
//emplCtrl.Update(empl1.EmployeeId, empl1);
//
//Print(empl1);
#endregion

#region 2 Different GetAll Employees
//List<Employee> empls = emplCtrl.GetAll().ToList();
//
//foreach(var emp in empls)
//{
//    Print(emp);
//}

//var employees = _context.Employees.ToList();
//
//foreach(Employee employee in employees)
//{
//    Console.WriteLine(employee);
//}
#endregion

void Print(object obj)
{
    if(obj is null)
    {
        obj = "(NULL)";
    }
    Console.WriteLine(obj);
    System.Diagnostics.Debug.WriteLine(obj.ToString());
}




