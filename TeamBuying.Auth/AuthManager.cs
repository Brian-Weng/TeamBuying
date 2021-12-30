using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamBuying.ORM.DBModels;
using TeamBuying.DB;
using System.Web.Security;
using Newtonsoft.Json;
using System.Web;

namespace TeamBuying.Auth
{
    public class AuthManager
    {
        /// <summary> 登入功能 </summary>
        /// <param name="account">帳號</param>
        /// <param name="pwd">密碼</param>
        /// <param name="errorMsg">錯誤訊息</param>
        public static void SignIn(string account, string pwd, out string errorMsg)
        {
            // 檢查傳進來的使用者輸入值
            if(string.IsNullOrWhiteSpace(account)||
                string.IsNullOrWhiteSpace(pwd))
            {
                errorMsg = "帳號或密碼不可為空";
                return;
            }

            // 取得帳號密碼資訊
            var user = AccountManager.GetAccount(account);

            // 檢查帳號是否存在
            if(user == null)
            {
                errorMsg = $"此帳號 {account} 不存在";
                return;
            }

            // 確認帳密
            if(string.Compare(user.UserAccount, account, true) == 0 
                && string.Compare(user.Password, pwd, false) == 0)
            {
                // 若帳密正確，使用表單驗證並存入cookie

                GetTicket_And_AddIntoCookies(user);

                HttpContext.Current.Response.Redirect("TeamBuyingList.aspx");

                errorMsg = string.Empty;
            }
            else
            {
                errorMsg = "登入失敗，請確認帳號密碼是否正確";
                return;
            }
        }

        /// <summary> 登出功能 </summary>
        public static void SignOut()
        {
            // 移除瀏覽器的表單驗證
            FormsAuthentication.SignOut();
        }

        /// <summary> 驗證使用者是否已登入 </summary>
        /// <returns></returns>
        public static bool IsAuthenticated()
        {
            var user = GetAccountInfo();
            if(user == null)
            {
                return false;
            }

            return true;
            
        }

        /// <summary> 建立票證並加入到 Cookie </summary>
        /// <param name="account"> DB帳號資訊 </param>
        private static void GetTicket_And_AddIntoCookies(Account account)
        {
            var ticket = new FormsAuthenticationTicket(
                1,  //版本
                account.AccountInfo.Name,   //使用者名稱
                DateTime.Now,   //發行時間
                DateTime.Now.AddMinutes(60),    //有效時間
                false,  // 是否將 Cookie 設定成 Session Cookie (會在瀏覽器關閉後移除)
                //JsonConvert.SerializeObject(account.AccountInfo),   // 將使用者資訊轉成 JSON字串
                account.AccountInfo.Name.ToString(),
                FormsAuthentication.FormsCookiePath     // 儲存 Cookie路徑
                );

            // 將 Ticket 加密
            var encTicket = FormsAuthentication.Encrypt(ticket);

            // 建立新的cookie物件( 此cookie的值 => ticket)
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);

            // 將 含有 Ticket的 cookie物件 寫入 Cookies
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
        
        /// <summary> 取得目前使用者資訊 </summary>
        /// <returns></returns>
        public static string GetAccountInfo()
        {
            var user = HttpContext.Current.User;

            if(user?.Identity?.IsAuthenticated == true)
            {
                var identity = user.Identity as FormsIdentity;

                return identity.Ticket.UserData;
            }

            return null;
        }
    }
}
