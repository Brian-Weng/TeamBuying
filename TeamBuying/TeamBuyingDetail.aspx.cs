using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TeamBuying.Auth;

namespace TeamBuying
{
    public partial class TeamBuyingDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!AuthManager.IsAuthenticated())
            {
                Response.Redirect("Login.aspx");
            }

            List<int> list = new List<int>() { 1,2,3,4,5,6,7,8};

            this.rpOrderLists.DataSource = list;
            this.rpOrderLists.DataBind();

            this.rpProducts.DataSource = list;
            this.rpProducts.DataBind();
        }
    }
}