using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;
using WebAPI_ModelBinding_Validation.Models;

namespace WebAPI_ModelBinding_Validation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        static List<Employee> employees = new List<Employee>();
        static int id = 1;
        public EmployeeController(){ }

        //create
        [HttpPost("create")]
        public IActionResult Create([FromBody]Employee employee) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }
            employee.Id = id++;
            employees.Add(employee);
            return CreatedAtAction(nameof(GetById), new { Id = employee.Id }, employee);
            
        }

        //readll
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            if (employees.Count != 0)
            {
                return Ok(employees); 
            }
            else
            {
                return Ok("No employees found.");
            }
        }

        //readbyid
        [HttpGet("getbyid/{id}")]
        public IActionResult GetById(int id)
        {
            var emp = employees.FirstOrDefault(e => e.Id == id);
            if (emp != null)
            {
                return Ok(emp);
            }
            else
            {
                return NotFound("No employee found with given id");

            }
        }

        //update
        [HttpPut("update")]
        public IActionResult Update([FromBody] Employee employee, [FromQuery]int id)
        {
            var emp = employees.FirstOrDefault(e => e.Id == id);
            if (emp == null)
            {
                return NotFound("No employee found with given id");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            emp.Name = employee.Name;
            emp.Age = employee.Age;
            return Ok(emp);
        }

        //delete
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var emp = employees.FirstOrDefault(e => e.Id == id);
            if (emp != null)
            {
                employees.Remove(emp);
                return NoContent();
            }
            else
            {
                return NotFound("No Employee found with given id");
            }
        }
        
    }
}
