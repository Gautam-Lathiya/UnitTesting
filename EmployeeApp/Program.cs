using EmployeeApp.Models;
using EmployeeApp.Repositories;
using EmployeeApp.Services;

var repo = new InMemoryEmployeeRepository(); // You can mock this or replace with real
var service = new EmployeeService(repo);

var emp = new Employee { Id = 1, Name = "Alice" };
service.AddEmployee(emp);

Console.WriteLine(service.GetEmployeeById(1)?.Name);
