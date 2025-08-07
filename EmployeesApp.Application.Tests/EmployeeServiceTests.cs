using EmployeesApp.Application.Employees.Services;
using EmployeesApp.Application.Employees.Interfaces;
using EmployeesApp.Domain.Entities;
using System;
using Xunit;
using Moq;

namespace EmployeesApp.Application.Tests;

public class EmployeeServiceTests
{
    [Fact]
    public void GetById_ValidId_ReturnsEmployee()
    {
        // Arrange

        var employeeRepository = new Mock<IEmployeeRepository>();
        employeeRepository
            //.Setup(o => o.GetById(1))
            .Setup(o => o.GetById(It.IsAny<int>())) // kollar bara om deet är int
            .Returns(new Employee { Id = 1, Name = "Hasse" });

        //var employeeService = new EmployeeService(new TestEmployeeRepository());
        var employeeService = new EmployeeService(employeeRepository.Object);


        // Act

        var result = employeeService.GetById(1); //Testar GetById
       



        // Assert

        Assert.NotNull(result);
        Assert.Equal(1, result!.Id);
        Assert.Equal("Hasse", result.Name);

        employeeRepository.Verify(r => r.GetById(1), Times.Once());

    }


    [Fact]
    public void GetAll_ReturnsAllEmployees()
    {

        // Arange

        var employeeService = new EmployeeService(new TestEmployeeRepository());


        // Act

        var result = employeeService.GetAll();


        // Assert

        Assert.NotNull(result);
        Assert.Equal(2, result.Length);
        Assert.Equal("Brasse", result[1].Name);




    }


    [Fact]
    public void AddEmployee_WithRightCredentials_WillAddEmployeeToList()
    {

        //Arange

        var repo = new TestEmployeeRepository();
        var service = new EmployeeService(repo);
        var newEmployee = new Employee()
        {
            Name = "Holger",
            Email = "superhogge@hoffz.net"
        };



        //Act

        service.Add(newEmployee);


        //Assert HERE

        var allEmployees = service.GetAll();
        Assert.Equal(3, allEmployees.Length);

        var addedEmployee = allEmployees.Last();
        Assert.Equal("Holger", addedEmployee.Name);
        Assert.Equal("superhogge@hoffz.net", addedEmployee.Email);
        Assert.Equal(3, addedEmployee.Id);
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
            return _employees.ToArray();
        }

        public Employee? GetById(int id)
        {
            return _employees.FirstOrDefault(e => e.Id == id);
        }
    }
}
