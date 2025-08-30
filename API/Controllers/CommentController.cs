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

        [HttpGet(Router.CommentRouting.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _commentService.GetAllAsync();
            return NewResult(result);

        }
        [HttpGet(Router.CommentRouting.GetById)]
        public async Task<IActionResult> GetById(Guid id )
        {
            var result = await _commentService.FindByIdAsync(id);
            return NewResult(result);
        }
        [AllowAnonymous]
        [HttpPost(Router.CommentRouting.Create)]
        public async Task<IActionResult> Create(CommentDTO commentDTO)
        {
            var result = await _commentService.SaveAsync(commentDTO, GuidUserId);
            return NewResult(result);
        }

        [HttpPut(Router.CommentRouting.Update)]
        public async Task<ActionResult<RegisterDTO>> Update(CommentDTO commentDTO)
        {
            var result = await _commentService.SaveAsync(commentDTO, GuidUserId);
            return NewResult(result);
        }

        [HttpDelete(Router.CommentRouting.Delete)]
        public async Task<IActionResult> Delete(Guid id )
        {
            var result = await _commentService.DeleteAsync(id, GuidUserId);
            return NewResult(result);
        }


    }
    #endregion

}

