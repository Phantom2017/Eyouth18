using Eyouth1.Models;

namespace Eyouth1.Repository
{
    public interface IEmployeeRepository:IRepository<Employee>
    {
        Employee GetbyName(string name);
    }
}
