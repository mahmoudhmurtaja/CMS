using CMS.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Web.Services.Homes
{
    public interface IHomeService
    {
        public DashboardViewModel GetDashboardViewModel();
    }
}
