using System;
using System.Collections.Generic;
using System.Text;

namespace DLL.Repository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
       // T Get(long id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
