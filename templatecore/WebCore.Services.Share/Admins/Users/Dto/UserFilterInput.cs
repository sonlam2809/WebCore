using System.ComponentModel.DataAnnotations;
using WebCore.Utils.FilterHelper;
using WebCore.Utils.ModelHelper;

namespace WebCore.Services.Share.Admins.Users.Dto
{
    //Model WebCoreUser
    public class UserFilterInput : IPagingFilterDto
    {
        [Filter(FilterComparison.Equal)]
        [EmailAddress(ErrorMessage = "LBL_EMAIL_ADDRESS_INVALID")]
        public string Email { get; set; }

        [Filter(FilterComparison.Contains)]
        public string UserName { get; set; }

        [Filter(FilterComparison.Contains)]
        public string Address { get; set; }

        [Filter(FilterComparison.Equal)]
        public string PhoneNumber { get; set; }

        [Filter(FilterComparison.NoFilter)]
        public int PageNumber { get; set; }

        [Filter(FilterComparison.NoFilter)]
        public int PageSize { get; set; }
    }
}
