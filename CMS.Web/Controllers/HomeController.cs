using CMS.Web.Data;
using CMS.Web.Models;
using CMS.Web.Services.Homes;
using CMS.Web.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class HomeController : BaseController
    {
        private readonly IHomeService _homeService;
        public HomeController(ApplicationDbContext DB, IHomeService homeService) : base(DB)
        {
            _homeService = homeService;
        }

        public IActionResult Index()
        {
             return View(_homeService.GetDashboardViewModel());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
