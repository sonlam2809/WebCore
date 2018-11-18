using System;
using System.Collections.Generic;
using System.Text;
using WebCore.Utils.ModelHelper;

namespace WebCore.Services.Share.Admins.Users.Dto
{
    public class UserFilterInput : IPagingFilterDto
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
