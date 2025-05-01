using EmployeeApp.Models;
using EmployeeApp.Repositories;

namespace EmployeeApp.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repo;

        public EmployeeService(IEmployeeRepository repo)
        {
            _repo = repo;
        }

        public Employee GetEmployeeById(int id)
        {
            if (id <= 0) return null;
            return _repo.GetById(id);
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _repo.GetAll();
        }

        public void AddEmployee(Employee employee)
        {
            _repo.Add(employee);
        }
    }
}
