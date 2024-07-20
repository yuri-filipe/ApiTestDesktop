using ApiTest.Domain.Data;
using ApiTest.Domain.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiTest.Domain.Repositories
{
    public class TestRepository : ITestRepository
    {
        private readonly AppDbContext _context;

        public TestRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Parameter>> GetAllParameterAsync()
        {
            return await _context.Parameter.ToListAsync();
        }

        public async Task<Parameter> GetParameterByIdAsync(int id)
        {
            return await _context.Parameter.FindAsync(id);
        }

        public async Task AddParameterAsync(Parameter parameter)
        {
            _context.Parameter.Add(parameter);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateParameterAsync(Parameter parameter)
        {
            _context.Entry(parameter).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteParameterAsync(int id)
        {
            var parameter = await _context.Parameter.FindAsync(id);
            if (parameter != null)
            {
                _context.Parameter.Remove(parameter);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Configuration>> GetAllConfigurationAsync()
        {
            return await _context.Configuration.Include(c => c.Parameters).Include(c => c.Headers).ToListAsync();
        }

        public async Task<Configuration> GetConfigurationByIdAsync(int id)
        {
            return await _context.Configuration.Include(c => c.Parameters).Include(c => c.Headers).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddConfigurationAsync(Configuration configuration)
        {
            _context.Configuration.Add(configuration);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateConfigurationAsync(Configuration configuration)
        {
            _context.Entry(configuration).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteConfigurationAsync(int id)
        {
            var configuration = await _context.Configuration.FindAsync(id);
            if (configuration != null)
            {
                _context.Configuration.Remove(configuration);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Test>> GetAllTestAsync()
        {
            return await _context.Test.Include(t => t.Configuration).ToListAsync();
        }

        public async Task<Test> GetTestByIdAsync(int id)
        {
            return await _context.Test.Include(t => t.Configuration).FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task AddTestAsync(Test test)
        {
            _context.Test.Add(test);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTestAsync(Test test)
        {
            _context.Entry(test).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTestAsync(int id)
        {
            var test = await _context.Test.FindAsync(id);
            if (test != null)
            {
                _context.Test.Remove(test);
                await _context.SaveChangesAsync();
            }
        }
    }
}
