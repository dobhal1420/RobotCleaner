using RobotCleanerCore.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotCleanerCore
{
    public class NavigationCommand
    {
        private const int MaxNavigationSteps = 9999;
        private const int MinNavigationSteps = 1;
        public Direction NavigateTo { get; set; }

        public int Steps { get; set; }

        private Dictionary<string, Direction> commandToNavigationMapping = new Dictionary<string, Direction>()
            {
                { "N", Direction.North },
                { "S", Direction.South },
                { "W", Direction.West },
                { "E", Direction.East}
            };

        public NavigationCommand(string inputCommand)
        {
            var coordinates = InputSplitter.splitString(inputCommand);
            if (coordinates.Length > 1)
            {
                string direction = coordinates[0].ToUpper();
                int steps = int.Parse(coordinates[1]);
                if (commandToNavigationMapping.ContainsKey(direction))
                {
                    NavigateTo = commandToNavigationMapping[direction];
                }
                else {
                    NavigateTo = Direction.Unknown;
                }
                
                steps = steps > MaxNavigationSteps ? MaxNavigationSteps : steps;

                steps = steps < MinNavigationSteps ? MinNavigationSteps : steps;

                Steps = steps;

            }
        }
    }
}
