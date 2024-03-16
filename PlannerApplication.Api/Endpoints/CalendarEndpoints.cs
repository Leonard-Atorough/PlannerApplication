using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using PlannerApplication.Api.Models.Calendar;
using PlannerApplication.Api.Services;
using PlannerApplication.Core.Entities.CalendarAggregate;
using PlannerApplication.Infrastructure.Data;

namespace PlannerApplication.Api.Endpoints
{
    public static class CalendarEndpoints
    {
        public static void MapCalendarEndpoints(this IEndpointRouteBuilder app)
        {
            var routeGroup = app.MapGroup("planner/calendar");

            routeGroup.MapPost("/v1/create", async Task<IResult> (
                CreateCalendarRequest request,
                IRepository<Calendar> repository,
                ILogger<CalendarService> logger,
                IMapper mapper) => await new CalendarService(
                repository, logger, mapper).CreateCalendar(request));
        }
    }
}
