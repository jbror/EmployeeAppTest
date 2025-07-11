using EmployeesApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeesApp.Application.Employees.Interfaces;



namespace EmployeesApp.Infrastructure.Persistance.Repositories;

public class EmployeeRepository : IEmployeeRepository
{

    private readonly List<Employee> employees = new()
    {
        new Employee {Id = 1, Name = "Sauron", Email = "sauron_evil@hotmail.com"},
        new Employee {Id = 2, Name = "Yoda", Email = "yodaboy@yahoo.com"},
        new Employee {Id = 3, Name = "Neo", Email = "neo_03@matrix.com"}

    };
   

    public void Add(Employee employee)
    {

        

        
        employees.Add(employee);

        //File.WriteAllText(@"C:\Users\bror\Documents\kaka.txt", $"Adding employee {employee.Id}");

    }

    public Employee[] GetAll()
    {
        return employees.ToArray();
    }


    public Employee? GetById(int id)
    {
        return employees.FirstOrDefault(e => e.Id == id);
    }












}