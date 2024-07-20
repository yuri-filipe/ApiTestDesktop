using ApiTest.Domain.Data.Models;

namespace ApiTest.Domain.Repositories
{
    public interface ITestRepository
    {
        Task<IEnumerable<Parameter>> GetAllParametersAsync();
        Task<Parameter> GetParameterByIdAsync(int id);
        Task AddParameterAsync(Parameter parameter);
        Task UpdateParameterAsync(Parameter parameter);
        Task DeleteParameterAsync(int id);

        Task<IEnumerable<Configuration>> GetAllConfigurationsAsync();
        Task<Configuration> GetConfigurationByIdAsync(int id);
        Task AddConfigurationAsync(Configuration configuration);
        Task UpdateConfigurationAsync(Configuration configuration);
        Task DeleteConfigurationAsync(int id);

        Task<IEnumerable<Test>> GetAllTestsAsync();
        Task<Test> GetTestByIdAsync(int id);
        Task AddTestAsync(Test test);
        Task UpdateTestAsync(Test test);
        Task DeleteTestAsync(int id);
    }
}
