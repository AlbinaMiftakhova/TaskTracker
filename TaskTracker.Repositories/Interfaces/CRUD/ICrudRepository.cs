namespace TaskTracker.Repositories.Interfaces.CRUD
{
    public interface ICrudRepository<TDto, TModel> :
        ICreatable<TDto, TModel>,
        IGettableById<TDto, TModel>,
        IGettable<TDto, TModel>,
        IUpdatable<TDto, TModel>,
        IDeletable
    {        
    }
}