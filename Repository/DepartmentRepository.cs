using Eyouth1.Models;

namespace Eyouth1.Repository
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(CompanyCtx companyCtx):base(companyCtx)
        {            
        }
        public int GetCount(int id)
        {
            return GetById(id).Employees.Count();
        }

        public IEnumerable<Employee> GetEmployees(int id)
        {
            return companyCtx.Employees.Where(e => e.DeptId == id).ToList();
        }
    }
}
