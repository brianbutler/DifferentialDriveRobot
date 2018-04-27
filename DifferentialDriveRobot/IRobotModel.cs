using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifferentialDriveRobot
{
    public abstract class IRobotModel
    {
        public IRobotModel(double wheelRadius, double wheelSeparation)
        {
            _wheelRadius = wheelRadius;
            _wheelSeparation = wheelSeparation;
        }

        public RobotState2D Propagate(RobotState2D currentState, double dT, double vl, double vr)
        {
            double dTheta_dT = 0.0;
            double dX_dT = ((vr + vl) / 2) * Math.Cos(currentState.Theta);
            double dY_dT = ((vr + vl) / 2) * Math.Sin(currentState.Theta);
            if (WheelSeparation > 0.0)
            {
                dTheta_dT = (vr - vl) / WheelSeparation;
            }
            RobotState2D newState = new RobotState2D(
               currentState.X + dX_dT * dT,
               currentState.Y + dY_dT * dT,
               currentState.Theta + dTheta_dT * dT);
            return newState;
        }

        public double WheelRadius { get { return _wheelRadius; } }
        public double WheelSeparation { get { return _wheelSeparation; } }

        private double _wheelRadius = 1.0; // Radius of wheel, m
        private double _wheelSeparation = 1.0; // Seperation of drive wheel, m

        private RobotState2D _currentState = new RobotState2D();
    }
}
