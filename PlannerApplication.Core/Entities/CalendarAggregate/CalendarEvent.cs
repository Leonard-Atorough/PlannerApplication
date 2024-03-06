using PlannerApplication.Core.Entities.Shared;

namespace PlannerApplication.Core.Entities.CalendarAggregate
{
    public class CalendarEvent : BaseEntity
    {
        public string EventName { get; set; }
        public EventTime EventTime { get; set; }
        public EventStatus EventStatus { get; set; }

        public CalendarEvent(string eventName, EventTime eventTime, EventStatus eventStatus)
        {
            EventName = eventName;
            EventTime = eventTime;
            EventStatus = eventStatus;
        }
    }
}
