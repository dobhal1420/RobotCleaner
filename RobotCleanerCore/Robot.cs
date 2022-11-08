namespace RobotCleanerCore
{
    public class Robot
    {
        private NavigationManager _commandHandler;
        private MovementTracker _movementTracker;
        private Coordinate _currentPosition;

        public Robot(NavigationManager commandHandler)
        {
            _commandHandler = commandHandler;
            _movementTracker = new MovementTracker();
            _currentPosition = commandHandler.startPosition;
        }

        public void Execute()
        {
            foreach (var navigationCommand in _commandHandler.navigationCommands)
            {
                for (int i = 0; i < navigationCommand.Steps; i++)
                {
                    MoveRobot(navigationCommand);
                }
                
            }
        }

        private void MoveRobot(NavigationCommand navigationCommand)
        {
            int x = _currentPosition.X;
            int y = _currentPosition.Y;
            switch (navigationCommand.NavigateTo)
            {
                case Helper.Direction.North:
                    _currentPosition = new Coordinate(x, y + 1);
                    break;
                case Helper.Direction.East:
                    _currentPosition = new Coordinate(x + 1, y);
                    break;
                case Helper.Direction.South:
                    _currentPosition = new Coordinate(x, y - 1);
                    break;
                case Helper.Direction.West:
                    _currentPosition = new Coordinate(x - 1, y);
                    break;
                default:
                    break;
            }

            if (_currentPosition.Equals(_commandHandler.startPosition))
                return;
                
           _movementTracker.SavePosition(_currentPosition);
        }

        public Coordinate CurrentPostion { get { return _currentPosition; } }

        public string ShowResult()
        {
            return _movementTracker.ShowResult();
        }
    }
}
