using Microsoft.AspNetCore.Mvc;
using System;
using WebCore.Areas.Admin.Models.Users;
using WebCore.Services.Share.Admins.Users;
using WebCore.Services.Share.Admins.Users.Dto;
using WebCore.Utils.Config;

namespace WebCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : AdminBaseController
    {
        private readonly IUserService userService;

        public UserController(IServiceProvider serviceProvider, IUserService userService) : base(serviceProvider)
        {
            this.userService = userService;
        }

        public IActionResult Index(int pageIndex = 0)
        {
            UserFilterInput filterInput = GetFilterInSession<UserFilterInput>(ConstantConfig.SessionName.UserSession);
            filterInput.PageNumber = pageIndex;
            var userViewModel = GetViewModel(filterInput);
            return View(userViewModel);
        }

        public IActionResult MainListPartial(UserFilterInput filterInput)
        {
            SetFilterToSession(ConstantConfig.SessionName.UserSession, filterInput);
            var userViewModel = GetViewModel(filterInput);
            return PartialView(userViewModel);
        }

        #region Private Method

        private UserViewModel GetViewModel(UserFilterInput filterInput)
        {
            UserViewModel userViewModel = new UserViewModel();
            userViewModel.PagingResult = userService.GetAll(filterInput);
            return userViewModel;
        }

        #endregion 
    }
}