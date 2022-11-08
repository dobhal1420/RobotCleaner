using RobotCleanerCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotCleanerCore
{
    public class InputHandler : IInputHandler
    {
        private const int MaxCommands = 10000;
        private const int MinCommands = 0;
        private int _numberOfCommands;

        public void SetNumberOfInput(string input)
        {
            int.TryParse(input, out _numberOfCommands);

            if (_numberOfCommands < MinCommands)
                _numberOfCommands = 0;
            if (_numberOfCommands > MaxCommands)
                _numberOfCommands = MaxCommands;
        }

        public int NumberOfCommands { get { return _numberOfCommands; } }
    }
}
