using API.Dtos;
using API.Entites;
using AutoMapper;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Journal, JournalToReturnDto>()
                .ReverseMap();
        }
    }
}
