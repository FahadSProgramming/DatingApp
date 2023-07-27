using AutoMapper;
using DatingApp.Core;
using DatingApp.Persistence.DTO;
using DatingApp.Persistence.DTO.Authentication;

namespace DatingApp.Persistence.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<RegistrationRequest, AppUser>();
            CreateMap<AppUserDTO, AppUser>();
            CreateMap<AppUser, AppUserDTO>()
                .ForMember(dest => dest.PhotoUrl, 
                           opt => opt.MapFrom(src => 
                           src.Photos.FirstOrDefault(photo => photo.IsMain).Url));
            CreateMap<Photo, PhotoDTO>();
        }
    }
}
