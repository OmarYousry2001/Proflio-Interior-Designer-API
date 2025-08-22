using BL.Contracts.GeneralService.CMS;
using BL.Contracts.IMapper;
using BL.Contracts.Services.Custom;
using BL.DTO.Entities;
using BL.GenericResponse;
using BL.Services.Generic;
using DAL.Contracts.Repositories.Generic;
using Domains.Entities;

namespace BL.Services.Custom
{
    public class SettingsService : BaseService<Settings, SettingsDTO>, ISettingsService
    {
        private readonly IFileUploadService _fileUploadService;
        private readonly ITableRepository<Settings> _settingsRepository;

        public SettingsService(
            ITableRepository<Settings> settingsRepository,
            IFileUploadService fileUploadService,
            IBaseMapper mapper) : base(settingsRepository, mapper)
        {
            _fileUploadService = fileUploadService;
            _settingsRepository = settingsRepository;
            _mapper = mapper;
        }
        public override async Task<Response<bool>> SaveAsync(SettingsDTO dto, Guid userId)
        {
            if (dto.Photo == null && dto.LogoName == null) return BadRequest<bool>();
            var entity = _mapper.MapModel<SettingsDTO, Settings>(dto);


            if (dto.Photo != null)
            {
                entity.Logo = await _fileUploadService.UploadFileAsync(dto.Photo, "Settings" , dto.LogoName);
            }
            var isSaved = await _settingsRepository.SaveAsync(entity, userId);
            if (isSaved) return Success(true);
            else return BadRequest<bool>();
        }

    }
}
