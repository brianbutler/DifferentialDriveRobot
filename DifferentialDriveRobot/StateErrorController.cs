using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifferentialDriveRobot
{
    public class StateErrorController : IStateErrorController
    {
        public StateErrorController(double kp, double ka, double r, double d)
        {
            Kp = kp;
            Ka = ka;
            _r = r;
            _d = d;
        }

        public override WheelCommands GetCommands(State2D_Difference error)
        {
            // Equations for body frame commands are as follows:
            // V = Kp*rho*cos(alpha)
            // W = Kp*sin(alpha)*cos(alpha) + Ka*alpha

            double sinAlpha = Math.Sin(error.Alpha);
            double cosAlpha = Math.Cos(error.Alpha);

            BodyFrameCommands bodyCommands = new BodyFrameCommands(
                Kp * error.Rho * cosAlpha,
                Kp * sinAlpha * cosAlpha + Ka * error.Alpha);

            WheelCommands wheelCommands = bodyCommands.GetWheelCommands(_r, _d);

            return wheelCommands;
        }

        public double Kp { get; set; }
        public double Ka { get; set; }

        private double _r;
        private double _d;
    }
}
