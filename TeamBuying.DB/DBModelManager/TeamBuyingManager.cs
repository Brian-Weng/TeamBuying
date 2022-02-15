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

        public ContextModel Context
        {
            get
            {
                var context = HttpContext.Current.Items["DbContext"] as ContextModel;
                return context;
            }
        }

        /// <summary> 查詢DB </summary>
        /// <returns></returns>
        public IEnumerable<ORM.DBModels.TeamBuying> Get()
        {
            try
            {
                var query = Context.TeamBuyings;
                return query;
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                throw;
            }
        }

        /// <summary> 將EDM轉成頁面顯示的ViewModel </summary>
        /// <returns></returns>
        public IEnumerable<TeamBuyingView> CovertToView()
        {
            try
            {
                var query =
                    from item in Context.TeamBuyings
                    select new TeamBuyingView()
                    {
                        ID = item.ID,
                        Title = item.Title,
                        TeamLeaderName = item.Account.AccountInfo.Name,
                        StoreName = item.Store.Name,
                        Body = item.Body,
                        EndDate = item.EndDate
                    };
                return query;
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }

        public void Create(ORM.DBModels.TeamBuying item)
        {
            try
            {
                item.CreateDate = DateTime.Now;
                item.Status = 0;
                Context.SaveChanges();
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


    }
}
