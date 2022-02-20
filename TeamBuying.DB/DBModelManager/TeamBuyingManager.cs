using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using TeamBuying.DB.ViewModel;
using TeamBuying.DB.DBHelper;
using TeamBuying.ORM.DBModels;
using System.Web;

namespace TeamBuying.DB.DBModelManager
{
    public class TeamBuyingManager : IDBManager<ORM.DBModels.TeamBuying>
    {
        /// <summary> 查詢DB </summary>
        /// <returns></returns>
        public IEnumerable<ORM.DBModels.TeamBuying> Get()
        {
            try
            {
                var query = DbContextHelper.DbContext().TeamBuyings;
                return query;
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                throw;
            }
        }


        public void Create(ORM.DBModels.TeamBuying item)
        {
            try
            {
                item.CreateDate = DateTime.Now;
                item.Status = 0;
                DbContextHelper.DbContext().SaveChanges();
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
            }
        }

        public void Delete(ORM.DBModels.TeamBuying item)
        {
            throw new NotImplementedException();
        }

        public void Update(ORM.DBModels.TeamBuying item)
        {
            throw new NotImplementedException();
        }
        //資料檢查 處理 儲存 Manager 商業邏輯曾

    }
}
