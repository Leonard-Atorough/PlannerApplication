using Microsoft.AspNetCore.Http.HttpResults;
using PlannerApplication.Api.Models.Calendar;

namespace PlannerApplication.Api.Services
{
    public interface ICalendarService
    {
        Task<IResult> CreateCalendar(CreateCalendarRequest request);
    }
}