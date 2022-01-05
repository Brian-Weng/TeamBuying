using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamBuying.ORM.DBModels;

namespace TeamBuying.DB
{
    public class StoreManager
    {
        public static List<Store> GetStores()
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    //var obj = 
                    //    (from item in context.Stores 
                    //     select item).ToList();

                    var obj = context.Stores.ToList();
                    return obj;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }
    }
}
