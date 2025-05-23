

namespace BugTrackerLiteJira.Services
{
    public class SaveLoadService
    {
        private readonly BugService bugService;
        private readonly FileService fileService;

        public SaveLoadService()
        {
            this.bugService = bugService;
            this.fileService = fileService; 
        }

        public void ShowSaveLoadMenu() {
            Console.WriteLine("Do you want to:\n1.Save Data. \n2.Load Data.");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                fileService.SaveBugs(bugService.Bugs);
                Console.WriteLine("Bugs Saved Successfully!");
            }
            else if (choice == "2")
            {
                string path = "bugs.json";
                if (File.Exists(path))
                {
                    var loadedBugs = fileService.LoadBugs();
                    bugService.SetInitialBugs(loadedBugs);
                    Console.WriteLine("Bugs loaded successfully!");
                }
                else
                {
                    Console.WriteLine("No saved file found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid choice. Please select 1 or 2.");
            }
        }
        
    }
}
