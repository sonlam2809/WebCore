
namespace WebCore.Services.Share.Admins.Languages
{
    using Dto;
    using WebCore.Utils.ModelHelper;

    public interface ILanguageAdminService
    {
        PagingResultDto<LanguageDto> GetAllByPaging(LanguageFilterInput languageFilterInput);
    }
}
