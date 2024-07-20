using ApiTest.Domain.Data.Models;
using LiteDB;

namespace ApiTest.Desktop.Services
{
    public class LiteDbCacheService : IDisposable
    {
        private readonly LiteDatabase _database;
        private readonly ILiteCollection<Test> _testsCollection;
        private readonly ILiteCollection<Configuration> _configurationsCollection;
        private readonly ILiteCollection<Parameter> _parametersCollection;
        private readonly ILiteCollection<Header> _headersCollection;

        public LiteDbCacheService(string databasePath)
        {
            _database = new LiteDatabase(databasePath);
            _testsCollection = _database.GetCollection<Test>("tests");
            _configurationsCollection = _database.GetCollection<Configuration>("configurations");
            _parametersCollection = _database.GetCollection<Parameter>("parameters");
            _headersCollection = _database.GetCollection<Header>("headers");
        }

        public void AddTest(Test test)
        {
            _testsCollection.Insert(test);
        }

        public List<Test> GetTests()
        {
            return _testsCollection.Include(t => t.Configuration).FindAll().ToList();
        }

        public void AddConfiguration(Configuration configuration)
        {
            _configurationsCollection.Insert(configuration);
        }

        public List<Configuration> GetConfigurations()
        {
            return _configurationsCollection.Include(c => c.Parameters).Include(c => c.Headers).FindAll().ToList();
        }

        public void Dispose()
        {
            _database.Dispose();
        }
    }
}
