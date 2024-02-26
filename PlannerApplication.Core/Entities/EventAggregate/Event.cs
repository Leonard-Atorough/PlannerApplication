using PlannerApplication.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannerApplication.Core.Entities.EventAggregate
{
    public class Event : BaseEntity, IEntity, IAggregateRoot
    {
        [Required]
        public string EventName { get; private set; }
        public string EventDescription { get; private set; }
        public EventLocation Location { get; private set; }
        [Required]
        public DateTime StartDate { get; private set; }
        [Required]
        public DateTime EndDate { get; private set; }
        public EventStatus EventStatus { get; private set; }

        private readonly List<int> _participants = [];
        public IReadOnlyCollection<int> Participants => _participants.AsReadOnly();

        public Event(string eventName, string eventDescription, EventLocation location, DateTime startDate, DateTime endDate, EventStatus eventStatus)
        {
            EventName = eventName;
            EventDescription = eventDescription;
            Location = location;
            StartDate = startDate;
            EndDate = endDate;
            EventStatus = eventStatus;
        }
    } 
}
