using API.Base;
using BL.Contracts.Services.Custom;
using BL.DTO.Entities;
using Domains.AppMetaData;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs.User;

namespace API.Controllers
{
    [ApiController]
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
        [HttpGet(Router.SettingsRouting.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _settingsService.GetAllAsync();
            return NewResult(result);

        }
        [HttpGet(Router.SettingsRouting.GetById)]
        public async Task<IActionResult> GetById(Guid id )
        {
            var result = await _settingsService.FindByIdAsync(id);
            return NewResult(result);
        }

        [HttpPut(Router.SettingsRouting.Update)]
        public async Task<IActionResult> Update([FromForm] SettingsDTO settingsDTO)
        {
            var result = await _settingsService.SaveAsync(settingsDTO, GuidUserId);
            return NewResult(result);
        }



    }
    #endregion

}

