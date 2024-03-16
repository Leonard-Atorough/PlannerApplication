using AutoMapper;
using PlannerApplication.Api.Models.Calendar;
using PlannerApplication.Core.Entities.CalendarAggregate;

namespace PlannerApplication.Api.Mappers
{
    public class DomainMappingProfile : Profile
    {
        public DomainMappingProfile() 
        {
            CreateMap<CreateCalendarRequest, Calendar>()
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.ContributorId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.CalenderName))
                .ForMember(dest => dest.Description,opt => opt.MapFrom(src => src.CalendarDescription));
            CreateMap<Calendar, CreateCalendarResponse>()
                .ForMember(dest => dest.CalendarName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.CalendarId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ContributorId, opt => opt.MapFrom(src => src.CreatedBy));
        }
    }
}
