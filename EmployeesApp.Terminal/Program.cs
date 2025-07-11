using EmployeesApp.Application.Employees.Interfaces;
using EmployeesApp.Application.Employees.Services;
using EmployeesApp.Infrastructure.Persistance.Repositories;

namespace EmployeesApp.Terminal;

internal class Program
{
    static void Main(string[] args)
    {


        var employeeRepository = new EmployeeRepository();
        var employeeService = new EmployeeService(employeeRepository);


        var employees = employeeService.GetAll();


        Console.WriteLine("This is the names of our employees");
        foreach (var e in employees)
        {
            Console.WriteLine($" - {e.Name}");
        }







    }
}
