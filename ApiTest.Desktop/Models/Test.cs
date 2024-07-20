using LiteDB;

namespace ApiTest.Domain.Data.Models
{
    public class Test
    {
        [BsonId]
        public int Id { get; set; }

        [BsonRef("Configurations")]
        public int ConfigurationId { get; set; }
        public Configuration Configuration { get; set; }
        public DateTime Date { get; set; }
        public string Result { get; set; }
        public string ErrorMessage { get; set; }
    }
}
