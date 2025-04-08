using Eyouth1.Models;

namespace Eyouth1.Repository
{
    public interface IDepartmentRepository:IRepository<Department>
    {
        int GetCount(int id);
        IEnumerable<Employee> GetEmployees(int id);
    }
}
