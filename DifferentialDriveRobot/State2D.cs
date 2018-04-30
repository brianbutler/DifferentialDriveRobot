using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifferentialDriveRobot
{
    public class State2D
    {
        public State2D()
        {
            X = 0.0;
            Y = 0.0;
            Theta = 0.0;
        }

        public State2D(double x, double y, double theta)
        {
            X = x;
            Y = y;
            Theta = theta;
        }

        /// <summary>
        /// X position in X-Y coordinate plane, meters
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// Y position in X-Y coordinate plane, meters
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// Orientation in X-Y coordinate plane, radians
        /// </summary>
        public double Theta { get; set; }
    }

    public class State2D_Difference
    {
        public State2D_Difference(State2D currentState, State2D goalState)
        {
            double dX = goalState.X - currentState.X;
            double dY = goalState.Y - currentState.Y;
            Rho = Math.Sqrt(dX * dX + dY * dY);

            Alpha = Normalise(Math.Atan2(dY, dX) - currentState.Theta);
        }

        //Normalizes any number to an arbitrary range 
        //by assuming the range wraps around when going below min or above max 
        double Normalise(double value, double min = -Math.PI, double max = Math.PI)
        {
            double width = max - min;   // 
            double offsetValue = value - min;   // value relative to 0

            return (offsetValue - (Math.Floor(offsetValue / width) * width)) + min;
            // + start to reset back to start of original range
        }

        /// <summary>
        /// Position difference in X-Y coordinate plane (goal - current), meters
        /// </summary>
        public double Rho { get; set; }

        /// <summary>
        /// Angle difference in X-Y coordinate plane (goal - current), radians
        /// </summary>
        public double Alpha { get; set; }
    }
}