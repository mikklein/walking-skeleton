using AutoMapper;
using WalkingSkeleton.API.DTO.Admin;
using WalkingSkeleton.API.DTO.User;
using WalkingSkeleton.API.Models;

namespace WalkingSkeleton.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserListDTO>();
            CreateMap<User, UserDetailsDTO>();
            CreateMap<UserLoginDTO, User>();
        }
    }
}