using System.Linq;
using API.DTO;
using API.Entensions;
using API.Entities;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles(){
            CreateMap<AppUser, MemberDto>()
            .ForMember(d=>d.PhotoUrl, opt => opt.MapFrom( src => src.Photos.FirstOrDefault(x=>x.IsMain).Url))
            .ForMember(destw=>destw.Age, opttt=>opttt.MapFrom(_src=>_src.DateOfBirth.CalculateAge()));
            CreateMap<Photo, PhotoDto>();
        }
    }
}