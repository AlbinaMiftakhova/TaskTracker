using System.Threading.Tasks;

namespace TaskTracker.Repositories.Interfaces.CRUD
{
    public interface ICreatable<TDto, TModel>
    {
        Task<TDto> CreateAsync(TDto dto);
    }
}