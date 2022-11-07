using RobotCleanerClient;
using RobotCleanerCore.Helper;

namespace RobotCleanerTest
{
    public class Tests
    {
        private CommandHandler? _commandHandler;


        [Test]
        public void GivenOneCommandSuccessCommandsValidResult()
        {
            _commandHandler = new CommandHandler();

            /*
                1
                10 22
                E 2
             */

            _commandHandler.AddInput("1");
            _commandHandler.AddInput("10 22");
            _commandHandler.AddInput("E 2");

            Assert.IsTrue(_commandHandler.NumberOfCommand == 1);
        }

        [Test]
        public void GivenTwoCommandsSuccessCommandsValidResult()
        {
            _commandHandler = new CommandHandler();

            _commandHandler.AddInput("2");
            _commandHandler.AddInput("10 22");
            _commandHandler.AddInput("E 2");
            _commandHandler.AddInput("N 1");

            Assert.IsTrue(_commandHandler.NumberOfCommand == 2);
        }

        [Test]
        public void GivenZeroCommandSuccessCommandsValidResult()
        {
            _commandHandler = new CommandHandler();

            _commandHandler.AddInput("0");
            _commandHandler.AddInput("10 22");

            Assert.IsTrue(_commandHandler.NumberOfCommand == 0);
        }

        [Test]
        public void GivenTenThousandCommandSuccessCommandsValidResult()
        {
            _commandHandler = new CommandHandler();

            _commandHandler.AddInput("10000");
            _commandHandler.AddInput("10 22");
            for (int i = 0; i < 10000; i++)
            {
                _commandHandler.AddInput("N 1");
            }

            Assert.IsTrue(_commandHandler.NumberOfCommand == 10000);
        }
        [Test]
        public void GivenNegativeIntegerCommandSuccessCommandsValidResult()
        {
            _commandHandler = new CommandHandler();

            // Should Gracefully handles this negative scenario without throwing any error.
            _commandHandler.AddInput("-5");
            _commandHandler.AddInput("10 22");


            for (int i = 0; i < 10000; i++)
            {
                _commandHandler.AddInput("N 1");
            }

            Assert.IsTrue(_commandHandler.NumberOfCommand == 0);
        }

        [Test]
        public void GivenMoreThanTenThousandsCommandSuccessCommandsValidResult()
        {
            _commandHandler = new CommandHandler();

            // Should Gracefully handles this negative scenario without throwing any error.
            _commandHandler.AddInput("11000");
            _commandHandler.AddInput("10 22");


            for (int i = 0; i < 11000; i++)
            {
                _commandHandler.AddInput("N 1");
            }

            Assert.IsTrue(_commandHandler.NumberOfCommand == 10000);
        }

        [Test]
        public void GivenStartingPointWithNewLineCoordinateValidateCoordinateResult()
        {
            _commandHandler = new CommandHandler();

            _commandHandler.AddInput("0");
            _commandHandler.AddInput("10   \n   22");

            Assert.That(_commandHandler.startPosition.X, Is.EqualTo(10));
            Assert.That(_commandHandler.startPosition.Y, Is.EqualTo(22));
        }
        [Test]
        public void GivenStartingPointWithSpaceCoordinateValidateCoordinateResult()
        {
            _commandHandler = new CommandHandler();

            _commandHandler.AddInput("0");
            _commandHandler.AddInput("10 22");


            Assert.That(_commandHandler.startPosition.X, Is.EqualTo(10));
            Assert.That(_commandHandler.startPosition.Y, Is.EqualTo(22));
        }

        [Test]
        public void GivenOneNavigationCommandsResult()
        {
            _commandHandler = new CommandHandler();

            _commandHandler.AddInput("1");
            _commandHandler.AddInput("10 22");
            _commandHandler.AddInput("N 1");

            Assert.That(_commandHandler.navigationCommands.Count, Is.EqualTo(1));
        }

        [Test]
        public void GivenMoreThanOneNavigationCommandsResult()
        {
            _commandHandler = new CommandHandler();

            _commandHandler.AddInput("3");
            _commandHandler.AddInput("10 22");
            _commandHandler.AddInput("N 1");
            _commandHandler.AddInput("S 1");
            _commandHandler.AddInput("E 1");

            Assert.That(_commandHandler.navigationCommands.Count, Is.EqualTo(3));
        }

        [Test]
        public void GivenIllegalDirectionNavigationCommandsGivesUnknownDirectionResult()
        {
            _commandHandler = new CommandHandler();

            _commandHandler.AddInput("1");
            _commandHandler.AddInput("10 22");
            _commandHandler.AddInput("K 2");


            Assert.That(_commandHandler.navigationCommands[0].NavigateTo, Is.EqualTo(Direction.Unknown));
        }

        [Test]
        public void GivenOutOfBoundNavigationCommandsGives9999StepsResult()
        {
            _commandHandler = new CommandHandler();

            _commandHandler.AddInput("1");
            _commandHandler.AddInput("10 22");
            _commandHandler.AddInput("S 20000");


            Assert.That(_commandHandler.navigationCommands[0].Steps, Is.EqualTo(9999));
        }

        [Test]
        public void GivenOutOfNegativeBoundNavigationCommandsGives9999StepsResult()
        {
            _commandHandler = new CommandHandler();

            _commandHandler.AddInput("1");
            _commandHandler.AddInput("10 22");
            _commandHandler.AddInput("S 0");


            Assert.That(_commandHandler.navigationCommands[0].Steps, Is.EqualTo(1));
        }
    }
}