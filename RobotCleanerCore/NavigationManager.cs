using RobotCleanerCore;
using RobotCleanerCore.Helper;

namespace RobotCleanerCore
{
    public class NavigationManager
    {
        public Coordinate startPosition;
        public List<NavigationCommand> navigationCommands;

        public NavigationManager()
        {
            navigationCommands = new List<NavigationCommand>();
        }

        public void AddCommand(string input)
        {
            navigationCommands.Add(new NavigationCommand(input));
        }

        public void SetStartPosition(string inputString)
        {
            var coordinates = InputSplitter.splitString(inputString);
            if (coordinates.Length > 1)
            {
                int x, y;
                int.TryParse(coordinates[0], out x);
                int.TryParse(coordinates[1], out y);
                startPosition = new Coordinate(x, y);
            }
        }

    }
}