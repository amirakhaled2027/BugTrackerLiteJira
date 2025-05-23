using BugTrackerLiteJira.Services;
using BugTrackerLiteJira.UI;

namespace BugTrackerLiteJira
{
    class Program
    {
        public static void Main(string[] args)
        {
            var bugService = new BugService();
            var fileService = new FileService();
            var saveLoadService = new SaveLoadService();
            var bugs = fileService.LoadBugs();

            bugService.SetInitialBugs(bugs);

            var ui = new ConsoleUI(bugService, saveLoadService);
            ui.Run();

        }
    }
}