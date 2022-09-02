using CMS.Web.Data;
using CMS.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Web.Services.Homes
{
    public class HomeService : IHomeService
    {
        private readonly ApplicationDbContext _DB;
        public HomeService(ApplicationDbContext DB)
        {
            _DB = DB;
        }
        public DashboardViewModel GetDashboardViewModel()
        {
            var result = new DashboardViewModel();
            result.UserCount = _DB.Users.Count(x => !x.IsDelete);
            result.OrgCount = _DB.Organizations.Count(x => !x.IsDelete);
            result.PostCount = _DB.Posts.Count(x => !x.IsDelete);
            result.EventCount = _DB.Events.Count(x => !x.IsDelete);
            return (result);
        }
    }
}
