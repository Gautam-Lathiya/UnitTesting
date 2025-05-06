using EmployeeApp.Models;
using EmployeeApp.Repositories;
using EmployeeApp.Services;
using Moq;

namespace EmployeeApp.Tests
{
    public class EmployeeServiceTests
    {
        private readonly Mock<IEmployeeRepository> _mockRepo;
        private readonly EmployeeService _service;

        public EmployeeServiceTests()
        {
            _mockRepo = new Mock<IEmployeeRepository>();
            _service = new EmployeeService(_mockRepo.Object);
        }

        [Fact]
        public void GetEmployeeById_ValidId_ReturnsEmployee()
        {
            var emp = new Employee { Id = 1, Name = "John" };
            _mockRepo.Setup(r => r.GetById(1)).Returns(emp);

            var result = _service.GetEmployeeById(1);

            Assert.NotNull(result);
            Assert.Equal("John", result.Name);
        }

        [Fact]
        public void GetEmployeeById_NotFound_ReturnsNull()
        {
            _mockRepo.Setup(r => r.GetById(2)).Returns((Employee)null);

            var result = _service.GetEmployeeById(2);

            Assert.Null(result);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-5)]
        public void GetEmployeeById_InvalidId_ReturnsNull(int id)
        {
            var result = _service.GetEmployeeById(id);

            Assert.Null(result);
        }

        [Fact]
        public void GetEmployeeById_RepositoryThrows_ThrowsException()
        {
            _mockRepo.Setup(r => r.GetById(It.IsAny<int>())).Throws(new Exception("DB error"));

            Assert.Throws<Exception>(() => _service.GetEmployeeById(1));
        }

        [Fact]
        public void AddEmployee_ValidEmployee_CallsRepositoryAdd()
        {
            var emp = new Employee { Id = 1, Name = "John" };
            _service.AddEmployee(emp);
            _mockRepo.Verify(r => r.Add(emp), Times.Once);
        }
    }
}