using RobotCleanerCore;

namespace RobotCleanerTest
{
    public class RobotTest
    {

        [Test]
        public void GivenEmptyCommandRobotStartPositionSameAsCurrentPosition()
        {
            //arrange
            NavigationManager navigationManager = new NavigationManager();
            navigationManager.SetStartPosition("0 0");
            Robot robot = new Robot(navigationManager);

            //act
            robot.Execute();

            //assert
            Assert.IsNotNull(robot);
            Assert.That(robot.CurrentPostion.X, Is.EqualTo(navigationManager.startPosition.X));
            Assert.That(robot.CurrentPostion.Y, Is.EqualTo(navigationManager.startPosition.Y));
        }

        [Test]
        public void GivenOne20StepsCommandRobotPositionShouldMoveBy20Steps()
        {
            //arrange
            NavigationManager navigationManager = new NavigationManager();
            navigationManager.SetStartPosition("0 0");
            navigationManager.AddCommand("N 20");
            Robot robot = new Robot(navigationManager);

            //act
            robot.Execute();

            //assert
            Assert.That(robot.CurrentPostion.X, Is.EqualTo(navigationManager.startPosition.X));
            Assert.That(robot.CurrentPostion.Y, Is.EqualTo(navigationManager.startPosition.Y + 20));
            Assert.That(robot.ShowResult(), Is.EqualTo($"=> Cleaned: 20"));
        }

        [Test]
        public void GivenOutOfBoundPositionCommandRobotPositionShouldMoveValidSteps()
        {
            //arrange
            NavigationManager navigationManager = new NavigationManager();
            navigationManager.SetStartPosition("-9999 9990");
            navigationManager.AddCommand("N 20");
            navigationManager.AddCommand("W 20");
            Robot robot = new Robot(navigationManager);

            //act
            robot.Execute();

            //assert
            Assert.That(robot.CurrentPostion.X, Is.EqualTo(navigationManager.startPosition.X - 1));
            Assert.That(robot.CurrentPostion.Y, Is.EqualTo(navigationManager.startPosition.Y + 10));
            Assert.That(robot.ShowResult(), Is.EqualTo($"=> Cleaned: 11"));
        }

        [Test]
        public void GivenOverlappingPositionCommandRobotPositionShouldMoveValidSteps()
        {
            //arrange
            NavigationManager navigationManager = new NavigationManager();
            navigationManager.SetStartPosition("0 0");
            navigationManager.AddCommand("E 10");
            navigationManager.AddCommand("W 10");
            Robot robot = new Robot(navigationManager);

            //act
            robot.Execute();

            //assert
            Assert.That(robot.CurrentPostion.X, Is.EqualTo(navigationManager.startPosition.X));
            Assert.That(robot.CurrentPostion.Y, Is.EqualTo(navigationManager.startPosition.Y));
            Assert.That(robot.ShowResult(), Is.EqualTo($"=> Cleaned: 10"));
        }

    }

}
