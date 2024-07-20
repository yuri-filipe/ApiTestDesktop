using LiteDB;

namespace ApiTest.Domain.Data.Models
{
    public class Parameter
    {
        [BsonId]
        public ObjectId Id { get; set; } = ObjectId.NewObjectId();
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
