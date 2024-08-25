using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PetShop.Models
{
    public class UsersModel
    {
        public UsersModel()
        {
            Id = ObjectId.GenerateNewId().ToString();
            DtCreated = DateTime.UtcNow;
        }

        [BsonId]
        public string Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime DtCreated { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime DtUpdated { get; set; }

        public bool Active { get; set; }

        public bool Deleted { get; set; }

    }
}
