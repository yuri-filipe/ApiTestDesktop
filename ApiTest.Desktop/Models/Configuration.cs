using LiteDB;

namespace ApiTest.Domain.Data.Models
{
    public class Configuration
    {
        [BsonId]
        public ObjectId Id { get; set; } = ObjectId.NewObjectId();
        public string Url { get; set; }
        public string Method { get; set; } // GET, POST, PUT, DELETE, etc.
        public string Body { get; set; }
        [BsonRef("Parameters")]
        public List<Parameter> Parameters { get; set; } = new List<Parameter>();
        [BsonRef("Headers")]
        public List<Header> Headers { get; set; } = new List<Header>();
    }
}
