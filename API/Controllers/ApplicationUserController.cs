using API.Base;
using BL.Abstracts;
using BL.Contracts.GeneralService.CMS;
using BL.DTO.Entities;
using BL.DTO.User;
using Domains.AppMetaData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs.User;

namespace API.Controllers
{
    [ApiController]
    public class ApplicationUserController : AppControllerBase
    {

        #region Fields
        private readonly IApplicationUserService _applicationUserService;
        private readonly ICurrentUserService _currentUserService;
        #endregion

        #region Constructor
        public ApplicationUserController(IApplicationUserService applicationUserService,
           ICurrentUserService currentUserService)
        {
            _applicationUserService = applicationUserService;
            _currentUserService = currentUserService;
        }
        #endregion

        #region Apis
      

        [HttpGet(Router.ApplicationUserRouting.SendResetPassword)]
        public async Task<IActionResult> SendResetPassword(string email)
        {
            return NewResult(await _applicationUserService.SendResetUserPasswordCodeForAngular(email));
        }

        [HttpPost(Router.ApplicationUserRouting.ResetPassword)]
        public async Task<IActionResult> ResetPassword(RestPasswordDTO restPasswordDTO)
        {
            return NewResult(await _applicationUserService.ResetPassword(restPasswordDTO));
        }

        [Authorize]
        [HttpPost(Router.ApplicationUserRouting.ChangePassword)]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto changePasswordDto)
        {
            return NewResult(await _applicationUserService.ChangePasswordAsync(UserId ,changePasswordDto));
        }


        [HttpGet(Router.ApplicationUserRouting.IsAuthenticated)]
        public IActionResult IsAuthenticated()
        {
            if (User.Identity?.IsAuthenticated == true)
            {
                return Ok();
            }

            return Unauthorized();
        }

        [HttpGet(Router.ApplicationUserRouting.GetUserName)]
        public IActionResult GetUserName()
        {
            return NewResult(_currentUserService.GetUserName());

        } 
        #endregion

    }
}

