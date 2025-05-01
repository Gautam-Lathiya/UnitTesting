using EmployeeApp.Models;

namespace EmployeeApp.Repositories
{
    public interface IEmployeeRepository
    {
        Employee GetById(int id);
        IEnumerable<Employee> GetAll();
        void Add(Employee employee);
    }
}
