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
        /// <summary>
        /// Get all categories.
        /// </summary>
        [AllowAnonymous]
        [HttpGet(Router.CategoryRouting.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _categoryService.GetAllAsync();
            return NewResult(result);

        }

        /// <summary>
        /// Get a category by ID.
        /// </summary>
        [AllowAnonymous]
        [HttpGet(Router.CategoryRouting.GetById)]
        public async Task<IActionResult> GetById(Guid id )
        {
            var result = await _categoryService.FindByIdAsync(id);
            return NewResult(result);
        }

        /// <summary>
        /// Create a new category.
        /// </summary>
        [HttpPost(Router.CategoryRouting.Create)]
        public async Task<IActionResult> Create(CategoryDTO categoryDTO)
        {
            var result = await _categoryService.SaveAsync(categoryDTO, GuidUserId);
            return NewResult(result);
        }

        /// <summary>
        /// Update an existing category.
        /// </summary>
        [HttpPut(Router.CategoryRouting.Update)]
        public async Task<ActionResult<RegisterDTO>> Update(CategoryDTO categoryDTO)
        {
            var result = await _categoryService.SaveAsync(categoryDTO, GuidUserId);
            return NewResult(result);
        }

        /// <summary>
        /// Delete a category by ID.
        /// </summary>
        [HttpDelete(Router.CategoryRouting.Delete)]
        public async Task<IActionResult> Delete(Guid id )
        {
            var result = await _categoryService.DeleteAsync(id, GuidUserId);
            return NewResult(result);
        }


    }
    #endregion

}

