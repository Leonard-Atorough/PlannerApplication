using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using PlannerApplication.Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace PlannerApplication.Core.Entities
{
    public abstract class BaseEntity : IEntity
    {
        [BsonId, BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? LastModifiedBy { get; set; }
        public DateTime LastModifiedOn { get; set; }
    }
}
