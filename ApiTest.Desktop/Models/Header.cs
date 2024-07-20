using LiteDB;

namespace ApiTest.Domain.Data.Models
{
    public class Header
    {
        [BsonId]
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
