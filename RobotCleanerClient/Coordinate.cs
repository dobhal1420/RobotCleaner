using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotCleanerCore
{
    public class Coordinate : IEquatable<Coordinate>
    {
        private const int MinLowerLimit = -10000;
        private const int MaxUppperLimit = 10000;
        private int _x;
        private int _y;
        
        public Coordinate(int x, int y)
        {
            _x = GetCoordinateWithinRange(x);
            _y = GetCoordinateWithinRange(y);
        }

        private int GetCoordinateWithinRange(int coordiante)
        {

            if (coordiante < MinLowerLimit)
                return MinLowerLimit;
            if(coordiante > MaxUppperLimit)
                return MaxUppperLimit;

            return coordiante;

        }

        public bool Equals(Coordinate other)
        {
            if(other == null)
                return false;
            
            return _x == other._x && _y == other._y;
        }

        public int GetHashCode(Coordinate pos)
        {
            return HashCode.Combine(pos.X, pos.Y);
        }


        public int X
        {
            get { return _x; }
        }

        public int Y
        {
            get
            {
                return _y;
            }
        }

    }
}
