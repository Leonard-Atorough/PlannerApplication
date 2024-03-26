using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using PlannerApplication.Api.Models.Calendar;
using PlannerApplication.Core.Entities.CalendarAggregate;
using PlannerApplication.Infrastructure.Data;

namespace PlannerApplication.Api.Services
{
    public class CalendarService : ICalendarService
    {
        private readonly IRepository<Calendar> _repository;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public CalendarService(IRepository<Calendar> repository, ILogger logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IResult> CreateCalendar(CreateCalendarRequest request)
        {
            var input = _mapper.Map<Calendar>(request);
            var result = await _repository.InsertAsync(input);

            var response = _mapper.Map<CreateCalendarResponse>(result);
            return TypedResults.Created("null",response);
        }
    }
}
