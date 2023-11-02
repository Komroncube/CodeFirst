using CodeFirst.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodeFirst.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    // GET: api/<EmployeeController>
    [HttpGet]
    public async ValueTask<IActionResult> Get()
    {
        var employees = await _employeeService.GetAllEmployees();
        return Ok(employees);
    }

    // GET api/<EmployeeController>/5
    [HttpGet("{id}")]
    public async ValueTask<IActionResult> Get(int id)
    {
        var employee = await _employeeService.GetEmployeeById(id);
        return Ok(employee);
    }

    // POST api/<EmployeeController>
    [HttpPost]
    public async ValueTask<IActionResult> Post([FromForm] EmployeeDto employeeDto)
    {
        var res = await _employeeService.CreateEmployee(employeeDto);
        return Ok(res);
    }

    // PUT api/<EmployeeController>/5
    [HttpPut("{id}")]
    public async ValueTask<IActionResult> Put(int id, [FromForm] EmployeeDto employeeDto)
    {
        var res = await _employeeService.UpdateEmployee(id, employeeDto);
        return Ok(res);
    }

    // DELETE api/<EmployeeController>/5
    [HttpDelete("{id}")]
    public async ValueTask<IActionResult> Delete(int id)
    {
        var res = await _employeeService.DeleteEmployee(id);
        return Ok(res);
    }
}
