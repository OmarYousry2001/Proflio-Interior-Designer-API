using BL.Contracts.GeneralService.CMS;
using BL.Contracts.IMapper;
using BL.Contracts.Services.Custom;
using BL.DTO.Entities;
using BL.Services.Generic;
using DAL.Contracts.Repositories.Generic;
using Domains.Entities;

namespace BL.Services.Custom
{
    public class CategoryService : BaseService<Category , CategoryDTO>, ICategoryService
    {
        private readonly IFileUploadService _fileUploadService;
        private readonly ITableRepository<Category > _categoryRepository;

        public CategoryService(
            ITableRepository<Category> categoryRepository,
            IFileUploadService fileUploadService,
            IBaseMapper mapper) : base(categoryRepository, mapper)
        {
            _fileUploadService = fileUploadService;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
     
    }
}
