using System.ComponentModel.DataAnnotations;

namespace TaskTracker.Database
{
    /// <summary>
    /// Task entity
    /// </summary>
    public class Task : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public TaskStatus Status { get; set; }

        public int Priority { get; set; }

        [Required]
        public long ProjectId { get; set; }

    }

    public enum TaskStatus { ToDo, InProgress, Done }
}
