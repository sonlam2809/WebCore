using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebCore.Services.Share.Languages;
using WebCore.Services.Share.SystemConfigs;

namespace WebCore.Helper
{
    public static class HtmlExtension
    {
        public static string Lang(this IHtmlHelper helper, string key)
        {
            var languageService = helper.ViewContext.HttpContext.RequestServices.GetRequiredService<ILanguageProviderService>();
            return languageService.GetlangByKey(key);
        }
        public static string LangFor<TSource>(this IHtmlHelper helper, Expression<Func<TSource, object>> selector, string groupName = "")
        {
            var name = GetMemberName(selector.Body);
            if(String.IsNullOrWhiteSpace(groupName))
            {
                groupName = typeof(TSource).Name;
            }
            return helper.Lang($"LBL_{groupName}_{name}".ToUpper());
        }
        public static string GetSysConfigString(this IHtmlHelper helper, string key)
        {
            var systemConfigService = helper.ViewContext.HttpContext.RequestServices.GetRequiredService<ISystemConfigService>();
            return systemConfigService.GetValueString(key);
        }
        public static decimal GetSysConfigNumber(this IHtmlHelper helper, string key)
        {
            var systemConfigService = helper.ViewContext.HttpContext.RequestServices.GetRequiredService<ISystemConfigService>();
            return systemConfigService.GetValueNumber(key);
        }
        public static bool HasPermission(this IHtmlHelper helper,  string permission)
        {
            var httpContext = helper.ViewContext.HttpContext.RequestServices.GetRequiredService<IHttpContextAccessor>();
            return httpContext.HttpContext.User.Claims.Any(x => x.Value == permission);
        }


        private static string GetMemberName(Expression expression)
        {
            if (expression == null)
            {
                throw new ArgumentException("Expression cannot be null");
            }

            if (expression is MemberExpression)
            {
                // Reference type property or field
                var memberExpression = (MemberExpression)expression;
                return memberExpression.Member.Name;
            }

            if (expression is MethodCallExpression)
            {
                // Reference type method
                var methodCallExpression = (MethodCallExpression)expression;
                return methodCallExpression.Method.Name;
            }

            if (expression is UnaryExpression)
            {
                // Property, field of method returning value type
                var unaryExpression = (UnaryExpression)expression;
                return GetMemberName(unaryExpression);
            }

            throw new ArgumentException("Invalid expression");
        }

        private static string GetMemberName(UnaryExpression unaryExpression)
        {
            if (unaryExpression.Operand is MethodCallExpression)
            {
                var methodExpression = (MethodCallExpression)unaryExpression.Operand;
                return methodExpression.Method.Name;
            }

            return ((MemberExpression)unaryExpression.Operand).Member.Name;
        }
    }
}
