using API.Base;
using BL.Contracts.Services.Custom;
using BL.DTO.Entities;
using Domains.AppMetaData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    [ApiController]
    [Authorize]
    public class SettingsController : AppControllerBase
    {

        #region Fields
        private readonly ISettingsService _settingsService;
        #endregion

        #region Constructor
        public SettingsController(ISettingsService settingsService)
        {
            _settingsService = settingsService;
 
        }
        #endregion

        #region Apis
        /// <summary>
        /// Get all settings.
        /// </summary>
        [AllowAnonymous]
        [HttpGet(Router.SettingsRouting.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _settingsService.GetAllAsync();
            return NewResult(result);

        }

        /// <summary>
        /// Get a setting by ID.
        /// </summary>
        [AllowAnonymous]
        [HttpGet(Router.SettingsRouting.GetById)]
        public async Task<IActionResult> GetById(Guid id )
        {
            var result = await _settingsService.FindByIdAsync(id);
            return NewResult(result);
        }

        /// <summary>
        /// Update application settings.
        /// </summary>
        [RequestSizeLimit(60_000_000)] // 60 MB
        [HttpPut(Router.SettingsRouting.Update)]
        public async Task<IActionResult> Update([FromForm] SettingsDTO settingsDTO)
        {
            var result = await _settingsService.SaveAsync(settingsDTO, GuidUserId);
            return NewResult(result);
        }

    }
    #endregion

}

