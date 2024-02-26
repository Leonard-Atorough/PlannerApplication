using PlannerApplication.Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace PlannerApplication.Core.Entities
{
    public abstract class BaseEntity : IEntity
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int CreatedBy { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        public int LastModifiedBy { get; set; }
        public DateTime LastModifiedOn { get; set; }
    }
}
