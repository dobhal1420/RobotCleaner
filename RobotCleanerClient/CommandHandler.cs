using RobotCleanerCore;

namespace RobotCleanerClient
{
    public class CommandHandler
    {
        private const int MaxCommands = 10000;
        private const int MinCommands = 0;
        private int _numberOfCommands;
        public Coordinate startPosition;
        public List<NavigationCommand> navigationCommands;

        private List<string> _inputs;

        public CommandHandler()
        {
            _inputs = new List<string>();
            navigationCommands = new List<NavigationCommand>();

        }

        public void AddInput(string input)
        {
            if (!IsInputComplete)
            {
                if (_inputs.Count == 0)
                {
                    SetNumberOfInput(input);
                }

                else if (_inputs.Count == 1)
                {
                    SetStartPosition(input);
                }
                else
                {
                    navigationCommands.Add(new NavigationCommand(input));
                }

                _inputs.Add(input);
            }
        }

        private void SetNumberOfInput(string input)
        {
            _numberOfCommands = int.Parse(input);
            if(_numberOfCommands < MinCommands)
                _numberOfCommands = 0;
            if(_numberOfCommands > MaxCommands)
                _numberOfCommands = MaxCommands;
        }

        private void SetStartPosition(string inputString)
        {
            var coordinates = inputString.Split(new char[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            if (coordinates.Length > 1)
            {
                int x = int.Parse(coordinates[0]);
                int y = int.Parse(coordinates[1]);
                startPosition = new Coordinate(x, y);
            }
        }

        public bool IsInputComplete { get { return _inputs.Count == _numberOfCommands + 2; } }

    }
}