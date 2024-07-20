namespace ApiTest.Domain.Data.Models
{
    public class Configuration
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Method { get; set; } // GET, POST, PUT, DELETE, etc.
        public string Body { get; set; }
        public List<Parameter> Parameters { get; set; } = new List<Parameter>();
        public List<Header> Headers { get; set; } = new List<Header>();

    }
}
