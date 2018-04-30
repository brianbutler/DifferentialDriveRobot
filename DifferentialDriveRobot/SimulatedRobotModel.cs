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
            StateController = new StateErrorController(0.1, 0.1, wheelRadius, wheelSeparation);
        }

        public override IStateErrorController StateController { get; protected set; }

        public override void SetWheelVelocityDesired(double vl, double vr)
        {
            _desiredVl = vl;
            _desiredVr = vr;
        }

        public override void CalculateWheelVelocity()
        {
            Vl = _desiredVl;
            Vr = _desiredVr;
        }

        public double _desiredVl;
        public double _desiredVr;
    }
}
