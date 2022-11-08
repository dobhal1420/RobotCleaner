using RobotCleanerCore;
using RobotCleanerCore.Interfaces;

namespace RobotCleanerTest
{
    public class InputHandlerTest
    {
        private IInputHandler _inputHandler;

        [Test]
        public void GivenOneCommandSuccessCommandsValidResult()
        {
            _inputHandler = new InputHandler();

            _inputHandler.SetNumberOfInput("1");

            Assert.IsTrue(_inputHandler.NumberOfCommands == 1);
        }

        [Test]
        public void GivenTwoCommandsSuccessCommandsValidResult()
        {
            _inputHandler = new InputHandler();

            _inputHandler.SetNumberOfInput("2");

            Assert.IsTrue(_inputHandler.NumberOfCommands == 2);
        }

        [Test]
        public void GivenZeroCommandSuccessCommandsValidResult()
        {
            _inputHandler = new InputHandler();

            _inputHandler.SetNumberOfInput("0");


            Assert.IsTrue(_inputHandler.NumberOfCommands == 0);
        }

        [Test]
        public void GivenTenThousandCommandSuccessCommandsValidResult()
        {
            _inputHandler = new InputHandler();

            _inputHandler.SetNumberOfInput("10000");

            Assert.IsTrue(_inputHandler.NumberOfCommands == 10000);
        }
        [Test]
        public void GivenNegativeIntegerCommandSuccessCommandsValidResult()
        {
            _inputHandler = new InputHandler();

            // Should Gracefully handles this negative scenario without throwing any error.
            _inputHandler.SetNumberOfInput("-5");

            Assert.IsTrue(_inputHandler.NumberOfCommands == 0);
        }

        [Test]
        public void GivenMoreThanTenThousandsCommandSuccessCommandsValidResult()
        {
            _inputHandler = new InputHandler();

            // Should Gracefully handles Outof bound limit without throwing any error.
            _inputHandler.SetNumberOfInput("11000");


            Assert.IsTrue(_inputHandler.NumberOfCommands == 10000);
        }
    }
}
