namespace TaskTracker.Model.Requests
{
    /// <summary>
    /// Class for task updation request
    /// </summary>
    public class UpdateTaskRequest : CreateTaskRequest
    {
        public long Id { get; set; }
    }
}
