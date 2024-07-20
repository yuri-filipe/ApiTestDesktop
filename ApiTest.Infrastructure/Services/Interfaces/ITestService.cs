
using ApiTest.Domain.Data.Models;

namespace ApiTest.Infrastructure.Services
{
    public interface ITestService
    {
        Task<IEnumerable<Configuration>> GetAllConfigurationAsync();
        Task<Configuration> GetConfigurationByIdAsync(int id);
        Task AddConfigurationAsync(Configuration configuration);
        Task UpdateConfigurationAsync(Configuration configuration);
        Task DeleteConfigurationAsync(int id);

        Task<IEnumerable<Test>> GetAllTestAsync();
        Task<Test> GetTestByIdAsync(int id);
        Task AddTestAsync(Test test);
        Task UpdateTestAsync(Test test);
        Task DeleteTestAsync(int id);
    }
}
