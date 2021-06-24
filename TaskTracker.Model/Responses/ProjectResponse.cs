using System;
using TaskTracker.Database;

namespace TaskTracker.Model.Responses
{
    /// <summary>
    /// Class for project response request
    /// </summary>
    public class ProjectResponse
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime CompletionDate { get; set; }

        public int Priority { get; set; }

        public ProjectStatus Status { get; set; }

    }
}
