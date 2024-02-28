using PlannerApplication.Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace PlannerApplication.Core.Entities.EventAggregate
{
    public class EventNote: BaseEntity
    {
        [Required]
        public string Content { get; private set; }
        public int ContributorId { get; private set; }
        public int EventId { get; set; }

        public EventNote(string content, int contributorId, int eventId)
        {
            Content = content;
            ContributorId = contributorId;
            EventId = eventId;
        }
    }
}