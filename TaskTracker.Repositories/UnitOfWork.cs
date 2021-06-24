using AutoMapper;
using TaskTracker.Database.Context;
using TaskTracker.Repositories.Interfaces;

namespace TaskTracker.Repositories
{

    public interface IUnitOfWork
    {
        ITaskRepository TaskRepository { get; }
        IProjectRepository ProjectRepository { get; }
        void Save();
    }
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IMapper _mapper;
        protected readonly TaskTrackerContext _сontext;

        public UnitOfWork(TaskTrackerContext context, IMapper mapper)
        {
            _сontext = context;
            _mapper = mapper;
        }

        public ITaskRepository TaskRepository
        {
            get
            {
                return new TaskRepository(_сontext, _mapper);
            }
        }


        public IProjectRepository ProjectRepository
        {
            get
            {
                return new ProjectRepository(_сontext, _mapper);
            }
        }

        public void Save()
        {
            _сontext.SaveChanges();
        }
    }
}
