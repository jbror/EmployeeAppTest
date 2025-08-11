using EmployeesApp.Application.Employees.Interfaces;
using EmployeesApp.Domain.Entities;
using EmployeesApp.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace EmployeesApp.Web.Tests;

public class EmployeesControllerTests
{
    [Fact]
    public void Index_NoParams_ReturnsViewResult()
    {
        // Arrange
        var employeeService = new Mock<IEmployeeService>();
        employeeService
            .Setup(o => o.GetAll())
            .Returns(
            [
                new Employee {Id = 1, Name = "Kurt"},
                new Employee {Id = 2, Name = "Olle"}
            ]);



        var controller = new EmployeesController(employeeService.Object);



        // Act


        var result = controller.Index();


        // Assert

        Assert.IsType<ViewResult>(result);


    }
}
