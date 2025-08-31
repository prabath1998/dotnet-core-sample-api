using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.Models.Entities;

namespace WebApplication2.Controllers;

[Route("api/[controller]")]
[ApiController]

public class EmployeesController : Controller
{
   private readonly ApplicationDbContext dbContext;
   public EmployeesController(ApplicationDbContext dbContext)
   {
      this.dbContext = dbContext;
   }
   [HttpGet]
   public IActionResult GetAllEmployees()
   {
      var allEmployees =  dbContext.Employees.ToList();
      return Ok(allEmployees);
   }

   [HttpPost]
   public IActionResult CreateEmployee(AddEmployeeDto employee)
   {
      var employeeEntity = new Employee()
      {
         Name = employee.Name,
         Email = employee.Email,
         Phone = employee.Phone,
         Salary = employee.Salary,
      };
      dbContext.Employees.Add(employeeEntity);
      dbContext.SaveChanges();
      return Ok(employeeEntity);
   }
}