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

        private int GetCoordinateWithinRange(int coordinate)
        {

            if (coordinate < MinLowerLimit)
                return MinLowerLimit;
            if(coordinate > MaxUppperLimit)
                return MaxUppperLimit;

            return coordinate;

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
