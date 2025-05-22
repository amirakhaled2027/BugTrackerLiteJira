using System;
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
            var bugs = fileService.LoadBugs();

            bugService.SetInitialBugs(bugs);

            var ui = new ConsoleUI(bugService, fileService);
            ui.Run();

        }
    }
}