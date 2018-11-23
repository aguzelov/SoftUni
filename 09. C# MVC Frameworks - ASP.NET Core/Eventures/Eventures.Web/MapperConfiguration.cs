using AutoMapper;
using Eventures.Models;
using Eventures.Web.Models.Events;
using Eventures.Web.Models.Orders;

namespace Eventures.Web
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventViewModel>()
                .ForPath(e => e.Order.TicketsCount, opt => opt.Ignore())
                .ForPath(e => e.Order.EventId, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();

            CreateMap<Order, EventWithTicketsCountViewModel>()
                .ForMember(
                    e => e.Name,
                    opt => opt.MapFrom(src => src.Event.Name)
                )
                .ForMember(
                    e => e.End,
                    opt => opt.MapFrom(src => src.Event.End)
                )
                .ForMember(
                    e => e.Start,
                    opt => opt.MapFrom(src => src.Event.Start)
                ).ReverseMap();

            CreateMap<Order, DisplayOrderViewModel>()
                .ForPath(
                e => e.EventName,
                opt => opt.MapFrom(src => src.Event.Name)
                )
                .ForPath(
                e => e.Customer,
                opt => opt.MapFrom(src => src.Customer.UserName)
                ).ReverseMap();
        }
    }
}