using System;
using TaskTracker.Database;

namespace TaskTracker.Model.Requests
{
    /// <summary>
    /// Class for project creation request
    /// </summary>
    public class CreateProjectRequest
    {
        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime CompletionDate { get; set; }

        public int Priority { get; set; }

        public ProjectStatus Status { get; set; }
    }
}
