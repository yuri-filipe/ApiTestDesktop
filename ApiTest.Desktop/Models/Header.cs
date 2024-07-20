using LiteDB;

namespace ApiTest.Domain.Data.Models
{
    public class Header
    {
        [BsonId]
        public ObjectId Id { get; set; } = ObjectId.NewObjectId();
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
