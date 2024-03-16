namespace PlannerApplication.Api.Models.Calendar
{
    public class CreateCalendarResponse
    {
        public int CalendarId { get; set; }
        public string CalendarName { get; set; } = string.Empty;
        public int ContributorId { get; set; }
    }
}
