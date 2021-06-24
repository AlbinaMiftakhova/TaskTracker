using System;
using TaskTracker.Database;

namespace TaskTracker.Model.DTO
{
    /// <summary>
    /// DTO for <see cref="Project"></see>
    /// </summary>
    public class ProjectDto : BaseDto
    {
        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime CompletionDate { get; set; }

        public int Priority { get; set; }

        public ProjectStatus Status { get; set; }
    }
}
