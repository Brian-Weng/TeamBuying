using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamBuying.DB.ViewModel
{
    public class TeamBuyingView
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public string TeamLeaderName { get; set; }
        public string StoreName { get; set; }
        public string Body { get; set; }
        public DateTime EndDate { get; set; }
    }
}
