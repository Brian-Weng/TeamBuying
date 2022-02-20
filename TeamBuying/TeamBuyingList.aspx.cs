using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TeamBuying.Auth;
using TeamBuying.DB.DBModelManager;
using TeamBuying.DB.ViewModel;

namespace TeamBuying
{
    public partial class TeamBuyingList : System.Web.UI.Page
    {
        ManagerHandler manager = new ManagerHandler();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ShowPageLayoutByLogined();
            this.BindStoreName();
            this.ShowTeamBuyingList();
            this.EndDateRange();

        }
        protected void lbLogout_Click(object sender, EventArgs e)
        {
            AuthManager.SignOut();
            Response.Redirect("~/Login.aspx");
        }

        #region Show
        private void ShowPageLayoutByLogined()
        {
            string currentUser = AuthManager.GetAccountInfo();
            if (!string.IsNullOrWhiteSpace(currentUser))
            {
                this.lblAccountName.Visible = true;
                this.lblAccountName.Text = $"Welcome, {currentUser}";
                this.lbLogout.Visible = true;
                this.lbLogin.Visible = false;
                this.lbCreateTeam.Visible = true;
            }
        }

        /// <summary> 將TeamBuing資料轉成ViewModel並繫結 </summary>
        private void ShowTeamBuyingList()
        {
            var viewList = manager.TeamBuyings.Get()
                                              .Select(t => new TeamBuyingView
                                              {
                                                  ID = t.ID,
                                                  Title = t.Title,
                                                  TeamLeaderName = t.Account.AccountInfo.Name,
                                                  StoreName = t.Store.Name,
                                                  Body = t.Body,
                                                  EndDate = t.EndDate
                                              }).ToList();

            this.rpTeamBuyings.DataSource = viewList;
            this.rpTeamBuyings.DataBind();
        }

        #endregion

        #region Bind

        /// <summary> 將Store資料轉成ViewModel並繫結</summary>
        private void BindStoreName()
        {
            var storeViewList = manager.Stores.Get()
                                              .Select(s => new StoreView
                                              {
                                                  ID = s.ID,
                                                  Name = s.Name
                                              });
            this.ddlStoreName.DataValueField = "ID";
            this.ddlStoreName.DataTextField = "Name";
            this.ddlStoreName.DataSource = storeViewList;
            this.ddlStoreName.DataBind();
        }
        #endregion

        #region EndDate
        private void EndDateRange()
        {
            var today = DateTime.Today;
            string todayText = today.ToString("yyyy-MM-dd");
            this.endDatePicker.Attributes.Add("min", todayText);
        }
        #endregion

    }
}