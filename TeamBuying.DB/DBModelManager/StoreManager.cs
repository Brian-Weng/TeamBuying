using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TeamBuying.DB.DBHelper;
using TeamBuying.DB.ViewModel;
using TeamBuying.ORM.DBModels;

namespace TeamBuying.DB.DBModelManager
{
    public class StoreManager : IDBManager<Store>
    {
        public IEnumerable<Store> Get()
        {
            try
            {
                var query = DbContextHelper.DbContext().Stores;
                return query;
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                throw;
            }
        }

        public void Create(Store item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Store item)
        {
            throw new NotImplementedException();
        }

        public void Update(Store item)
        {
            throw new NotImplementedException();
        }
    }
}
