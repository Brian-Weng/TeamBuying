using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TeamBuying.Auth;
using TeamBuying.Controller;
using TeamBuying.DB;

namespace TeamBuying
{
    public partial class TeamBuyingList : System.Web.UI.Page
    {
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

        private void ShowTeamBuyingList()
        {
            TeamBuyingController teamBuyingController = new TeamBuyingController();
            var teamBuyingList = teamBuyingController.GetTeamBuyingViewList();

            this.rpTeamBuyings.DataSource = teamBuyingList;
            this.rpTeamBuyings.DataBind();
        }

        #endregion

        #region Bind
        private void BindStoreName()
        {
            var controller = new StoreController();
            var storeList = controller.GetStoreDropDownList();
            this.ddlStoreName.DataValueField = "ID";
            this.ddlStoreName.DataTextField = "Name";
            this.ddlStoreName.DataSource = storeList;
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