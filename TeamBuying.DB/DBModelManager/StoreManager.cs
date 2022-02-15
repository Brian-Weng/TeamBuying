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
        public ContextModel Context 
        { 
            get
            {
                var context = HttpContext.Current.Items["DbContext"] as ContextModel;
                return context;
            } 
        }

        public IEnumerable<Store> Get()
        {
            try
            {
                var query = Context.Stores;
                return query;
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                throw;
            }
        }

        public IEnumerable<StoreView> ConvertToView()
        {
            try
            {
                var query =
                    from item in Context.Stores
                    select new StoreView
                    {
                        ID = item.ID,
                        Name = item.Name
                    };
                return query;
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
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
