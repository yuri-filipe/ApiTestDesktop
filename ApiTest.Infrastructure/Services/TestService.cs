

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

        public async Task<IEnumerable<Configuration>> GetAllConfigurationAsync()
        {
            return await _testRepository.GetAllConfigurationAsync();
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

        public async Task<IEnumerable<Test>> GetAllTestAsync()
        {
            return await _testRepository.GetAllTestAsync();
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
