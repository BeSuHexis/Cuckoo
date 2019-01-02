using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PalmGroupRESTAPIServer.DatabaseRepositories
{
    public interface IGenericRepository<T> where T : class
    {

        IList<T> GetAll();
        List<T> FindBy(Expression<Func<T, bool>> predicate);
        T Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
        void Save();
    }
}
