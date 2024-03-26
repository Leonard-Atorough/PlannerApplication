using MongoDB.Bson;

namespace PlannerApplication.Core.Interfaces
{
    public interface IEntity
    {
        public ObjectId Id { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? LastModifiedBy { get; set; }
        public DateTime LastModifiedOn { get; set; }

    }
}
