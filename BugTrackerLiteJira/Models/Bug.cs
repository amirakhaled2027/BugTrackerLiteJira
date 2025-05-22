
namespace BugTrackerLiteJira.Model
{
    public class Bug
    {
        public int id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Priority { get; set; }
        public string? Status { get; set; }
        public string? AssignedTo { get; set; }
    }
}
