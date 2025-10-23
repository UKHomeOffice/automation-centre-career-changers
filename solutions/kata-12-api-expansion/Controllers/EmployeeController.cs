using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BasicApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BasicApi.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            var employees = await _context.Employees.Include(e => e.Department).ToListAsync();
            return Ok(employees);
        }
    }
}
