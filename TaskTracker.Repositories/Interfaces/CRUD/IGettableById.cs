using System.Threading.Tasks;

namespace TaskTracker.Repositories.Interfaces.CRUD
{
    public interface IGettableById<TDto, TModel>
    {
        Task<TDto> GetAsync(long id);
    }
}