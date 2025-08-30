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
    public class SliderController : AppControllerBase
    {

        #region Fields
        private readonly ISliderService _sliderService;
        #endregion

        #region Constructor
        public SliderController(ISliderService sliderService)
        {
            _sliderService = sliderService;
 
        }
        #endregion

        #region Apis
        [AllowAnonymous]
        [HttpGet(Router.SliderRouting.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _sliderService.GetAllAsync();
            return NewResult(result);

        }

        [HttpGet(Router.SliderRouting.GetById)]
        public async Task<IActionResult> GetById(Guid id )
        {
            var result = await _sliderService.FindByIdAsync(id);
            return NewResult(result);
        }
        [HttpPost(Router.SliderRouting.Create)]
        public async Task<IActionResult> Create([FromForm] SliderDTO sliderDTO)
        {
            var result = await _sliderService.SaveAsync(sliderDTO, GuidUserId);
            return NewResult(result);
        }

        [HttpPut(Router.SliderRouting.Update)]
        public async Task<ActionResult<RegisterDTO>> Update([FromForm]  SliderDTO sliderDTO)
        {
            var result = await _sliderService.SaveAsync(sliderDTO, GuidUserId);
            return NewResult(result);
        }

        [HttpDelete(Router.SliderRouting.Delete)]
        public async Task<IActionResult> Delete(Guid id )
        {
            var result = await _sliderService.DeleteAsync(id, GuidUserId);
            return NewResult(result);
        }
    }
    #endregion

}

