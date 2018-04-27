using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifferentialDriveRobot
{
    public class RobotState2D
    {
        public RobotState2D()
        {
            X = 0.0;
            Y = 0.0;
            Theta = 0.0;
        }

        public RobotState2D(double x, double y, double theta)
        {
            X = x;
            Y = y;
            Theta = theta;
        }

        public double X { get; set; }
        public double Y { get; set; }
        public double Theta { get; set; }
    }
}