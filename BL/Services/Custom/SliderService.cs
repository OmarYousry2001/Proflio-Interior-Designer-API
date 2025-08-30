using BL.Contracts.GeneralService.CMS;
using BL.Contracts.IMapper;
using BL.Contracts.Services.Custom;
using BL.DTO.Entities;
using BL.GenericResponse;
using BL.Services.Generic;
using DAL.Contracts.Repositories.Generic;
using Domains.Entities;
using Microsoft.EntityFrameworkCore;

namespace BL.Services.Custom
{
    public class SliderService : BaseService<Slider, SliderDTO>, ISliderService
    {
        private readonly IFileUploadService _fileUploadService;
        private readonly ITableRepository<Slider> _sliderRepository;

        public SliderService(
            ITableRepository<Slider> sliderRepository,
            IFileUploadService fileUploadService,
            IBaseMapper mapper) : base(sliderRepository, mapper)
        {
            _fileUploadService = fileUploadService;
            _sliderRepository = sliderRepository;
            _mapper = mapper;
        }
        public override async Task<Response<IEnumerable<SliderDTO>>> GetAllAsync()
        {
            var entitiesList = await _sliderRepository.GetTableNoTracking().Where(x => x.CurrentState ==1).OrderBy(x => x.Order).ToListAsync();
            if (entitiesList == null) return NotFound<IEnumerable<SliderDTO>>();
            var dtoList = _mapper.MapList<Slider, SliderDTO>(entitiesList);
             return Success(dtoList);
        }


        public override async Task<Response<bool>> SaveAsync(SliderDTO dto, Guid userId)
        {
            if (dto.Img == null && dto.ImgPath == null) return BadRequest<bool>();
            var entity = _mapper.MapModel<SliderDTO, Slider>(dto);


            if (dto.Img != null)
            {
                entity.ImgPath = await _fileUploadService.UploadFileAsync(dto.Img, "Slider", dto.ImgPath);
            }

            var isSaved = await _sliderRepository.SaveAsync(entity, userId);
            if (isSaved) return Success(true);
            else return BadRequest<bool>();
        }

     
    }
}
