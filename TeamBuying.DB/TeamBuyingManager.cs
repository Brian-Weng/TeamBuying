using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamBuying.ORM.DBModels;
using System.Data.Entity;

namespace TeamBuying.DB
{
    public class TeamBuyingManager
    {
        public List<TeamBuying.ORM.DBModels.TeamBuying> GetTeamBuyings()
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var query =
                         context.TeamBuyings
                         .Include(o => o.Account.AccountInfo)
                         .Include(o => o.Store);
                    var obj = query.ToList();
                    return obj;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }

        public void CreateTeamBuying(TeamBuying.ORM.DBModels.TeamBuying teamBuying)
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    teamBuying.CreateDate = DateTime.Now;
                    teamBuying.Status = 0;
                    context.TeamBuyings.Add(teamBuying);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return;
            }
        }
    }
}
