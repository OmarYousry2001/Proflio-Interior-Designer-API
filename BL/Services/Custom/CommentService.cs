using BL.Contracts.GeneralService.CMS;
using BL.Contracts.IMapper;
using BL.Contracts.Services.Custom;
using BL.DTO.Entities;
using BL.Services.Generic;
using DAL.Contracts.Repositories.Generic;
using Domains.Entities;

namespace BL.Services.Custom
{
    public class CommentService : BaseService<Comment, CommentDTO>, ICommentService
    {
        private readonly IFileUploadService _fileUploadService;
        private readonly ITableRepository<Comment> _commentRepository;

        public CommentService(
            ITableRepository<Comment> commentRepository,
            IFileUploadService fileUploadService,
            IBaseMapper mapper) : base(commentRepository, mapper)
        {
            _fileUploadService = fileUploadService;
            _commentRepository = commentRepository;
            _mapper = mapper;
        }
     
    }
}
