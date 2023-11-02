using CodeFirst.Data;

namespace CodeFirst.Services
{
    public interface IEmployeeService
    {
        public ValueTask<Employee> GetEmployeeById(int id);
        public ValueTask<IEnumerable<Employee>> GetAllEmployees();
        public ValueTask<int> UpdateEmployee(int id, EmployeeDto employee);
        public ValueTask<int> DeleteEmployee(int id);
        public ValueTask<int> CreateEmployee(EmployeeDto employee);

    }
}
