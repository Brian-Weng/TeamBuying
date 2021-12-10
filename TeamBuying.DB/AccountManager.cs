using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamBuying.ORM.DBModels;
using System.Data.Entity;

namespace TeamBuying.DB
{
    public class AccountManager
    {
        public static Account GetAccount(string account)
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var query =
                        (from item in context.Accounts
                         where item.UserAccount == account
                         select item).Include(o => o.AccountInfo);

                    var obj = query.FirstOrDefault();
                    return obj;
                }
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }
    }
}
