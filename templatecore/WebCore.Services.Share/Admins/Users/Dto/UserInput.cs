using System;
using WebCore.Utils.ModelHelper;

namespace WebCore.Services.Share.Admins.Users.Dto
{
    public class UserInput : UpdateTokenModel<string>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? JoinDate { get; set; }
        public string JobTitle { get; set; }
        public string Contract { get; set; }
        public string Carrer { get; set; }
        public string Password { get; set; }
    }
}
