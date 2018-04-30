using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DifferentialDriveRobot;

namespace DifferentialDriveRobotUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            double r = 0.1;
            double d = 0.5;

            SimulatedRobotModel robot = new SimulatedRobotModel(r, d);

            State2D currState = new State2D(0.0, 0.0, 0.0);
            State2D goalState = new State2D(5.0, 5.0, 0.0);
            //State2D_Difference err = new State2D_Difference(currState, goalState);

            //BodyFrameCommands cmdBody = new BodyFrameCommands(0.1, 0.0);
            //WheelCommands cmdWheel = cmdBody.GetWheelCommands(r, d);

            //robot.SetWheelVelocityDesired(cmdWheel.OmegaL * r, cmdWheel.OmegaR * r);
            robot.CalculateWheelVelocity();

            State2D state = robot.Propagate(new State2D(), 1.0, robot.Vl, robot.Vr);

            int i = 0;
            while(i < 1000)
            {
                State2D_Difference err = new State2D_Difference(currState, goalState);

                WheelCommands cmdWheel = robot.StateController.GetCommands(err);

                robot.SetWheelVelocityDesired(cmdWheel.OmegaL * r, cmdWheel.OmegaR * r);
                robot.CalculateWheelVelocity();

                currState = robot.Propagate(currState, 0.1, robot.Vl, robot.Vr);

                i++;
            }



        }
    }
}
