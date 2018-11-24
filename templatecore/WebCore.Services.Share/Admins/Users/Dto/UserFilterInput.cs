using System;
using System.Collections.Generic;
using System.Text;
using WebCore.Utils.ModelHelper;

namespace WebCore.Services.Share.Admins.Users.Dto
{
    /// <summary>
    /// Model WebCoreUser
    /// </summary>
    public class UserFilterInput : IPagingFilterDto
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string Carrer { get; set; }
    }
}
