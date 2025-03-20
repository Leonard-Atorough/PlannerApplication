using MongoDB.Bson;

namespace PlannerApplication.Api.Models.Calendar
{
    public class CreateCalendarResponse
    {
        public ObjectId CalendarId { get; set; }
        public string CalendarName { get; set; } = string.Empty;
        public int ContributorId { get; set; }
    }
}
