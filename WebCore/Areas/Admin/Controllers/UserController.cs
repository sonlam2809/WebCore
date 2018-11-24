using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebCore.Areas.Admin.Models.Users;
using WebCore.Services.Share.Admins.Users;
using WebCore.Services.Share.Admins.Users.Dto;
using WebCore.Utils.Config;
using WebCore.Utils.ModelHelper;

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

        public IActionResult Index(int pageIndex = 1)
        {
            UserFilterInput filterInput = GetInSession<UserFilterInput>(ConstantConfig.SessionName.UserSession);
            filterInput.PageNumber = pageIndex;
            UserViewModel userViewModel = new UserViewModel()
            {
                PagingResult = userService.GetAll(filterInput),
                FilterInput = filterInput
            };
            return View(userViewModel);
        }

        [HttpPost]
        public IActionResult FilterPartial(UserFilterInput filterInput)
        {
            SetToSession(ConstantConfig.SessionName.UserSession, filterInput);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult MainListPartial()
        {
            UserFilterInput filterInput = GetInSession<UserFilterInput>(ConstantConfig.SessionName.UserSession);
            PagingResultDto<UserDto> pagingResult = userService.GetAll(filterInput);
            return PartialView(pagingResult);
        }

        [HttpGet]
        public IActionResult InputInfoPartial(EntityId<string> idModel = null)
        {
            if (idModel != null && idModel.Id != null)
            {
                UserInfoInput userInput = userService.GetInputById(idModel);
                return PartialView(userInput);
            }
            return Unauthorized();
        }

        [HttpPost]
        public async Task<IActionResult> InputInfoPartial(UserInfoInput userInfoInput)
        {
            Entities.WebCoreUser lastInfo = userService.GetById(userInfoInput);
            if (!userInfoInput.UpdateToken.Equals(lastInfo.UpdateToken.GetValueOrDefault(Guid.Empty)))
            {
                return Ok(new { result = ConstantConfig.WebApiStatusCode.Warning, message = GetLang(ConstantConfig.WebApiResultMessage.UpdateTokenNotMatch) });
            }
            bool user = await userService.UpdateInfo(userInfoInput, lastInfo);
            if (!user)
            {
                return Ok(new { result = ConstantConfig.WebApiStatusCode.Error, message = GetLang(ConstantConfig.WebApiResultMessage.Error) });
            }
            return Ok(new { result = ConstantConfig.WebApiStatusCode.Success, message = GetLang(ConstantConfig.WebApiResultMessage.UpdateSuccess) });
        }
    }
}