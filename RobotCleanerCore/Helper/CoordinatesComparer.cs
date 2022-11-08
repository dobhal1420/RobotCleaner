using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotCleanerCore.Helper
{
    public class CoordinatesComparer : IEqualityComparer<Coordinate>
    {
        public bool Equals(Coordinate p1, Coordinate p2)
        {
            return (p1.X == p2.X) && (p1.Y == p2.Y);
        }

        public int GetHashCode(Coordinate pos)
        {
            return HashCode.Combine(pos.X, pos.Y);
        }
    }
}
