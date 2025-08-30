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
    public class CommentController : AppControllerBase
    {
        #region Fields
        private readonly ICommentService _commentService;
        #endregion

        #region Constructor
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
 
        }
        #endregion

        #region Apis
        /// <summary>
        /// Get all comments.
        /// </summary>
        [HttpGet(Router.CommentRouting.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _commentService.GetAllAsync();
            return NewResult(result);

        }

        /// <summary>
        /// Get a comment by ID.
        /// </summary>
        [HttpGet(Router.CommentRouting.GetById)]
        public async Task<IActionResult> GetById(Guid id )
        {
            var result = await _commentService.FindByIdAsync(id);
            return NewResult(result);
        }

        /// <summary>
        /// Create a new comment.
        /// </summary>
        [AllowAnonymous]
        [HttpPost(Router.CommentRouting.Create)]
        public async Task<IActionResult> Create(CommentDTO commentDTO)
        {
            var result = await _commentService.SaveAsync(commentDTO, GuidUserId);
            return NewResult(result);
        }

        /// <summary>
        /// Update an existing comment.
        /// </summary>
        [HttpPut(Router.CommentRouting.Update)]
        public async Task<ActionResult<RegisterDTO>> Update(CommentDTO commentDTO)
        {
            var result = await _commentService.SaveAsync(commentDTO, GuidUserId);
            return NewResult(result);
        }

        /// <summary>
        /// Delete a comment by ID.
        /// </summary>
        [HttpDelete(Router.CommentRouting.Delete)]
        public async Task<IActionResult> Delete(Guid id )
        {
            var result = await _commentService.DeleteAsync(id, GuidUserId);
            return NewResult(result);
        }


    }
    #endregion

}

