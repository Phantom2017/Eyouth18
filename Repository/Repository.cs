
using Eyouth1.Models;

namespace Eyouth1.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly CompanyCtx companyCtx;

        public Repository(CompanyCtx companyCtx)
        {
            this.companyCtx = companyCtx;
        }
        public void Add(T entity)
        {
            companyCtx.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            companyCtx.Set<T>().Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return companyCtx.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return companyCtx.Set<T>().Find(id);
        }

        //public int Save()
        //{
        //    return companyCtx.SaveChanges();
        //}

        public void Update(T entity)
        {
            companyCtx.Set<T>().Update(entity);
        }
    }
}
