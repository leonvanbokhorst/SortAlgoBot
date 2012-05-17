using System.Diagnostics;
using System.Threading;
using NKH.MindSqualls;
using NKH.MindSqualls.MotorControl;

namespace SortAlgoBot.Commands
{
    public class RobotReadColorCommand
    {
        #region IRobotCommand Members

        public Nxt2Color Execute(McNxtBrick brick)
        {
            var colorSensor = brick.Sensor3 as Nxt2ColorSensor;
            Nxt2Color? color = null;

            if (colorSensor != null)
            {
                colorSensor.SetColorDetectorMode();
                colorSensor.Poll();
                color = colorSensor.Color;

                Thread.Sleep(500);

                if (color != null)
                    Debug.WriteLine("Color {0}", color.Value);
            }

            return color.Value;
        }

        #endregion
    }
}