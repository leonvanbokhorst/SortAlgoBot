using System.Diagnostics;
using NKH.MindSqualls;
using NKH.MindSqualls.MotorControl;

namespace SortAlgoBot.Commands
{
    public class RobotReadColorCommand : IRobotCommand
    {
        public void Execute(McNxtBrick brick, SortRail sortRail, BallPosition position)
        {
            var colorSensor = brick.Sensor3 as Nxt2ColorSensor;
            if (colorSensor != null)
            {
                colorSensor.SetColorDetectorMode();
                //colorSensor.SetColorRange(Nxt2Color.Black, Nxt2Color.White);
                colorSensor.Poll();
                var color = colorSensor.Color;

                if (color != null) 
                    Debug.WriteLine("Color {0}", color.Value);
            }
        }
    }
}