using TaskTracker.Database;

namespace TaskTracker.Model.Responses
{
    /// <summary>
    /// Class for task response request
    /// </summary>
    public class TaskResponse
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public TaskStatus Status { get; set; }

        public int Priority { get; set; }

        public long ProjectId { get; set; }
    }
}
