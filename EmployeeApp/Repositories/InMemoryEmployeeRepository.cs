using EmployeeApp.Models;

namespace EmployeeApp.Repositories
{
    public class InMemoryEmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> _employees = new();

        public void Add(Employee employee)
        {
            _employees.Add(employee);
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employees;
        }

        public Employee GetById(int id)
        {
            return _employees.FirstOrDefault(e => e.Id == id);
        }
    }
}
