using EmployeeApp.Models;

namespace EmployeeApp.Services
{
    public interface IEmployeeService
    {
        Employee GetEmployeeById(int id);
        IEnumerable<Employee> GetAllEmployees();
        void AddEmployee(Employee employee);
    }
}
