using System.Threading;
using System.Threading.Tasks;

namespace TaskTracker.Repositories.Interfaces.CRUD
{
    public interface IUpdatable<TDto, TModel>
    {
        Task<TDto> UpdateAsync(TDto dto, CancellationToken token = default);
    }
}