using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotCleanerCore.Helper
{
    public static class InputSplitter
    {
        public static string[] splitString(string input)
        {
            return input.Split(new char[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
