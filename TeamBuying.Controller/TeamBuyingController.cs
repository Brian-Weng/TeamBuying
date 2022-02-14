using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamBuying.Controller.ViewModels;
using TeamBuying.DB;

namespace TeamBuying.Controller
{
    public class TeamBuyingController
    {
        public List<TeamBuyingViewModel> GetTeamBuyingViewList()
        {
            var manager = new TeamBuyingManager();
            var list = manager.GetTeamBuyings();
            List<TeamBuyingViewModel> teamBuyingViewList = new List<TeamBuyingViewModel>();
            foreach (var item in list)
            {
                var teamBuyingViewModel = new TeamBuyingViewModel() 
                { 
                    ID = item.ID,
                    Title = item.Title,
                    TeamLeaderName = item.Account.AccountInfo.Name,
                    StoreName = item.Store.Name,
                    Body = item.Body,
                    EndDate = item.EndDate
                };

                teamBuyingViewList.Add(teamBuyingViewModel);
            }

            return teamBuyingViewList;
        }
    }
}
