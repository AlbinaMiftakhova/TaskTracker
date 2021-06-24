using TaskTracker.Database;

namespace TaskTracker.Model.Requests
{
    /// <summary>
    /// Class for task creation request
    /// </summary>
    public class CreateTaskRequest
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public TaskStatus Status { get; set; }

        public int Priority { get; set; }

        public long ProjectId { get; set; }
    }
}
