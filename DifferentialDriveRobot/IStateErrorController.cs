using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifferentialDriveRobot
{
    public abstract class IStateErrorController
    {
        public abstract WheelCommands GetCommands(State2D_Difference error);
    }
}
