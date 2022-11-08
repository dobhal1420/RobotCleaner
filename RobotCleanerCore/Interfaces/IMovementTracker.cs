using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotCleanerCore.Interfaces
{
 
    public interface IMovementTracker
    {
        string ShowResult();

        void SavePosition(Coordinate position);
    }
}
