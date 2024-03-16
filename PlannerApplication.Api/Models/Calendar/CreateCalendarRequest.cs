namespace PlannerApplication.Api.Models.Calendar
{
    public class CreateCalendarRequest
    {
        public int ContributorId { get; set; }
        public string CalenderName { get; set; } = string.Empty;
        public string CalendarDescription { get; set; } = string.Empty;

    }
}
