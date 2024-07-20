namespace ApiTest.Domain.Data.Models
{
    public class Test
    {
        public int Id { get; set; }
        public int ConfigurationId { get; set; }
        public Configuration Configuration { get; set; }
        public DateTime Date { get; set; }
        public string Result { get; set; }
        public string ErrorMessage { get; set; }
    }
}
