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

        public abstract IStateErrorController StateController { get; protected set; }

        public abstract void SetWheelVelocityDesired(double vl, double vr);
        public abstract void CalculateWheelVelocity();

        public State2D Propagate(State2D currentState, double dT, double vl, double vr)
        {
            double dTheta_dT = 0.0;
            double dX_dT = ((vr + vl) / 2) * Math.Cos(currentState.Theta);
            double dY_dT = ((vr + vl) / 2) * Math.Sin(currentState.Theta);
            if (WheelSeparation > 0.0)
            {
                dTheta_dT = (vr - vl) / WheelSeparation;
            }
            State2D newState = new State2D(
               currentState.X + dX_dT * dT,
               currentState.Y + dY_dT * dT,
               currentState.Theta + dTheta_dT * dT);

            _currentState = newState;

            return newState;
        }

        public double WheelRadius { get { return _wheelRadius; } }
        public double WheelSeparation { get { return _wheelSeparation; } }
        public double Vl { get; protected set; }
        public double Vr { get; protected set; }

        private double _wheelRadius = 1.0; // Radius of wheel, m
        private double _wheelSeparation = 1.0; // Seperation of drive wheel, m

        private State2D _currentState = new State2D();
    }
}