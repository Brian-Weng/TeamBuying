using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TeamBuying.ORM.DBModels;

namespace TeamBuying.DB.DBHelper
{
    public class DbContextHelper
    {
        public static ContextModel DbContext()
        {
            var dbContext = HttpContext.Current.Items["DbContext"];
            if (dbContext == null)
                dbContext = new ContextModel();
            return dbContext as ContextModel;
        }
    }
}
