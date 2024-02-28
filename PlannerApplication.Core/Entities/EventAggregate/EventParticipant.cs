using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannerApplication.Core.Entities.EventAggregate
{
    public class EventParticipant // Value object - see obsidian note 051
    {
        public  int ParticipantId { get; init; }
        public string ParticipantName { get; init; }

        public EventParticipant(int participantId, string participantName)
        {
            ParticipantId = participantId;
            ParticipantName = participantName;
        }

#pragma warning disable //required by EF Core
        private EventParticipant() { }
    }
}
