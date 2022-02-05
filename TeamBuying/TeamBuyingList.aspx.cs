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
            this.BindEndDate();
            this.ShowList();
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

        private void ShowList()
        {
            List<int> list = new List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            this.rpTeamBuyings.DataSource = list;
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

        private void BindEndDate()
        {
            this.BindEndDateYear();
            this.BindEndDateMonth();
        }

        private void BindEndDateYear()
        {
            // 截止日期的年份只給今年 & 明年
            IEnumerable<int> yearCollection = Enumerable.Range(DateTime.Now.Year, 2);

            // 由於dateYear只是單純整數集合，使用匿名型別方便繫結下拉選單
            var query =
                from item in yearCollection
                select new
                {
                    Year = item,
                    YearText = item + "年"
                };
            var yearList = query.ToList();

            this.ddlYear.DataValueField = "Year";
            this.ddlYear.DataTextField = "YearText";
            this.ddlYear.DataSource = yearList;
            this.ddlYear.DataBind();
        }

        private void BindEndDateMonth()
        {
            var selectedYear = int.Parse(this.ddlYear.SelectedValue);
            // 計算開始月份，選今年從現在月份開始，選明年從1月開始
            var startMonth =
                (DateTime.Now.Year < selectedYear)
                ? 1
                : DateTime.Now.Month;
            // 計算選擇的年份還有幾個月
            var monthCount = 12 - startMonth + 1;
            IEnumerable<int> monthCollection = Enumerable.Range(startMonth, monthCount);
            var query =
                from item in monthCollection
                select new
                {
                    Month = item,
                    MonthText = item + "月"
                };
            var monthList = query.ToList();

            this.ddlMonth.DataValueField = "Month";
            this.ddlMonth.DataTextField = "MonthText";
            this.ddlMonth.DataSource = monthList;
            this.ddlMonth.DataBind();
        }

        #endregion



    }
}