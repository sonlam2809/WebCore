using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebCore.Areas.Admin.Models.Users;
using WebCore.Entities;
using WebCore.EntityFramework.Helper;
using WebCore.Services.Share.Admins.Users;
using WebCore.Services.Share.Admins.Users.Dto;
using WebCore.Utils.Attributes;
using WebCore.Utils.Config;
using WebCore.Utils.ModelHelper;

namespace WebCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : AdminBaseController
    {
        private readonly IUserService userService;
        private readonly IUnitOfWork unitOfWork;

        public UserController(IServiceProvider serviceProvider, IUserService userService, IUnitOfWork unitOfWork) : base(serviceProvider)
        {
            this.userService = userService;
            this.unitOfWork = unitOfWork;
        }

        public IActionResult Index(int pageIndex = 1)
        {
            UserFilterInput filterInput = GetFilterInSession<UserFilterInput>(ConstantConfig.SessionName.UserSession);
            filterInput.PageNumber = pageIndex;
            UserViewModel userViewModel = new UserViewModel
            {
                FilterInput = filterInput,
                PagingResult = userService.GetAllByPaging(filterInput)
            };
            InitAdminBaseViewModel(userViewModel);
            return View(userViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult FilterPartial(UserFilterInput filterInput)
        {
            SetFilterToSession(ConstantConfig.SessionName.UserSession, filterInput);
            return RedirectToAction("Index", new { page = 1 });
        }

        [HttpGet]
        public IActionResult ResetPasswordPartial(EntityId<string> idModel = null)
        {
            UserResetPasswordInput input = null;
            if (idModel == null)
            {
                input = new UserResetPasswordInput();
            }
            else
            {
                input = userService.GetResetPasswordInputById(idModel);
            }

            return PartialView(input);
        }

        [HttpGet]
        public IActionResult InputInfoPartial(EntityId<string> idModel = null)
        {
            UserInfoInput input = null;
            if (idModel == null)
            {
                input = new UserInfoInput();
            }
            else
            {
                input = userService.GetInputById(idModel);
            }

            return PartialView(input);
        }

        [HttpPost]
        [ClaimRequirement(ConstantConfig.ClaimValue.BlockUser)]
        public IActionResult InActiveUser(string userId)
        {
            try
            {
                unitOfWork.BeginTransaction();
                userService.InActiveUser(userId);
                unitOfWork.SaveChanges();
                unitOfWork.CommitTransaction();
                return Ok();
            }
            catch (Exception)
            {
                unitOfWork.Rollback();
                throw;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InputInfoPartial(UserInfoInput inputModel)
        {
            if (inputModel.Id != null)
            {
                //update
                WebCoreUser lastInfo = userService.GetById(inputModel);
                if (lastInfo.UpdateToken.GetValueOrDefault(Guid.Empty).Equals(inputModel.UpdateToken))
                {
                    await userService.UpdateInfo(inputModel);
                    return Ok(new { result = ConstantConfig.WebApiStatusCode.Success, message = GetLang(ConstantConfig.WebApiResultMessage.UpdateSuccess) });
                }
                return Ok(new { result = ConstantConfig.WebApiStatusCode.Warning, message = GetLang(ConstantConfig.WebApiResultMessage.UpdateTokenNotMatch) });
            }
            return Ok(new { result = ConstantConfig.WebApiStatusCode.Error, message = GetLang(ConstantConfig.WebApiResultMessage.Error) });
        }

        public IActionResult MainListPartial()
        {
            UserFilterInput filterInput = GetFilterInSession<UserFilterInput>(ConstantConfig.SessionName.UserSession);
            PagingResultDto<UserDto> pagingResult = userService.GetAllByPaging(filterInput);
            return PartialView(pagingResult);
        }


    }
}