using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifferentialDriveRobot
{
    public class SimulatedRobotModel : IRobotModel
    {
        public SimulatedRobotModel(double wheelRadius, double wheelSeparation) : base(wheelRadius, wheelSeparation)
        {
        }
    }
}
