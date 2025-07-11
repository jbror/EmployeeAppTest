using Microsoft.AspNetCore.Mvc;
using EmployeesApp.Web.Models.ViewModels;
using Microsoft.Extensions.Logging;
using EmployeesApp.Application.Employees.Interfaces;
using EmployeesApp.Domain.Entities;

namespace EmployeesApp.Web.Controllers;

public class EmployeesController : Controller
{
    private readonly IEmployeeService _employeeService;
    private readonly ILogger<EmployeesController> _logger;

    public EmployeesController(IEmployeeService employeeService, ILogger<EmployeesController> logger) // Nu med filter och ILogger
    {
        _employeeService = employeeService;
        _logger = logger;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        var employees = _employeeService.GetAll();
        var viewModels = employees.Select(e => new EmployeeIndexViewModel
        {
            Id = e.Id,
            Name = e.Name,
            Email = e.Email
        }).ToList();

        _logger.LogInformation("Number of employees: {count}", viewModels.Count);
        


        return View(viewModels);
    }



    [HttpGet("create")]
    public IActionResult Create()
    {

        return View(new EmployeeCreateViewModel());
    }

    [HttpPost("create")]
    public IActionResult Create(EmployeeCreateViewModel vm)
    {

        if (ModelState.IsValid)
        {
            var employee = new Employee
            {
              
                Name = vm.Name,
                Email = vm.Email
            };

            _employeeService.Add(employee);
            _logger.LogInformation("New employee created! Name: {Name}", employee.Name);
            return RedirectToAction("Index");
        }
        
        return View(vm);
    }

    
    
    



}
