using BugTrackerLiteJira.Model;
using BugTrackerLiteJira.Services;

namespace BugTracker.UnitTests
{
    public class BugServiceTests
    {

        //Adding Bug Test
        [Fact]
        public void AddBug_ShouldAddBugToList()
        {
            //Arrange
            var bugService = new BugService();
            var newBug = new Bug
            {
                Title = "Test Bug",
                Description = "Test Description",
                Priority = "High",
                Status = "Open",
                AssignedTo = "Developer"
            };

            //Act
            bugService.AddBug(newBug);
            var result = bugService.Bugs;

            //Assert
            Assert.Single(result);
            Assert.Equal("Test Bug", result[0].Title);
            Assert.Equal("Developer", result[0].AssignedTo);
        }

        //Getting Bug By Id Test
        [Fact]
        public void GetById_ShouldReturnCorrectBug()
        {
            //Arrange
            var bugService = new BugService();
            var testBug = new Bug
            {
                Title = "Test Bug",
                Description = "Test Description",
                Priority = "High",
                Status = "Open",
                AssignedTo = "Developer"
            };
            bugService.AddBug(testBug);
            int bugId = bugService.Bugs[0].id;

            //Act
            var result = bugService.GetBugById(bugId);

            //Assert
            Assert.NotNull(result);
            Assert.Equal("Test Bug", result.Title);
            Assert.Equal("High", result.Priority);
        }

        //Updating Bug Test
        [Fact]
        public void updateBug_ShouldModifyExistingBug()
        {
            //Arrange
            var bugService = new BugService();
            var updateBug = new Bug
            { 
                Title = "Test Bug",
                Description = "Test Description",
                Priority = "High",
                Status = "Open",
                AssignedTo = "Developer"
            };
            bugService.AddBug(updateBug);
            int bugId = bugService.Bugs[0].id;

            //Act
            bugService.UpdateBugStatus(bugId);

            //Assert
            var updatedBug = bugService.GetBugById(bugId);
            Assert.Equal("closed", updatedBug.Status);
        }

        //Deleting Bug By Id Test (when it exist)
        [Fact]
        public void DeleteBugById_RemovesBug_WhenIdExists()
        {
            //Arrange
            var bugService = new BugService();
            var bug = new Bug
            {
                Title = "Test Bug",
                Description = "Test Description",
                Priority = "High",
                Status = "Open",
                AssignedTo = "Developer"
            };
            bugService.AddBug(bug);

            //Act
            var addedBugById = bugService.Bugs.First().id;
            var deletedBug = bugService.DeleteBugById(addedBugById);

            //Assert
            Assert.True(deletedBug);
            Assert.Empty(bugService.Bugs);
        }

        //Deleting Bug By Id Test (when it DOES NOT exist)
        [Fact]
        public void DeleteBugById_ReturnsFalse_WhenIdDoesNotExist()
        {
            //Arrange
            var bugService = new BugService();

            //Act
            var deletedBug = bugService.DeleteBugById(1000);

            //Assert
            Assert.False(deletedBug);
        }
    }
}
