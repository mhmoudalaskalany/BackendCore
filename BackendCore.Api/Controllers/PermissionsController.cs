﻿using System.Threading.Tasks;
using BackendCore.Api.Controllers.Base;
using BackendCore.Common.Core;
using BackendCore.Common.DTO.Base;
using BackendCore.Common.DTO.Permission;
using BackendCore.Common.DTO.Permission.Parameters;
using BackendCore.Service.Services.Permission;
using Microsoft.AspNetCore.Mvc;

namespace BackendCore.Api.Controllers
{
    /// <summary>
    /// App Controller
    /// </summary>
    public class PermissionsController : BaseController
    {
        private readonly IPermissionService _permissionService;
        /// <summary>
        /// Constructor
        /// </summary>
        public PermissionsController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }
        /// <summary>
        /// Get By Id 
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IResult> GetAsync(long id)
        {
            var result = await _permissionService.GetByIdAsync(id);
            return result;
        }

        /// <summary>
        /// Get All 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IResult> GetAllAsync()
        {
            var result = await _permissionService.GetAllAsync();
            return result;
        }

        /// <summary>
        /// GetAll Data paged
        /// </summary>
        /// <param name="filter">Filter responsible for search and sort</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<DataPaging> GetPagedAsync([FromBody] BaseParam<PermissionFilter> filter)
        {
            return await _permissionService.GetAllPagedAsync(filter);
        }

        /// <summary>
        /// Add 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IResult> AddAsync([FromBody] AddPermissionDto dto)
        {
            var result = await _permissionService.AddAsync(dto);
            return result;
        }


        /// <summary>
        /// Update  
        /// </summary>
        /// <param name="model">Object content</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IResult> UpdateAsync(AddPermissionDto model)
        {

            return await _permissionService.UpdateAsync(model);
        }
        /// <summary>
        /// Remove  by id
        /// </summary>
        /// <param name="id">PK</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IResult> DeleteAsync(long id)
        {
            return await _permissionService.DeleteAsync(id);
        }

        /// <summary>
        /// Soft Remove  by id
        /// </summary>
        /// <param name="id">PK</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IResult> DeleteSoftAsync(long id)
        {
            return await _permissionService.DeleteSoftAsync(id);
        }


    }
}
