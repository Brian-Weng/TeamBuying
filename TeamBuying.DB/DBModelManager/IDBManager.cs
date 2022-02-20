using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamBuying.ORM.DBModels;

namespace TeamBuying.DB.DBModelManager
{
    public interface IDBManager<T> 
                     where T:class, new()
    {
        IEnumerable<T> Get();
        void Create(T item);
        void Update(T item);
        void Delete(T item);
    }
}
