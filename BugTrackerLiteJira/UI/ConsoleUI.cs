
using BugTrackerLiteJira.Services;

namespace BugTrackerLiteJira.UI
{
    public class ConsoleUI
    {
        private readonly BugService bugService;
        private readonly FileService fileService;

        public ConsoleUI(BugService bugService, FileService fileService)
        {
            this.bugService = bugService;
            this.fileService = fileService;
        }

        public void Run()
        {

            Console.WriteLine("===================");
            Console.WriteLine("Bug Tracker");
            Console.WriteLine("===================\r\n");

            Console.WriteLine("\nMenu");
            Console.WriteLine("1.Add a New Bug");
            Console.WriteLine("2.List All Bugs");
            Console.WriteLine("3.Update Bug Status");
            Console.WriteLine("4.Delete a Bug");
            Console.WriteLine("5.Search/Filter Bugs");
            Console.WriteLine("6.Save/Load JSON File");
            Console.WriteLine("7.Exit");


            bool running = true;

            while (running)
            {
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        bugService.AddBug();
                        break;

                    case "2":
                        bugService.ListBugs();
                        break;

                    case "3":
                        bugService.UpdateBug();
                        break;

                    case "4":
                        bugService.DeleteBug();
                        break;

                    case "5":
                        bugService.SearchBugs();
                        break;

                    case "6":
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
                        break;

                    case "7":
                        Console.WriteLine("Exiting...");
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Please choose a valid option from 1 to 6!");
                        break;
                }
            }
        }
    }
}
