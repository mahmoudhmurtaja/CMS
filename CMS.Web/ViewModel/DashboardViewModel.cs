using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Web.ViewModel
{
    public class DashboardViewModel
    {
        public int UserCount { get; set; }
        public int OrgCount { get; set; }
        public int PostCount { get; set; }
        public int EventCount { get; set; }
    }
}
