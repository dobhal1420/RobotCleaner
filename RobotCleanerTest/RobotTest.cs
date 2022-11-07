using RobotCleanerClient;
using RobotCleanerCore;

namespace RobotCleanerTest
{
    public class RobotTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GivenIllegalEmptyCommandRobotInitialized()
        {
            //arrange
            CommandHandler commandHandler = new CommandHandler();
            commandHandler.AddInput(" ");
            commandHandler.AddInput("0 0");

            //act
            Robot robot = new Robot(commandHandler);

            //assert
            Assert.IsNotNull(robot);
        }

        [Test]
        public void GivenEmptyCommandRobotInitialized()
        {
            //arrange
            CommandHandler commandHandler = new CommandHandler();
            commandHandler.AddInput("0");
            commandHandler.AddInput("0 0");

            //act
            Robot robot = new Robot(commandHandler);

            //assert
            Assert.IsNotNull(robot);
        }

        [Test]
        public void GivenEmptyCommandRobotStartPositionSameAsCurrentPosition()
        {
            //arrange
            CommandHandler commandHandler = new CommandHandler();
            commandHandler.AddInput("0");
            commandHandler.AddInput("0 0");
            Robot robot = new Robot(commandHandler);

            //act
            robot.Execute();

            //assert
            Assert.That(robot.CurrentPostion.X, Is.EqualTo(commandHandler.startPosition.X));
            Assert.That(robot.CurrentPostion.Y, Is.EqualTo(commandHandler.startPosition.Y));
        }

        [Test]
        public void GivenOne20StepsCommandRobotPositionShouldMoveBy20Steps()
        {
            //arrange
            CommandHandler commandHandler = new CommandHandler();
            commandHandler.AddInput("1");
            commandHandler.AddInput("0 0");
            commandHandler.AddInput("N 20");
            Robot robot = new Robot(commandHandler);

            //act
            robot.Execute();

            //assert
            Assert.That(robot.CurrentPostion.X, Is.EqualTo(commandHandler.startPosition.X));
            Assert.That(robot.CurrentPostion.Y, Is.EqualTo(commandHandler.startPosition.Y + 20));
            Assert.That(robot.ShowResult(), Is.EqualTo($"=> Cleaned: 20"));
        }

        [Test]
        public void GivenOutOfBoundPositionCommandRobotPositionShouldMoveValidSteps()
        {
            //arrange
            CommandHandler commandHandler = new CommandHandler();
            commandHandler.AddInput("2");
            commandHandler.AddInput("-9999 9990");
            commandHandler.AddInput("N 20");
            commandHandler.AddInput("W 20");
            Robot robot = new Robot(commandHandler);

            //act
            robot.Execute();

            //assert
            Assert.That(robot.CurrentPostion.X, Is.EqualTo(commandHandler.startPosition.X - 1));
            Assert.That(robot.CurrentPostion.Y, Is.EqualTo(commandHandler.startPosition.Y + 10));
            Assert.That(robot.ShowResult(), Is.EqualTo($"=> Cleaned: 11"));
        }

        [Test]
        public void GivenOverlappingPositionCommandRobotPositionShouldMoveValidSteps()
        {
            //arrange
            CommandHandler commandHandler = new CommandHandler();
            commandHandler.AddInput("2");
            commandHandler.AddInput("0 0");
            commandHandler.AddInput("E 10");
            commandHandler.AddInput("W 10");
            Robot robot = new Robot(commandHandler);

            //act
            robot.Execute();

            //assert
            Assert.That(robot.CurrentPostion.X, Is.EqualTo(commandHandler.startPosition.X));
            Assert.That(robot.CurrentPostion.Y, Is.EqualTo(commandHandler.startPosition.Y));
            Assert.That(robot.ShowResult(), Is.EqualTo($"=> Cleaned: 10"));
        }

    }

}
