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
    public class CategoryController : AppControllerBase
    {

        #region Fields
        private readonly ICategoryService _categoryService;
        #endregion

        #region Constructor
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
 
        }
        #endregion

        #region Apis
        [AllowAnonymous]
        [HttpGet(Router.CategoryRouting.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _categoryService.GetAllAsync();
            return NewResult(result);

        }
        [AllowAnonymous]
        [HttpGet(Router.CategoryRouting.GetById)]
        public async Task<IActionResult> GetById(Guid id )
        {
            var result = await _categoryService.FindByIdAsync(id);
            return NewResult(result);
        }
        [HttpPost(Router.CategoryRouting.Create)]
        public async Task<IActionResult> Create(CategoryDTO categoryDTO)
        {
            var result = await _categoryService.SaveAsync(categoryDTO, GuidUserId);
            return NewResult(result);
        }

        [HttpPut(Router.CategoryRouting.Update)]
        public async Task<ActionResult<RegisterDTO>> Update(CategoryDTO categoryDTO)
        {
            var result = await _categoryService.SaveAsync(categoryDTO, GuidUserId);
            return NewResult(result);
        }

        [HttpDelete(Router.CategoryRouting.Delete)]
        public async Task<IActionResult> Delete(Guid id )
        {
            var result = await _categoryService.DeleteAsync(id, GuidUserId);
            return NewResult(result);
        }


    }
    #endregion

}

