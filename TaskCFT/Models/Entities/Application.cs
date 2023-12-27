namespace TaskCFT.Models.Entities
{
    public class Application
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public List<WorkRequest> WorkRequests { get; set; } = new List<WorkRequest>();

    }
}
