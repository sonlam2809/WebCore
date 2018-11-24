using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
using WebCore.Models;
using WebCore.Services.Share.AppMenus;
using WebCore.Services.Share.SystemConfigs;
using WebCore.Utils.Config;

namespace WebCore.Controllers
{
    public class HomeController : WebCoreBaseController
    {
        private ISystemConfigService systemConfigService;
        private readonly IAppMenuService appMenuService;

        public HomeController(IAppMenuService appMenuService, ISystemConfigService systemConfigService)
        {
            this.appMenuService = appMenuService;
            this.systemConfigService = systemConfigService;
        }

        public IActionResult Index()
        {
            decimal thamSo = systemConfigService.GetValueNumber(ConstantConfig.SystemConfigName.GetValue);
            Utils.ModelHelper.ListResult<Services.Share.AppMenus.Dto.AppMenuDto> menus = appMenuService.GetAllMenuByPermission(GetAllPermissions().ToList());
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
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
