using Eyouth1.Models;

namespace Eyouth1.Repository
{
    public class EmployeeRepository :Repository<Employee>, IEmployeeRepository
    {
        //private readonly CompanyCtx companyCtx;

        public EmployeeRepository(CompanyCtx companyCtx):base(companyCtx)
        {
            //this.companyCtx = companyCtx;
        }

        public Employee GetbyName(string name)
        {
            return companyCtx.Employees.Where(em => em.Name.Contains(name)).FirstOrDefault();
        }
        //public void Add(Employee employee)
        //{
        //    companyCtx.Employees.Add(employee);
        //}

        //public void Delete(Employee employee)
        //{
        //    companyCtx.Employees.Remove(employee);
        //}

        //public IEnumerable<Employee> GetAll()
        //{
        //    return companyCtx.Employees.ToList();
        //}

        //public Employee GetById(int id)
        //{
        //    return companyCtx.Employees.Find(id);
        //}

        //public int Save()
        //{
        //    return companyCtx.SaveChanges();
        //}

        //public void Update(Employee employee)
        //{
        //    companyCtx.Employees.Update(employee);
        //}
    }
}
