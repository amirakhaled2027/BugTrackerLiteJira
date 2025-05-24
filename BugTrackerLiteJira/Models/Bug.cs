using static BugTrackerLiteJira.Models.BugEnums;

namespace BugTrackerLiteJira.Model
{
    public class Bug
    {
        public int id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }
        public string? AssignedTo { get; set; }


        public DateTime DateReported { get; set; } = DateTime.Now;
        public string ReporterName { get; set; } = "Unknown";
        public List<string> Comments { get; set; } = new List<string>();
    }
}
