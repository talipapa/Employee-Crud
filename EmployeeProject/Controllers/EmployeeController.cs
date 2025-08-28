using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmployeeProject.Model;
using EmployeeProject.Data;
using Microsoft.EntityFrameworkCore;
using EmployeeProject.DTO.Employee;

namespace EmployeeProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly DataContext _context;

        public EmployeeController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees(string? searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
            {
                var employees = await _context.Employees.ToListAsync();
                List<ViewEmployeeDto> employees_dto = employees.Select(e => new ViewEmployeeDto
                {
                    Id = e.Id,
                    FullName = e.GetFullName(initialMiddle: true),
                    Position = e.Position,
                    MonthlyRate = e.MonthlyRate,
                    OnBoardDate = e.OnBoardDate
                }).ToList<ViewEmployeeDto>();
                return Ok(employees_dto);

            }

            var query = _context.Employees.AsQueryable();

            query = query.Where(e => e.FirstName.Contains(searchString) ||
                                     e.LastName.Contains(searchString) ||
                                     (e.MiddleName != null && e.MiddleName.Contains(searchString)) ||
                                     (e.Suffix != null && e.Suffix.Contains(searchString)) ||
                                     (e.MonthlyRate.ToString().Contains(searchString)) ||
                                     e.Position.Contains(searchString) ||
                                     (e.Id.ToString().Contains(searchString)));


            List<Employee> filteredEmployees = await query.ToListAsync();
            var filteredEmployeesDto = filteredEmployees.Select(e => new ViewEmployeeDto
            {
                Id = e.Id,
                FullName = e.GetFullName(initialMiddle: true),
                Position = e.Position,
                MonthlyRate = e.MonthlyRate,
                OnBoardDate = e.OnBoardDate
            }).ToList();
            return Ok(filteredEmployeesDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
                return BadRequest("Employee not found.");

            var employeeDto = new ViewEmployeeDto
            {
                Id = employee.Id,
                FullName = employee.GetFullName(initialMiddle: false),
                Position = employee.Position,
                MonthlyRate = employee.MonthlyRate,
                OnBoardDate = employee.OnBoardDate
            };

            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(AddEmployeeDto employeeDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var employee = new Employee
                {
                    FirstName = employeeDto.FirstName,
                    MiddleName = employeeDto.MiddleName,
                    LastName = employeeDto.LastName,
                    Suffix = employeeDto.Suffix,
                    Position = employeeDto.Position,
                    MonthlyRate = employeeDto.MonthlyRate,
                    OnBoardDate = employeeDto.OnBoardDate
                };

                _context.Employees.Add(employee);
                await _context.SaveChangesAsync();
                return Created();

            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> EditEmployee(int id, UpdateEmployeeDto employeeDto)
        {
            try
            {
                var employee = await _context.Employees.FindAsync(id);
                if (employee == null)
                    return NotFound("Employee not found.");
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                employee.FirstName = employeeDto.FirstName;
                employee.MiddleName = employeeDto.MiddleName;
                employee.LastName = employeeDto.LastName;
                employee.Suffix = employeeDto.Suffix;
                employee.Position = employeeDto.Position;
                employee.MonthlyRate = employeeDto.MonthlyRate;
                employee.OnBoardDate = employeeDto.OnBoardDate;
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PartialEditEmployee(int id, PartialUpdateEmployeeDto employeeDto)
        {
            try
            {
                var employee = await _context.Employees.FindAsync(id);
                if (employee == null)
                    return NotFound("Employee not found.");
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (employeeDto.FirstName != null)
                {
                    employee.FirstName = employeeDto.FirstName;
                    _context.Entry(employee).Property(e => e.FirstName).IsModified = true;
                }

                if (employeeDto.MiddleName != null)
                {
                    employee.MiddleName = employeeDto.MiddleName;
                    _context.Entry(employee).Property(e => e.MiddleName).IsModified = true;
                }

                if (employeeDto.LastName != null)
                {
                    employee.LastName = employeeDto.LastName;
                    _context.Entry(employee).Property(e => e.LastName).IsModified = true;
                }

                if (employeeDto.Suffix != null)
                {
                    employee.Suffix = employeeDto.Suffix;
                    _context.Entry(employee).Property(e => e.Suffix).IsModified = true;
                }

                if (employeeDto.Position != null)
                {
                    employee.Position = employeeDto.Position;
                    _context.Entry(employee).Property(e => e.Position).IsModified = true;
                }

                if (employeeDto.MonthlyRate != null)
                {
                    employee.MonthlyRate = (decimal)employeeDto.MonthlyRate;
                    _context.Entry(employee).Property(e => e.MonthlyRate).IsModified = true;
                }
                if (employeeDto.OnBoardDate != null)
                {
                    employee.OnBoardDate = (DateTime)employeeDto.OnBoardDate;
                    _context.Entry(employee).Property(e => e.OnBoardDate).IsModified = true;
                }

                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
                return NotFound("Employee not found.");
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
