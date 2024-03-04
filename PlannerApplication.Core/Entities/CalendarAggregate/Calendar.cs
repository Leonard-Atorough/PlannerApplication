using PlannerApplication.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannerApplication.Core.Entities.CalendarAggregate
{
    public class Calendar: BaseEntity, IAggregateRoot
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        private List<int?> _participants = new List<int?>();
        public IReadOnlyCollection<int?> Participants => _participants.AsReadOnly();

        private List<CalendarEvent> _calendarEvents = new List<CalendarEvent>();
        public IReadOnlyCollection<CalendarEvent> CalendarEvents => _calendarEvents.AsReadOnly();

        public Calendar(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public void AddCalendarEvent(CalendarEvent calendarEvent)
        {
            _ = calendarEvent ?? throw new ArgumentNullException();

            _calendarEvents.Add(calendarEvent);

        }

        public void AddParticipant(int? participantId)
        {
            _ = participantId ?? throw new ArgumentNullException(Name + nameof(participantId));

            _participants.Add(participantId);
        }
    }
}
