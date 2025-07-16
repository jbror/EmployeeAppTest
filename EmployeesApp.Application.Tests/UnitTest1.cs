using EmployeesApp.Application.Employees.Services;
using EmployeesApp.Application.Employees.Interfaces;
using EmployeesApp.Domain.Entities;

namespace EmployeesApp.Application.Tests;

public class EmployeeServiceTests
{
    [Fact]
    public void GetById_ValidId_ReturnsEmployee()
    {
        // Arrange
        
        var employeeService = new EmployeeService(new TestEmployeeRepository());


        // Act

        var result = employeeService.GetById(1);



        // Assert

        Assert.NotNull(result);
        Assert.Equal(1, result!.Id);
        Assert.Equal("Hasse", result.Name);


    }

    class TestEmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> _employees = new()
        {

         new Employee {Id = 1, Name = "Hasse"},
         new Employee {Id = 2, Name = "Brasse"}


        };


        public void Add(Employee employee)
        {
            _employees.Add(employee);
        }

        public Employee[] GetAll()
        {
            throw new NotImplementedException();
        }

        public Employee? GetById(int id)
        {
            return _employees.FirstOrDefault(e => e.Id == id);
        }
    }
}
