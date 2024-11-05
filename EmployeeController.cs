using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testAPI.Models;

namespace testAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext _ApplicationDbContext;

        public EmployeeController(ApplicationDbContext ApplicationDbContext)
        {
            _ApplicationDbContext = ApplicationDbContext;
        }

        
        [HttpGet]
        public async Task<IEnumerable<Employee>> GetEmployee()
        {
            return await _ApplicationDbContext.Employees.ToListAsync();
        }

        
        [HttpPost]
        public async Task<ActionResult<Employee>> AddEmployee([FromBody] Employee objEmployee)
        {
            _ApplicationDbContext.Employees.Add(objEmployee);
            await _ApplicationDbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetEmployee), new { id = objEmployee.EmpId }, objEmployee);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] Employee objEmployee)
        {
            if (id != objEmployee.EmpId)
            {
                return BadRequest("Employee ID mismatch");
            }

            _ApplicationDbContext.Entry(objEmployee).State = EntityState.Modified;

            try
            {
                await _ApplicationDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_ApplicationDbContext.Employees.Any(e => e.EmpId == id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public async Task<bool> DeleteEmployee(int id)
        {
            var employee = await _ApplicationDbContext.Employees.FindAsync(id);
            if (employee == null)
            {
                return false;
            }

            _ApplicationDbContext.Employees.Remove(employee);
            await _ApplicationDbContext.SaveChangesAsync();
            return true;
        }
    }
}


