using AutoFixture;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Logging;
using NSubstitute;
using PlannerApplication.Api.Models.Calendar;
using PlannerApplication.Api.Services;
using PlannerApplication.Core.Entities.CalendarAggregate;
using PlannerApplication.Infrastructure.Data;
using Shouldly;
using TestStack.BDDfy;

namespace PlannerApplication.UnitTests.Api.Endpoints
{
    public class CalendarEndpointTests
    {
        private const string BaseRoute = @"planner/calendar";

        private CreateCalendarRequest? _createCalendarRequest;
        private CreatedAtRoute<CreateCalendarResponse> _response;

        private IRepository<Calendar> _repository;
        private ILogger<CalendarService> _logger;
        private IMapper _mapper;

        [Test]
        public void CreateACalendarTest()
        {
            this.Given(_ => this.AValidCreateCalendarRequest())
                .When(_ => this.TheRequestIsMade())
                .Then(_ => this.A201CreatedResponseIsReturned())
                .And(_ => this.TheResponseResultIsACreateCalendarResponse())
                .BDDfy();
        }

        private void AValidCreateCalendarRequest()
        {
            var fixture = new Fixture();
            _createCalendarRequest = fixture.Create<CreateCalendarRequest>();        
            _repository = Substitute.For<IRepository<Calendar>>();
            _logger = Substitute.For<ILogger<CalendarService>>();
            _mapper = Substitute.For<IMapper>();

            _repository.InsertAsync(Arg.Any<Calendar>()).Returns(new Calendar("test", "tesy")
            {
                CreatedBy = 1
            });

            _mapper.Map<CreateCalendarResponse>(Arg.Any<Calendar>()).Returns(new CreateCalendarResponse()
            {
                CalendarId = 1,
                ContributorId = 1,
                CalendarName = "test"
            });
        }

        private void TheRequestIsMade()
        {
            var calendarService = new CalendarService(_repository, _logger, _mapper);
            var result = calendarService.CreateCalendar(_createCalendarRequest).Result;
            _response = (CreatedAtRoute<CreateCalendarResponse>)result;
        }

        private void A201CreatedResponseIsReturned()
        {
            _response.StatusCode.ShouldBe(201);
        }

        private void TheResponseResultIsACreateCalendarResponse()
        {
            _response.Value.CalendarId.ShouldBe(1);
            _response.Value.ContributorId.ShouldBe(1);
            _response.Value.CalendarName.ShouldBe("test");
        }
    }
}
