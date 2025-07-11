//using EmployeesApp.Web.Models;

//namespace EmployeesApp.Web.Services;

//public class OtherEmployeeService : IEmployeeService
//{
//    private readonly List<Employee> employees = new()
//    {
//        new Employee {Id = 101, Name = "Evert", Email = "evert999@test.com"},
//        new Employee {Id = 102, Name = "Bert", Email = "berty_boy@yahoo.com"},
//        new Employee {Id = 103, Name = "Niklas", Email = "snyggnikke@manly.org"}

//    };
//    private int nextId = 104; // Första lediga Id

//    public void Add(Employee employee)
//    {

//        //employees.Add(employee);

//        employee.Id = nextId;
//        nextId++;
//        employees.Add(employee);


//    }

//    public Employee[] GetAll()
//    {
//        return employees.ToArray();
//    }


//    public Employee? GetById(int id)
//    {
//        return employees.FirstOrDefault(e => e.Id == id);
//    }












//}


