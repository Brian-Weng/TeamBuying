using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TeamBuying.Auth;

namespace TeamBuying
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //若有驗證Cookie 直接跳轉到List頁
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string accountText = this.txtAccount.Text.Trim();
            string pwdText = this.txtPassword.Text.Trim();

            AuthManager.SignIn(accountText, pwdText, out string msg);

            this.lbMsg.Text = msg;
        }
    }
}