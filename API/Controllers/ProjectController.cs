using API.Base;
using BL.Contracts.Services.Custom;
using BL.DTO.Entities;
using Domains.AppMetaData;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs.User;

namespace API.Controllers
{
    [ApiController]
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
        [HttpGet(Router.ProjectRouting.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _projectService.GetAllWithIncludesAsync();
            return NewResult(result);

        }
        [HttpGet(Router.ProjectRouting.GetById)]
        public async Task<IActionResult> GetById(Guid id )
        {
            var result = await _projectService.FindByIdWithIncludesAsync(id);
            return NewResult(result);
        }
        [HttpPost(Router.ProjectRouting.Create)]
        public async Task<IActionResult> Create([FromForm] ProjectDTO settingsDTO)
        {
            var result = await _projectService.SaveAsync(settingsDTO, GuidUserId);
            return NewResult(result);
        }

        [HttpPut(Router.ProjectRouting.Update)]
        public async Task<IActionResult> Update([FromForm]  ProjectDTO settingsDTO)
        {
            var result = await _projectService.SaveAsync(settingsDTO, GuidUserId);
            return NewResult(result);
        }

        [HttpDelete(Router.ProjectRouting.Delete)]
        public async Task<IActionResult> Update(Guid id )
        {
            var result = await _projectService.DeleteAsync(id, GuidUserId);
            return NewResult(result);
        }


    }
    #endregion

}

