
using System.Text.Json;
using System.Text.Json.Serialization;
using BugTrackerLiteJira.Model;

namespace BugTrackerLiteJira.Services
{
    public class FileService
    {
        //private readonly string filePath = "bugs.json";
        private readonly string filePath = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "bugs.json");



        //Loading Data (deserialization)
        public List<Bug> LoadBugs()
        {
            if (!File.Exists(filePath))
                return new List<Bug>();

            string json = File.ReadAllText(filePath);

            var options = new JsonSerializerOptions
            {
                Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) },
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<List<Bug>>(json, options) ?? new List<Bug>();
        }

        //Saving Data to JSON (serlialization)
        public void SaveBugs(List<Bug> bugs)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(bugs, options);
            File.WriteAllText(filePath, json);
        }
    }
}
