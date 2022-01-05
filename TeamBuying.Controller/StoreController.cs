using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamBuying.Controller.ViewModels;
using TeamBuying.DB;

namespace TeamBuying.Controller
{
    public class StoreController
    {
        public List<StoreViewModel> GetStoreDropDownList()
        {
            var storeList = StoreManager.GetStores();
            var storeViewList = new List<StoreViewModel>();

            foreach (var item in storeList)
            {
                var store = new StoreViewModel();
                store.ID = item.ID;
                store.Name = item.Name;
                storeViewList.Add(store);
            }

            return storeViewList;
        }
    }
}
