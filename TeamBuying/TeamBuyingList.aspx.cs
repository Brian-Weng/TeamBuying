using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TeamBuying
{
    public partial class TeamBuyingList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
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