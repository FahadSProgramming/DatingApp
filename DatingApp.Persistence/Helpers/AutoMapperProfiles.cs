using AutoMapper;
using DatingApp.Core;
using DatingApp.Persistence.DTO;

namespace DatingApp.Persistence.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, AppUserDTO>();
            CreateMap<Photo, PhotoDTO>();
        }
    }
}
