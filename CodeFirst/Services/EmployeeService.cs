global using CodeFirst.Data;
global using CodeFirst.DTO;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst.Services;

public class EmployeeService : IEmployeeService
{
    private EmployeeDbContext dbContext;

    public EmployeeService(EmployeeDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async ValueTask<int> CreateEmployee(EmployeeDto employee)
    {
        var entity = new Employee();
        entity.Name = employee.Name;
        entity.Surname = employee.Surname;
        entity.Email = employee.Email;
        entity.Login = employee.Login;
        entity.Password = employee.Password;
        entity.Role = employee.Role;


        await dbContext.AddAsync(employee);
        return await dbContext.SaveChangesAsync();
    }

    public async ValueTask<int> DeleteEmployee(int id)
    {
        var entity = dbContext.Employees.FirstOrDefaultAsync(x=>x.Id == id);
        if(entity is not null)
        {
            dbContext.Remove(entity);
            return await dbContext.SaveChangesAsync();
        }
        return 0;
    }

    public async ValueTask<IEnumerable<Employee>> GetAllEmployees()
    {
        var employees = await dbContext.Employees.AsNoTracking().ToListAsync();
        return employees;
    }

    public async ValueTask<Employee> GetEmployeeById(int id)
    {
        var employee = await dbContext.Employees.AsNoTracking().FirstOrDefaultAsync(x=>x.Id == id);
        return employee;
    }

    public async ValueTask<int> UpdateEmployee(int id, EmployeeDto employee)
    {
        var entity = await dbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
        if (entity is not null)
        {
            entity.Name = employee.Name;
            entity.Surname = employee.Surname;
            entity.Email = employee.Email;
            entity.Login = employee.Login;
            entity.Password = employee.Password;
            entity.Role = employee.Role;
            entity.ModifyDate = DateTime.Now;





            dbContext.Update(entity);
            return await dbContext.SaveChangesAsync();
        }
        return 0;
    }
}
