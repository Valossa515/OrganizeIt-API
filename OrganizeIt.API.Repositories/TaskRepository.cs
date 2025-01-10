using Microsoft.Extensions.Logging;
using OrganizeIt.API.Borders.Database;
using OrganizeIt.API.Borders.Entities;
using OrganizeIt.API.Borders.Repositories;
using OrganizeIt.API.Repositories.Database;
using System.Diagnostics.CodeAnalysis;

namespace OrganizeIt.API.Repositories
{
    [ExcludeFromCodeCoverage]
    public class TaskRepository(IDataBaseFactory dataBaseFactory,
        ILogger<TaskRepository> logger)
        : DatabaseRepository<Tasks, Guid>(dataBaseFactory, logger), ITaskRepository
    {
        public async Task<Tasks?> CreateTaksAysnc(Tasks tasks)
        {
            try
            {
                await InsertOneAsync(tasks);
                return await GetByIdAsync(tasks.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }
    }
}