using System.Diagnostics;
using System.Threading;
using NKH.MindSqualls;

namespace SortAlgoBot.Commands
{
    public class RobotReadColor : IRobotValueCommand
    {
        private readonly SortRobot _robot;

        public RobotReadColor(SortRobot robot)
        {
            _robot = robot;
        }

        #region IRobotValueCommand Members

        public int Result { get; set; }

        public void Execute()
        {
            if (_robot.ColorSensor != null)
            {
                _robot.ColorSensor.SetColorDetectorMode();
                _robot.ColorSensor.Poll();
                Nxt2Color? color = _robot.ColorSensor.Color;

                Thread.Sleep(1000);

                if (color == null)
                {
                    throw new NxtException("Color sensor error.");
                }

                Result = (int) color.Value;

                Debug.WriteLine("Ball color is {0}", color.Value);
            }
        }

        #endregion
    }
}