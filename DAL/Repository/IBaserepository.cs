using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repository
{
    public interface IBaserepository<T> :IRepository<T>where T :class
    {
        List<T> GetUsersDataByManagerId(int id);
    }
}
