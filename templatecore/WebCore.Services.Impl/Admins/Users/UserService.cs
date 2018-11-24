using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebCore.Entities;
using WebCore.EntityFramework.Repositories;
using WebCore.Services.Share.Admins.Users;
using WebCore.Services.Share.Admins.Users.Dto;
using WebCore.Utils.CollectionHelper;
using WebCore.Utils.Config;
using WebCore.Utils.ModelHelper;

namespace WebCore.Services.Impl.Admins.Users
{
    public class UserService : BaseService, IUserService
    {
        private readonly UserManager<WebCoreUser> userManager;
        private readonly IRepository<WebCoreUser, string> userRepository;
        private readonly IMapper mapper;



        public UserService(IServiceProvider serviceProvider, UserManager<WebCoreUser> userManager, IRepository<WebCoreUser, string> userRepository, IMapper mapper)
            : base(serviceProvider)
        {
            this.userManager = userManager;
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public async Task<bool> Add(UserInfoInput addInput)
        {
            WebCoreUser entity = mapper.Map<WebCoreUser>(addInput);

            entity.CreatedBy = GetCurrentUserLogin();
            entity.CreatedDate = DateTime.Now;
            entity.ModifiedBy = entity.CreatedBy;
            entity.ModifiedDate = entity.CreatedDate;
            entity.UpdateToken = Guid.NewGuid();

            IdentityResult result = await userManager.CreateAsync(entity);
            return result.Succeeded;
        }

        public async Task<bool> Active(EntityId<string> entityId)
        {
            WebCoreUser entity = userRepository.GetById(entityId.Id);

            entity.RecordStatus = ConstantConfig.UserRecordStatus.Active;

            entity.ModifiedBy = GetCurrentUserLogin();
            entity.ModifiedDate = DateTime.Now;
            entity.UpdateToken = Guid.NewGuid();
            IdentityResult result = await userManager.UpdateAsync(entity);

            return result.Succeeded;
        }

        public async Task<bool> Delete(EntityId<string> entityId)
        {
            WebCoreUser entity = userRepository.GetById(entityId.Id);

            entity.RecordStatus = ConstantConfig.UserRecordStatus.Deleted;

            entity.ModifiedBy = GetCurrentUserLogin();
            entity.ModifiedDate = DateTime.Now;
            entity.UpdateToken = Guid.NewGuid();

            IdentityResult result = await userManager.UpdateAsync(entity);
            return result.Succeeded;
        }

        public async Task<bool> InActive(EntityId<string> entityId)
        {
            WebCoreUser entity = userRepository.GetById(entityId.Id);

            entity.RecordStatus = ConstantConfig.UserRecordStatus.InActive;

            entity.ModifiedBy = GetCurrentUserLogin();
            entity.ModifiedDate = DateTime.Now;
            entity.UpdateToken = Guid.NewGuid();

            IdentityResult result = await userManager.UpdateAsync(entity);
            return result.Succeeded;
        }

        public PagingResultDto<UserDto> GetAllByPaging(UserFilterInput filterInput)
        {
            SetDefaultPageSize(filterInput);

            System.Linq.IQueryable<WebCoreUser> userQuery = userRepository.GetAll();

            #region FILTER

            // filter by UserName
            if (filterInput.UserName != null)
            {
                userQuery = userQuery.Where(x => x.UserName.ToLower().Equals(filterInput.UserName.ToLower()));
            }

            // filter by FirstName
            if (filterInput.FirstName != null)
            {
                userQuery = userQuery.Where(x => x.FirstName.ToLower().Contains(filterInput.FirstName.ToLower()));
            }

            // filter by Carrer
            if (filterInput.Carrer != null)
            {
                userQuery = userQuery.Where(x => x.Carrer.ToLower().Contains(filterInput.Carrer.ToLower()));
            }

            #endregion

            PagingResultDto<UserDto> userResult = userQuery
                .ProjectTo<UserDto>(mapper.ConfigurationProvider)
                .PagedQuery(filterInput);

            return userResult;
        }


        public async Task<bool> UpdateInfo(UserInfoInput updateInput)
        {
            WebCoreUser entity = userRepository.GetById(updateInput.Id);

            if (entity == null)
            {
                return false;
            }

            mapper.Map(updateInput, entity);

            entity.RecordStatus = ConstantConfig.UserRecordStatus.Active;

            entity.ModifiedBy = GetCurrentUserLogin();
            entity.ModifiedDate = DateTime.Now;
            entity.UpdateToken = Guid.NewGuid();
            IdentityResult result = await userManager.UpdateAsync(entity);

            return result.Succeeded;
        }

        public UserInfoInput GetInputById(EntityId<string> entityId)
        {
            WebCoreUser entity = userRepository.GetById(entityId.Id);

            UserInfoInput updateInput = new UserInfoInput();

            if (entity == null)
            {
                return null;
            }

            updateInput = mapper.Map<UserInfoInput>(entity);

            return updateInput;
        }

        public UserResetPasswordInput GetResetPasswordInputById(EntityId<string> entityId)
        {
            WebCoreUser entity = userRepository.GetById(entityId.Id);

            UserResetPasswordInput updateInput = new UserResetPasswordInput();

            if (entity == null)
            {
                return null;
            }

            updateInput = mapper.Map<UserResetPasswordInput>(entity);

            return updateInput;
        }


        public WebCoreUser GetById(EntityId<string> entityId)
        {
            return userRepository.GetById(entityId.Id);
        }
    }
}
