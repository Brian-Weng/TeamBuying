using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TeamBuying.DB.ViewModel;
using TeamBuying.ORM;
using TeamBuying.ORM.DBModels;

namespace TeamBuying.DB.DBModelManager
{
    public class ManagerHandler
    {
        private IDBManager<TeamBuying.ORM.DBModels.TeamBuying> _TeamBuyingManager = null;

        private IDBManager<Store> _StoreManager = null;

        public IDBManager<TeamBuying.ORM.DBModels.TeamBuying> TeamBuyings 
        {
            get 
            {
                if (_TeamBuyingManager == null)
                    this._TeamBuyingManager = new TeamBuyingManager();
                return _TeamBuyingManager;
            } 
        }

        public IDBManager<Store> Stores
        {
            get
            {
                if (_TeamBuyingManager == null)
                    this._StoreManager = new StoreManager();
                return _StoreManager;
            }
        }
    }
}
