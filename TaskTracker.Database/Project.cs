using System;
using System.ComponentModel.DataAnnotations;

namespace TaskTracker.Database
{
    /// <summary>
    /// Project entity
    /// </summary>
    public class Project: BaseEntity
    {
        [Required]
        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime CompletionDate { get; set; }

        public int Priority { get; set; }

        public ProjectStatus Status { get; set; }
    }
    public enum ProjectStatus { NotStarted, Active, Completed }
}
