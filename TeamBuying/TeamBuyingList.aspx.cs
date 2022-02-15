using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TeamBuying.Auth;
using TeamBuying.Controller;
using TeamBuying.DB;
using TeamBuying.DB.DBModelManager;
using TeamBuying.DB.ViewModel;

namespace TeamBuying
{
    public partial class TeamBuyingList : System.Web.UI.Page
    {
        TeamBuyingObject dbObject = new TeamBuyingObject();
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
            IEnumerable<TeamBuyingView> teamBuyingViews = ((TeamBuyingManager)(dbObject.TeamBuyings)).CovertToView().ToList();

            this.rpTeamBuyings.DataSource = teamBuyingViews;
            this.rpTeamBuyings.DataBind();
        }

        #endregion

        #region Bind
        private void BindStoreName()
        {
            IEnumerable<StoreView> storeViews = ((StoreManager)(dbObject.Stores)).ConvertToView().ToList();
            this.ddlStoreName.DataValueField = "ID";
            this.ddlStoreName.DataTextField = "Name";
            this.ddlStoreName.DataSource = storeViews;
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