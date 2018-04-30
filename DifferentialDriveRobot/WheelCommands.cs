using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifferentialDriveRobot
{
    public class BodyFrameCommands
    {
        public BodyFrameCommands()
        {
            V = 0.0;
            W = 0.0;
        }

        public BodyFrameCommands(double v, double w)
        {
            V = v;
            W = w;
        }

        public WheelCommands GetWheelCommands(double r, double d)
        {
            // Equations are as follows:
            // r = Wheel radius, meters
            // d = Wheel seperation, meters
            // Wr = Right wheel angular velocity, radians/sec
            // Wl = Left wheel angular velocity, radians/sec
            // V = Forward velocity, meters/sec
            // W = Angular velocity, radians/sec
            //
            // V = (r/2)(Wr + Wl) = Forward velocity, meters/sec
            // W = (r/d)(Wr - Wl) = Angular velocity, radians/sec
            //
            // Inverting matrix equation:
            // Wr = (1/r)V + (d/r)W
            // Wl = (1/r)V - (d/r)W

            WheelCommands commands = new WheelCommands();

            if((r > 0.0) && (d > 0.0))
            {
                commands.OmegaR = (1 / r) * V + (d / r) * W;
                commands.OmegaL = (1 / r) * V - (d / r) * W;
            }

            return commands;
        }

        /// <summary>
        /// Forward commanded velocity, meters/sec
        /// </summary>
        public double V { get; set; }

        /// <summary>
        /// Commanded angular velocity, radians/sec
        /// </summary>
        public double W { get; set; }
    }


    public class WheelCommands
    {
        public WheelCommands()
        {
            OmegaR = 0.0;
            OmegaL = 0.0;
        }

        public WheelCommands(double omegaR, double omegaL)
        {
            OmegaR = omegaR;
            OmegaL = omegaL;
        }

        /// <summary>
        /// Right wheel commanded angular velocity, radians/sec
        /// </summary>
        public double OmegaR { get; set; }

        /// <summary>
        /// Left wheel commanded angular velocity, radians/sec
        /// </summary>
        public double OmegaL { get; set; }
    }
}
