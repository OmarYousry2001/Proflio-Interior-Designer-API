using API.Base;
using BL.Contracts.Services.Custom;
using BL.DTO.Entities;
using Domains.AppMetaData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs.User;

namespace API.Controllers
{
    [ApiController]
    [Authorize]
    public class ProjectController : AppControllerBase
    {

        #region Fields
        private readonly IProjectService _projectService;
        #endregion

        #region Constructor
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
 
        }
        #endregion

        #region Apis
        /// <summary>
        /// Get all projects with related data.
        /// </summary>
        [AllowAnonymous]
        [HttpGet(Router.ProjectRouting.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _projectService.GetAllWithIncludesAsync();
            return NewResult(result);

        }

        /// <summary>
        /// Get a project by ID with related data.
        /// </summary>
        [AllowAnonymous]
        [HttpGet(Router.ProjectRouting.GetById)]
        public async Task<IActionResult> GetById(Guid id )
        {
            var result = await _projectService.FindByIdWithIncludesAsync(id);
            return NewResult(result);
        }

        /// <summary>
        /// Create a new project.
        /// </summary>
        [HttpPost(Router.ProjectRouting.Create)]
        public async Task<IActionResult> Create([FromForm] ProjectDTO projectDTO)
        {
            var result = await _projectService.SaveAsync(projectDTO, GuidUserId);
            return NewResult(result);
        }

        /// <summary>
        /// Update an existing project.
        /// </summary>
        [HttpPut(Router.ProjectRouting.Update)]
        public async Task<IActionResult> Update([FromForm]  ProjectDTO projectDTO)
        {
            var result = await _projectService.SaveAsync(projectDTO, GuidUserId);
            return NewResult(result);
        }

        /// <summary>
        /// Delete a project by ID.
        /// </summary>
        [HttpDelete(Router.ProjectRouting.Delete)]
        public async Task<IActionResult> Delete(Guid id )
        {
            var result = await _projectService.DeleteAsync(id, GuidUserId);
            return NewResult(result);
        }

        /// <summary>
        /// Get all projects under a specific category.
        /// </summary>
        [AllowAnonymous]
        [HttpGet(Router.ProjectRouting.GetByCategoryId)]
        public async Task<IActionResult> GetByCategoryId(Guid id)
        {
            var result = await _projectService.GetByCategoryId(id);
            return NewResult(result);
        }
        
    }
    #endregion

}

