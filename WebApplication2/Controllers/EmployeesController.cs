using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;

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
}