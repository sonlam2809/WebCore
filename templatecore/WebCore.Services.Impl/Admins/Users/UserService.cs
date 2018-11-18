﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;
using WebCore.EntityFramework.Repositories;
using WebCore.Entities;
using WebCore.Services.Share.Admins.Users;
using WebCore.Services.Share.Admins.Users.Dto;
using WebCore.Services.Share.SystemConfigs;
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

        public async Task<bool> Add(UserInput addInput)
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

        public PagingResultDto<UserDto> GetAll(UserFilterInput filterInput)
        {
            SetDefaultPageSize(filterInput);

            System.Linq.IQueryable<WebCoreUser> userQuery = userRepository.GetAll();
            var userResult = userQuery
                .ProjectTo<UserDto>(mapper.ConfigurationProvider)
                .PagedQuery(filterInput);

            return userResult;
        }


        public async Task<bool> UpdateInfo(UserInput updateInput)
        {
            WebCoreUser entity = userRepository.GetById(updateInput.Id);

            if (entity == null)
            {
                return false;
            }

            Mapper.Map(updateInput, entity);

            entity.RecordStatus = ConstantConfig.UserRecordStatus.Active;

            entity.ModifiedBy = GetCurrentUserLogin();
            entity.ModifiedDate = DateTime.Now;
            entity.UpdateToken = Guid.NewGuid();
            IdentityResult result = await userManager.UpdateAsync(entity);

            return result.Succeeded;
        }

        public UserInput GetInputById(EntityId<string> entityId)
        {
            WebCoreUser entity = userRepository.GetById(entityId.Id);

            UserInput updateInput = new UserInput();

            if (entity == null)
            {
                return null;
            }

            Mapper.Map(entity, updateInput);

            return updateInput;
        }

        public WebCoreUser GetById(EntityId<string> entityId)
        {
            return userRepository.GetById(entityId.Id);
        }
    }
}