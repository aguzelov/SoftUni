using AutoMapper;
using TeamBuilder.App.Models;
using TeamBuilder.Models;

namespace TeamBuilder.App.Core
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<EventTeamsDto, Event>();
            CreateMap<TeamMembersDto, Team>();
        }
    }
}