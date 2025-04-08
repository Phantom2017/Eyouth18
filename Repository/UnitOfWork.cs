using Eyouth1.Models;

namespace Eyouth1.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CompanyCtx companyCtx;

        public UnitOfWork(CompanyCtx companyCtx)
        {
            this.companyCtx = companyCtx;
            EmployeeRepository= new EmployeeRepository(companyCtx);
            DepartmentRepository= new DepartmentRepository(companyCtx);
        }
        public IEmployeeRepository EmployeeRepository { get; private set; }

        public IDepartmentRepository DepartmentRepository { get; private set; }

        public int Complete()
        {
            return companyCtx.SaveChanges();
        }
    }
}
