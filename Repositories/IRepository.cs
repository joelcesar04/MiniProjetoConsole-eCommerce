using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Console.Repositories
{
    public interface IRepository<T> 
        where T : class
    {
        IEnumerable<T> Get();
        T Get(int id);
        void Create(T model);
        void Update(T model);
        void Delete(T model);
    }
}
