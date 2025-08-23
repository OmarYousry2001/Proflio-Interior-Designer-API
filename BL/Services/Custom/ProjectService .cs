using BL.Contracts.GeneralService.CMS;
using BL.Contracts.IMapper;
using BL.Contracts.Services.Custom;
using BL.DTO.Entities;
using BL.GenericResponse;
using BL.Services.Generic;
using DAL.Contracts.UnitOfWork;
using Domains.Entities;

namespace BL.Services.Custom
{
    public class ProjectService : BaseService<Project, ProjectDTO>, IProjectService
    {
        private readonly IFileUploadService _fileUploadService;
        private readonly IUnitOfWork _unitOfWork;

        public ProjectService(
        IFileUploadService fileUploadService,
        IUnitOfWork unitOfWork,
        IBaseMapper mapper) : base(unitOfWork.TableRepository<Project>(), mapper)
        {
            _fileUploadService = fileUploadService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

       public async Task<Response<IEnumerable<GetProjectDTO>>> GetAllWithIncludesAsync()
               {
                   var entitiesList = await _unitOfWork.TableRepository<Project>().GetAsync(
                     x => x.CurrentState == 1,
                     x => x.Category,
                     x => x.Images
                   );
                   if (entitiesList == null) return NotFound<IEnumerable<GetProjectDTO>>();
                   var dtoList = _mapper.MapList<Project, GetProjectDTO>(entitiesList);
                   return Success(dtoList);
               }
       public async Task<Response<GetProjectDTO>> FindByIdWithIncludesAsync(Guid Id)
         {
             var entity = await _unitOfWork.TableRepository<Project>().FindAsync(
           x => x.CurrentState == 1 && x.Id == Id,
           x => x.Category,
           x => x.Images
          );
             if (entity == null) return NotFound<GetProjectDTO>();
             var dto = _mapper.MapModel<Project, GetProjectDTO>(entity);
             return Success(dto);
         }
       public override async Task<Response<bool>> SaveAsync(ProjectDTO entityDTO, Guid userId)
                {
                    using var transaction = await _unitOfWork.BeginTransactionAsync();
                    try
                    {
                        if (entityDTO.Photos == null && entityDTO.ImageName == null) return BadRequest<bool>("pelase Enter Image ");

                        var entity = _mapper.MapModel<ProjectDTO, Project >(entityDTO);
                        await _unitOfWork.TableRepository<Project>().SaveAsync(entity, userId);

                        if (entityDTO.Photos?.Any() == true)
                        {
                            var imagePaths = await _fileUploadService.AddImagesAsync(entityDTO.Photos, "Projects", entityDTO.Title, entityDTO.ImageName);
                            var photos = imagePaths.Select(path => new Image
                            {
                                ImgPath = path,
                                ProjectId = entity.Id

                            }).ToList();

                            await _unitOfWork.TableRepository<Image>().AddRangeAsync(photos, userId);

                        }
                        await transaction.CommitAsync();
                        return Success(true);
                    }

                    catch (Exception)
                    {
                        await transaction.RollbackAsync();
                        throw;
                    }



                }

    }
}
