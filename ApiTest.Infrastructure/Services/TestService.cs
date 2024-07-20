

using ApiTest.Domain.Data.Models;
using ApiTest.Domain.Repositories;

namespace ApiTest.Infrastructure.Services
{
    public class TestService : ITestService
    {
        private readonly ITestRepository _testRepository;

        public TestService(ITestRepository testRepository)
        {
            _testRepository = testRepository;
        }

        public async Task<IEnumerable<Configuration>> GetAllConfigurationsAsync()
        {
            return await _testRepository.GetAllConfigurationsAsync();
        }

        public async Task<Configuration> GetConfigurationByIdAsync(int id)
        {
            return await _testRepository.GetConfigurationByIdAsync(id);
        }

        public async Task AddConfigurationAsync(Configuration configuration)
        {
            await _testRepository.AddConfigurationAsync(configuration);
        }

        public async Task UpdateConfigurationAsync(Configuration configuration)
        {
            await _testRepository.UpdateConfigurationAsync(configuration);
        }

        public async Task DeleteConfigurationAsync(int id)
        {
            await _testRepository.DeleteConfigurationAsync(id);
        }

        public async Task<IEnumerable<Test>> GetAllTestsAsync()
        {
            return await _testRepository.GetAllTestsAsync();
        }

        public async Task<Test> GetTestByIdAsync(int id)
        {
            return await _testRepository.GetTestByIdAsync(id);
        }

        public async Task AddTestAsync(Test test)
        {
            await _testRepository.AddTestAsync(test);
        }

        public async Task UpdateTestAsync(Test test)
        {
            await _testRepository.UpdateTestAsync(test);
        }

        public async Task DeleteTestAsync(int id)
        {
            await _testRepository.DeleteTestAsync(id);
        }
    }
}
