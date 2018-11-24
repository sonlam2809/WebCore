using System;
using System.ComponentModel.DataAnnotations;
using WebCore.Utils.ModelHelper;

namespace WebCore.Services.Share.Admins.Users.Dto
{
    // WebCoreUser
    public class UserInfoInput : UpdateTokenModel<string>
    {
        [Display(Name = "LBL_WEBUSER_FIRSTNAME")]
        [Required(ErrorMessage = "LBL_WEBUSER_FIRSTNAME_REQUIRED")]
        public string FirstName { get; set; }

        [Display(Name = "LBL_WEBUSER_LASTNAME")]
        [Required(ErrorMessage = "LBL_WEBUSER_LASTNAME_REQUIRED")]
        public string LastName { get; set; }

        [Display(Name = "LBL_WEBUSER_JOINDATE")]
        public DateTime? JoinDate { get; set; }

        [Display(Name = "LBL_WEBUSER_JOBTITLE")]
        public string JobTitle { get; set; }

        [Display(Name = "LBL_WEBUSER_CARRER")]
        public string Carrer { get; set; }

        [Display(Name = "LBL_WEBUSER_ADDRESS")]
        public string Address { get; set; }

        [Display(Name = "LBL_WEBUSER_EMAIL")]
        [EmailAddress(ErrorMessage = "LBL_WEBUSER_EMAIL_INVALID")]
        [Required(ErrorMessage = "LBL_WEBUSER_EMAIL_REQUIRED")]
        public string Email { get; set; }

        [Display(Name = "LBL_WEBUSER_PHONENUMBER")]
        public string PhoneNumber { get; set; }
    }
}
