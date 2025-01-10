using OrganizeIt.API.Borders.Entities;

namespace OrganizeIt.API.Borders.Repositories
{
    public interface ITaskRepository
    {
        Task<Tasks?> CreateTaksAysnc(Tasks tasks);
    }
}