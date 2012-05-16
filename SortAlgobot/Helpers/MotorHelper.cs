using System.Diagnostics;
using System.Threading;
using NKH.MindSqualls.MotorControl;

namespace SortAlgoBot.Helpers
{
    public enum MotorDirection
    {
        Forward,
        Backward
    }

    public class MotorHelper
    {
        private const int WaitMultiplier = 6;

        public static int RunAndWait(McNxtBrick brick, uint tacho,
                                     MotorDirection direction)
        {
            sbyte speed = GetSpeed(direction);

            brick.MotorA.Run(speed, tacho);
            Thread.Sleep((int) (tacho*WaitMultiplier));

            brick.MotorA.Poll();
            Debug.WriteLine("OnPoll {0}", brick.MotorA.TachoCount);

            return brick.MotorA.TachoCount.Value;
        }

        private static sbyte GetSpeed(MotorDirection direction)
        {
            sbyte speed = 50;

            if (direction == MotorDirection.Backward)
            {
                speed = -50;
            }

            return speed;
        }
    }
}