using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TeamBuying.Auth;
using TeamBuying.Controller;

namespace TeamBuying
{
    public partial class TeamBuyingList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ShowPageLayoutByLogined();
            this.BindStoreName();
            this.ShowList();
        }
        protected void lbLogout_Click(object sender, EventArgs e)
        {
            AuthManager.SignOut();
            Response.Redirect("~/Login.aspx");
        }

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

        private void BindStoreName()
        {
            var controller = new StoreController();
            var storeList = controller.GetStoreDropDownList();
            this.ddlStoreName.DataValueField = "ID";
            this.ddlStoreName.DataTextField = "Name";
            this.ddlStoreName.DataSource = storeList;
            this.ddlStoreName.DataBind();
        }

        private void ShowList()
        {
            List<int> list = new List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            this.rpTeamBuyings.DataSource = list;
            this.rpTeamBuyings.DataBind();
        }

    }
}