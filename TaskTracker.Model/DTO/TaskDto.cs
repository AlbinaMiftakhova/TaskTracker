using TaskTracker.Database;

namespace TaskTracker.Model.DTO
{
    /// <summary>
    /// DTO for <see cref="Task"></see>
    /// </summary>
    public class TaskDto : BaseDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public TaskStatus Status { get; set; }

        public int Priority { get; set; }

        public long ProjectId { get; set; }

    }
}
