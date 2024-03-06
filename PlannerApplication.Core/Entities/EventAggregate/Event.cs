using PlannerApplication.Core.Entities.Shared;
using PlannerApplication.Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace PlannerApplication.Core.Entities.EventAggregate
{
    public class Event : BaseEntity, IAggregateRoot
    {
        public string EventName { get; private set; }
        public string EventDescription { get; private set; }
        public EventLocation Location { get; private set; }
        public EventTime EventTime { get; private set; }
        public EventStatus EventStatus { get; private set; }

        private readonly List<EventParticipant> _participants = [];
        public IReadOnlyCollection<EventParticipant> Participants => _participants.AsReadOnly();

        public Event(string eventName, string eventDescription, EventLocation location, EventTime eventTime, EventStatus eventStatus)
        {
            EventName = eventName;
            EventDescription = eventDescription;
            Location = location;
            EventTime = eventTime;
            EventStatus = eventStatus;
        }

        public void AddParticipant(EventParticipant participant)
        {
            _participants.Add(participant);
        }

        public void RemoveParticipant(EventParticipant participant)
        {
            _participants.Remove(participant);
        }
    } 
}
