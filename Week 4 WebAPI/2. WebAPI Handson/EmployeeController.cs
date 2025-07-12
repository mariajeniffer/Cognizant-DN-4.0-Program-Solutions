using Microsoft.AspNetCore.Mvc;
using WebAPI2.Models;

namespace WebAPI2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private static List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Maria", Department = "IT", Salary = 60000 },
            new Employee { Id = 2, Name = "Arjun", Department = "HR", Salary = 50000 },
            new Employee { Id = 3, Name = "Divya", Department = "Finance", Salary = 55000 }
        };

        /// <summary>Get all employees</summary>
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetAll()
        {
            return employees;
        }

        /// <summary>Get a specific employee by ID</summary>
        [HttpGet("{id}")]
        public ActionResult<Employee> GetById(int id)
        {
            var emp = employees.FirstOrDefault(e => e.Id == id);
            if (emp == null) return NotFound();
            return emp;
        }

        /// <summary>Create a new employee</summary>
        [HttpPost]
        public IActionResult Create([FromBody] Employee employee)
        {
            employee.Id = employees.Max(e => e.Id) + 1;
            employees.Add(employee);
            return CreatedAtAction(nameof(GetById), new { id = employee.Id }, employee);
        }

        /// <summary>Update an existing employee</summary>
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Employee updated)
        {
            var emp = employees.FirstOrDefault(e => e.Id == id);
            if (emp == null) return NotFound();

            emp.Name = updated.Name;
            emp.Department = updated.Department;
            emp.Salary = updated.Salary;

            return NoContent();
        }

        /// <summary>Delete an employee</summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var emp = employees.FirstOrDefault(e => e.Id == id);
            if (emp == null) return NotFound();

            employees.Remove(emp);
            return NoContent();
        }
    }
}