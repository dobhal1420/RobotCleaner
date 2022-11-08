using RobotCleanerCore.Helper;
using RobotCleanerCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotCleanerCore
{
    public class MovementTracker : IMovementTracker
    {
        private HashSet<Coordinate> _cleanedLocations;

        public MovementTracker()
        {
            _cleanedLocations = new HashSet<Coordinate>(new CoordinatesComparer());
        }
        public void SavePosition(Coordinate position)
        {
            _cleanedLocations.Add(position);
        }

        public string ShowResult()
        {
            string result = $"=> Cleaned: {_cleanedLocations.Count}";
            return result;
        }
    }
}
