using AutoMapper;
using WebCore.Entities;
using WebCore.Services.Share.Admins.Languages.Dto;
using WebCore.Services.Share.Admins.Users.Dto;
using WebCore.Services.Share.Languages.Dto;
using WebCore.Services.Share.SystemConfigs.Dto;
using WebCore.Utils.ModelHelper;

namespace WebCore.Services.Share.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LanguageDetail, Languages.Dto.LanguageDetailDto>();
            CreateMap<ListResult<LanguageDetail>, ListResult<Languages.Dto.LanguageDetailDto>>();

            CreateMap<SystemConfig, SystemConfigDto>();
            CreateMap<ListResult<SystemConfig>, ListResult<SystemConfigDto>>();


            CreateMap<LanguageDetail, LanguageInsertUpdateInput>();
            CreateMap<LanguageInsertUpdateInput, LanguageDetail>();


            CreateMap<WebCoreUser, UserDto>();

            CreateMap<Language, LanguageDto>();

            CreateMap<LanguageDetail, WebCore.Services.Share.Admins.LanguageDetails.Dto.LanguageDetailDto>();
            CreateMap<LanguageDetail, WebCore.Services.Share.Admins.LanguageDetails.Dto.LanguageDetailInput>();
            CreateMap<WebCore.Services.Share.Admins.LanguageDetails.Dto.LanguageDetailInput, LanguageDetail>();


        }
    }
}
