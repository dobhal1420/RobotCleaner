using RobotCleanerClient;
using RobotCleanerCore.Helper;

namespace RobotCleanerTest
{
    public class NavigationManagerTests
    {
        private NavigationManager navigationManager;

        [Test]
        public void GivenStartingPointWithSpaceCoordinateValidateCoordinateResult()
        {
            navigationManager = new NavigationManager();
            navigationManager.SetStartPosition("10 22");


            Assert.That(navigationManager.startPosition.X, Is.EqualTo(10));
            Assert.That(navigationManager.startPosition.Y, Is.EqualTo(22));
        }

        [Test]
        public void GivenStartingPointWithNewLineCoordinateValidateCoordinateResult()
        {
            navigationManager = new NavigationManager();

            navigationManager.SetStartPosition("10   \n   22");

            Assert.That(navigationManager.startPosition.X, Is.EqualTo(10));
            Assert.That(navigationManager.startPosition.Y, Is.EqualTo(22));
        }

        [Test]
        public void GivenOneNavigationCommandsResult()
        {
            navigationManager = new NavigationManager();

            navigationManager.SetStartPosition("10 22");
            navigationManager.AddCommand("N 1");

            Assert.That(navigationManager.navigationCommands.Count, Is.EqualTo(1));
        }

        [Test]
        public void GivenMoreThanOneNavigationCommandsResult()
        {
            navigationManager = new NavigationManager();

            navigationManager.SetStartPosition("10 22");
            navigationManager.AddCommand("N 1");
            navigationManager.AddCommand("S 1");
            navigationManager.AddCommand("E 1");

            Assert.That(navigationManager.navigationCommands.Count, Is.EqualTo(3));
        }

        [Test]
        public void GivenIllegalDirectionNavigationCommandsGivesUnknownDirectionResult()
        {
            navigationManager = new NavigationManager();

            navigationManager.SetStartPosition("10 22");
            navigationManager.AddCommand("K 2");


            Assert.That(navigationManager.navigationCommands[0].NavigateTo, Is.EqualTo(Direction.Unknown));
        }

        [Test]
        public void GivenOutOfBoundNavigationCommandsGives9999StepsResult()
        {
            navigationManager = new NavigationManager();

            navigationManager.SetStartPosition("10 22");
            navigationManager.AddCommand("S 20000");


            Assert.That(navigationManager.navigationCommands[0].Steps, Is.EqualTo(9999));
        }

        [Test]
        public void GivenOutOfNegativeBoundNavigationCommandsGives9999StepsResult()
        {
            navigationManager = new NavigationManager();

            navigationManager.SetStartPosition("10 22");
            navigationManager.AddCommand("S 0");


            Assert.That(navigationManager.navigationCommands[0].Steps, Is.EqualTo(1));
        }
    }
}