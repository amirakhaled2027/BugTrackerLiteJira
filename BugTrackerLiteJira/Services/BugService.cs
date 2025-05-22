using BugTrackerLiteJira.Model;

namespace BugTrackerLiteJira.Services
{
    public class BugService
    {
        private List<Bug> bugs = new List<Bug>();
        private int nextId = 1;

        public List<Bug> Bugs => bugs;

        public void SetInitialBugs(List<Bug> loadedBugs)
        {
            bugs = loadedBugs;
            if (bugs.Any())
                nextId = bugs.Max(b => b.id) + 1;
        }

        //added for unit testing
        public void AddBug(Bug bug)
        {
            bug.id = nextId++;
            bugs.Add(bug);
        }

        //added for unit testing
        public Bug GetBugById(int id)
        {
            return bugs.FirstOrDefault(bug => bug.id == id);
        }

        //added for unit testing
        public void UpdateBugStatus(int id)
        {
            var bug = GetBugById(id);
            if (bug == null)
            {
                return;
            }

            if (bug.Status.Trim().ToLower() == "open")
            {
                bug.Status = "closed";
            }
            else if (bug.Status.Trim().ToLower() == "closed")
            {
                bug.Status = "open";
            }
        }

        //added for unit testing
        public bool DeleteBugById(int id)
        {
            var bugToDelete = bugs.FirstOrDefault(bug => bug.id == id);
            if (bugToDelete != null)
            {
                bugs.Remove(bugToDelete);
                return true;
            }
            return false;
        }


        //Validation Input Method
        private string PromptForRequiredInput(string label)
        {
            string input;

            do
            {
                Console.WriteLine($"{label}: ");
                input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine($"{label} cannot be empty!");
                }
            }
            while (string.IsNullOrWhiteSpace(input));
            return input;
        }


        //Add Bug Method
        public void AddBug()
        {
            Console.WriteLine("Add a new bug:");

            int newId = nextId++;

            string newTitle = PromptForRequiredInput("Title");

            string newDescription = PromptForRequiredInput("Description");

            Console.WriteLine("Priority: High/Medium/Low");
            string newPriority = PromptForRequiredInput("Priority");

            Console.WriteLine("Status: Open/Closed");
            string newStatus = PromptForRequiredInput("Status").Trim().ToLower();
            if (newStatus != "open" && newStatus != "closed")
            {
                Console.WriteLine("Status must be 'Open or 'Closed'");
                return;
            }

            string newAssignedTo = PromptForRequiredInput("Assigned To");

            bugs.Add(new Bug
            {
                id = newId,
                Title = newTitle,
                Description = newDescription,
                Priority = newPriority,
                Status = newStatus,
                AssignedTo = newAssignedTo
            });
        }

        //List All Bugs
        public void ListBugs()
        {
            if (bugs.Count == 0)
            {
                Console.WriteLine("There are no bugs found in the list!");
                return;
            }

            Console.WriteLine($"List of All The Bugs:");
            int index = 1;
            foreach (var bug in bugs)
            {
                Console.WriteLine($"Bug No.{index++}");
                Console.WriteLine($"ID: {bug.id}");
                Console.WriteLine($"Title: {bug.Title}");
                Console.WriteLine($"Description: {bug.Description}");
                Console.WriteLine($"Priority: {bug.Priority}");
                Console.WriteLine($"Status: {bug.Status}");
                Console.WriteLine($"Assigned To: {bug.AssignedTo}");

                Console.WriteLine($"----------------------");
            }
        }

        //Update Bug
        public void UpdateBug()
        {
            Console.WriteLine("Write the Id of the bug you wanna update:");
            int SearchId = int.Parse(Console.ReadLine());

            foreach (var bug in bugs)
            {
                if (SearchId == bug.id)
                {
                    if (bug.Status.Trim().ToLower() == "open")
                    {
                        bug.Status = "closed";
                        Console.WriteLine($"Bug No. {bug.id} has been updated to Closed!");
                    }
                    else if (bug.Status.Trim().ToLower() == "closed")
                    {
                        bug.Status = "open";
                        Console.WriteLine($"Bug No. {bug.id} has been updated to Open!");
                    }
                    else
                    {
                        Console.WriteLine("Unable to update. Status must be either 'open' or 'closed'.");
                    }
                }
            }
        }

        //Delete Bug
        public void DeleteBug()
        {
            Console.WriteLine("Delete Bug by Id:");

            if (!int.TryParse(Console.ReadLine(), out int deletedId))
            {
                Console.WriteLine("Invalid Input. Please enter a valid numeric Id");
                return;
            }

            var bugToDelete = bugs.FirstOrDefault(bug => bug.id == deletedId);

            if (bugToDelete != null)
            {
                bugs.Remove(bugToDelete);
                Console.WriteLine("Bug has been deleted successfully!");
            }
            else
            {
                Console.WriteLine("No bug found with that Id");
            }
        }

        //Search/Filter Bugs
        public void SearchBugs()
        {
            Console.WriteLine("Search bugs by: \n(1) for status, \n(2) for priority, or \n(3) for assignee");
            string search = Console.ReadLine();

            switch (search)
            {
                case "1":
                    Console.WriteLine("Search by status: Open/Closed");
                    string searchStatus = Console.ReadLine().Trim().ToLower();

                    if (searchStatus != "open" && searchStatus != "closed")
                    {
                        Console.WriteLine("Input is invalid. Please enter 'Open' or 'Closed'");
                        break;
                    }

                    bool foundStatus = false;
                    foreach (var bug in bugs)
                    {
                        if (bug.Status.ToLower() == searchStatus)
                        {
                            foundStatus = true;

                            Console.WriteLine($"ID: {bug.id}");
                            Console.WriteLine($"Title: {bug.Title}");
                            Console.WriteLine($"Description: {bug.Description}");
                            Console.WriteLine($"Priority: {bug.Priority}");
                            Console.WriteLine($"Status: {bug.Status}");
                            Console.WriteLine($"Assigned To: {bug.AssignedTo}");
                        }
                    }

                    if (!foundStatus)
                    {
                        Console.WriteLine("No bug found with that status");
                    }
                    break;

                case "2":
                    Console.WriteLine("Search by priority: High/Medium/Low");
                    string searchPriority = Console.ReadLine().Trim().ToLower();

                    if (searchPriority != "high" && searchPriority != "medium" && searchPriority != "low")
                    {
                        Console.WriteLine("Invalid Input. Please enter 'High' or 'Medium' or 'Low'");
                        break;
                    }

                    bool foundPriority = false;
                    foreach (var bug in bugs)
                    {
                        if (bug.Priority.ToLower() == searchPriority)
                        {
                            foundPriority = true;

                            Console.WriteLine($"ID: {bug.id}");
                            Console.WriteLine($"Title: {bug.Title}");
                            Console.WriteLine($"Description: {bug.Description}");
                            Console.WriteLine($"Priority: {bug.Priority}");
                            Console.WriteLine($"Status: {bug.Status}");
                        }
                    }

                    if (!foundPriority)
                    {
                        Console.WriteLine("No bug found with that priority");
                    }
                    break;

                case "3":
                    Console.WriteLine("Enter the name of the assignee you wanna search the bug by:");
                    string searchAssignee = Console.ReadLine().Trim().ToLower();

                    bool foundAssignee = false;

                    foreach (var bug in bugs)
                    {
                        if (bug.AssignedTo.ToLower() == searchAssignee)
                        {
                            foundAssignee = true;

                            Console.WriteLine($"ID: {bug.id}");
                            Console.WriteLine($"Title: {bug.Title}");
                            Console.WriteLine($"Description: {bug.Description}");
                            Console.WriteLine($"Priority: {bug.Priority}");
                            Console.WriteLine($"Status: {bug.Status}");
                        }
                    }

                    if (!foundAssignee)
                    {
                        Console.WriteLine("No bug found with that Assignee");
                    }
                    break;

                default:
                    Console.WriteLine("Please choose a valid option from 1 to 3");
                    break;
            }


        }
    }
}
