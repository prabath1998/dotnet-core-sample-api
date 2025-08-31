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
   
   [HttpGet]
   [Route("{id:guid}")]
   public IActionResult GetEmployeeById(Guid id)
   {
      var employee = dbContext.Employees.Find(id);
      if (employee is null)
      {
         return NotFound();
      }

      return Ok(employee);
   }

   [HttpPut]
   [Route("{id:guid}")]
   
   public IActionResult UpdateEmployee(Guid id, UpdateEmployeeDto updateEmployeeDto)
   {
      var employee = dbContext.Employees.Find(id);
      
      if (employee is null)
      {
         return NotFound();
      }
      
      employee.Name = updateEmployeeDto.Name;
      employee.Email = updateEmployeeDto.Email;
      employee.Phone = updateEmployeeDto.Phone;
      employee.Salary = updateEmployeeDto.Salary;
      
      dbContext.SaveChanges();
      return Ok();
   }

   [HttpDelete]
   [Route("{id:guid}")]

   public IActionResult DeleteEmployee(Guid id)
   {
      var employee = dbContext.Employees.Find(id);
      if (employee is null)
      {
         return NotFound();
      }

      dbContext.Employees.Remove(employee);
      dbContext.SaveChanges();
      return Ok();
   }
}