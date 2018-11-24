using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using WebCore.Areas.Admin.Models;
using WebCore.Services.Share.Languages;
using WebCore.Utils.Config;
using WebCore.Utils.ModelHelper;

namespace WebCore.Areas.Admin.Controllers
{
    public class AdminBaseController : Controller
    {
        protected IServiceProvider serviceProvider;
        private readonly ILanguageProviderService languageService;

        public AdminBaseController(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            languageService = (ILanguageProviderService)serviceProvider.GetService(typeof(ILanguageProviderService));
        }

        protected void InitAdminBaseViewModel(AdminBaseViewModel adminBaseViewModel)
        {

        }

        protected string[] GetAllPermissions()
        {
            if (HttpContext.User == null)
            {
                return new string[0];
            }
            return HttpContext.User.Claims.Where(x => x.Type == ConstantConfig.ClaimType.Permission).Select(x => x.Value).ToArray();
        }

        protected TModel GetInSession<TModel>(string sessionName) where TModel : new()
        {
            try
            {
                string filter = HttpContext.Session.GetString(sessionName);
                if (filter == null)
                {
                    TModel filterModel = new TModel();

                    return filterModel;
                }
                else
                {
                    return JsonConvert.DeserializeObject<TModel>(filter);
                }
            }
            catch
            {
                return new TModel();
            }
        }

        protected IEnumerable<ModelStateErrorModel> GetModelErrors()
        {
            return ModelState
                .Where(x => x.Value.Errors.Any())
                .Select(x => new ModelStateErrorModel()
                {
                    PropertyName = x.Key,
                    ErrorMessages = x.Value.Errors.Select(e => e.ErrorMessage)
                });
        }

        protected void SetToSession(string sessionName, object filterObject)
        {
            string jsonString = JsonConvert.SerializeObject(filterObject);
            HttpContext.Session.SetString(sessionName, jsonString);
        }

        protected bool HasPermission(string permission)
        {
            return HttpContext.User.Claims.Any(x => x.Value == permission);
        }

        protected string GetLang(string code)
        {
            return languageService.GetlangByKey(code);
        }
    }
}