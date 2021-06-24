namespace TaskTracker.Model.Requests
{
    /// <summary>
    /// Class for project updation request
    /// </summary>
    public class UpdateProjectRequest: CreateProjectRequest
    {
        public long Id { get; set; }
    }
}
