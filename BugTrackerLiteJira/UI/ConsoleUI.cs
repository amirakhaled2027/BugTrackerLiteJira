
using System.Security.Cryptography.X509Certificates;
using BugTrackerLiteJira.Services;

namespace BugTrackerLiteJira.UI
{
    public class ConsoleUI
    {
        private readonly BugService bugService;
        private readonly SaveLoadService saveLoadService;

        public ConsoleUI(BugService bugService, SaveLoadService saveLoadService)
        {
            this.bugService = bugService;
            this.saveLoadService = saveLoadService;
        }

        public void Run()
        {
            ShowWelcome();
            bool running = true;

            while (running)
            {
                ShowMainMenu();
                string option = Console.ReadLine();
                running = HandleMenuOptions(option);
            }
        }

        public void ShowWelcome()
        {
            Console.WriteLine("===================");
            Console.WriteLine("Bug Tracker");
            Console.WriteLine("===================\r\n");
        }

        public void ShowMainMenu()
        {
            Console.WriteLine("\nMenu");
            Console.WriteLine("1.Add a New Bug");
            Console.WriteLine("2.List All Bugs");
            Console.WriteLine("3.Update Bug Status");
            Console.WriteLine("4.Delete a Bug");
            Console.WriteLine("5.Search/Filter Bugs");
            Console.WriteLine("6.Save/Load JSON File");
            Console.WriteLine("7.Exit");
            Console.WriteLine("Choose an option: ");
        }


        private bool HandleMenuOptions(string option)
        {
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
                    saveLoadService.ShowSaveLoadMenu();
                    break;

                case "7":
                    Console.WriteLine("Exiting...");
                    return false;

                default:
                    Console.WriteLine("Please choose a valid option from 1 to 6!");
                    break;
            }
            return true;
        }

    }
}
