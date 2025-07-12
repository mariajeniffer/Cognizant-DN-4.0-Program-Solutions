using EmployeeApiDemo.Filters;
using EmployeeApiDemo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApiDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ServiceFilter(typeof(CustomAuthFilter))] // ✅ Applies custom authorization filter
    public class EmployeeController : ControllerBase
    {
        private List<Employee> _employees;

        public EmployeeController()
        {
            _employees = GetStandardEmployeeList();
        }

        private List<Employee> GetStandardEmployeeList()
        {
            return new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    Name = "John",
                    Salary = 50000,
                    Permanent = true,
                    DateOfBirth = new DateTime(1990, 1, 1),
                    Department = new Department { Id = 1, Dept = "HR" },
                    Skills = new List<Skill>
                    {
                        new Skill { Id = 1, SkillName = "C#" },
                        new Skill { Id = 2, SkillName = "ASP.NET" }
                    }
                }
            };
        }

        // ✅ GET method that throws exception (for testing CustomExceptionFilter)
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<Employee>> GetStandard()
        {
            throw new Exception("Something went wrong in GetStandard!");

            // Normal return would be:
            // return Ok(_employees);
        }

        // ✅ POST method to receive a new employee
        [HttpPost]
        public IActionResult Post([FromBody] Employee emp)
        {
            return Ok($"Received: {emp.Name}");
        }

        // ✅ PUT method to update existing employee
        [HttpPut]
        public ActionResult<Employee> UpdateEmployee([FromBody] Employee emp)
        {
            if (emp.Id <= 0)
            {
                return BadRequest("Invalid employee id");
            }

            var existingEmployee = _employees.FirstOrDefault(e => e.Id == emp.Id);

            if (existingEmployee == null)
            {
                return BadRequest("Invalid employee id");
            }

            // Update details
            existingEmployee.Name = emp.Name;
            existingEmployee.Salary = emp.Salary;
            existingEmployee.Permanent = emp.Permanent;
            existingEmployee.DateOfBirth = emp.DateOfBirth;
            existingEmployee.Department = emp.Department;
            existingEmployee.Skills = emp.Skills;

            return Ok(existingEmployee);
        }
    }
}

