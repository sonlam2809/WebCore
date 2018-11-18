using System;
using System.Collections.Generic;
using System.Text;
using WebCore.Utils.ModelHelper;

namespace WebCore.Services.Share.Admins.LanguageDetails.Dto
{
    public class LanguageDetailFilterInput : IPagingFilterDto
    {
        public string LangCode { get; set; }
        public string LanguageKey { get; set; }
        public string LanguageValue { get; set; }
        public int PageNumber { get ; set ; }
        public int PageSize { get ; set ; }
    }
}
