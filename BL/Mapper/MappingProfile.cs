using AutoMapper;
using BL.DTO.Entities;
using Domains.Entities;

namespace BL.Mapper
{
    public partial class MappingProfile : Profile
    {
        public MappingProfile()
        {

            //CreateMap<TbRefreshToken, RefreshTokenDto>().ReverseMap();
            //CreateMap<ApplicationUser, UserRegistrationDto>().ReverseMap();
            //CreateMap<VwUserProfile, UserProfileViewDto>().ReverseMap();

            #region Product
            //CreateMap<Product, GetProductDTO>()
            //.ForMember(des => des.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
            //.ForMember(des => des.Id, opt => opt.MapFrom(src => src.Id)).ReverseMap();

            //CreateMap<Photo, PhotoDTO>()
            //.ForMember(des => des.ImageName, opt => opt.MapFrom(src => src.ImagePath)).ReverseMap();

            //CreateMap<ProductDTO, Product>().ReverseMap();
            #endregion


            #region Settings 
            CreateMap<Settings, SettingsDTO>()
                .ForMember(dest => dest.LogoName, opt => opt.MapFrom(src => src.Logo))
                .ForMember(dest => dest.PersonPhotoName, opt => opt.MapFrom(src => src.PersonPhoto))
                .ForMember(dest => dest.VideoName, opt => opt.MapFrom(src => src.Video))
                .ForMember(dest => dest.Photo, opt => opt.Ignore())
                .ForMember(dest => dest.PersonPhoto, opt => opt.Ignore())
                .ForMember(dest => dest.Video, opt => opt.Ignore()).ReverseMap();

            #endregion

            #region Category 
            CreateMap<Category, CategoryDTO>().ReverseMap();
            #endregion


            #region Project 

            CreateMap<Project, GetProjectDTO>()
            .ForMember(des => des.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
            .ForMember(des => des.Images, opt => opt.MapFrom(src => src.Images))
            .ForMember(des => des.Id, opt => opt.MapFrom(src => src.Id)).ReverseMap();

            CreateMap<ProjectDTO, Project>().ReverseMap();

            #endregion


            #region Image 
            CreateMap<Image, ImageDTO>()
           .ForMember(des => des.ImgName, opt => opt.MapFrom(src => src.ImgPath)).ReverseMap();    
            #endregion







        }
    }
}
