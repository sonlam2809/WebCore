﻿namespace WebCore.Services.Share.Admins.Users
{
    using Dto;
    using System.Threading.Tasks;
    using WebCore.Entities;
    using WebCore.Utils.ModelHelper;

    public interface IUserService
    {
        Task<bool> Add(UserInfoInput addInput);
        Task<bool> UpdateInfo(UserInfoInput updateInput,object obj);
        Task<bool> Delete(EntityId<string> entityId);
        Task<bool> InActive(EntityId<string> entityId);
        Task<bool> Active(EntityId<string> entityId);
        PagingResultDto<UserDto> GetAll(UserFilterInput filterInput);

        WebCoreUser GetById(EntityId<string> entityId);

        UserInfoInput GetInputById(EntityId<string> entityId);
    }
}
