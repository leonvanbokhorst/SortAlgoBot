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

        public static int RunAndWait(McNxtMotor motor, uint tacho,
                                     MotorDirection direction)
        {
            sbyte speed = GetSpeed(direction);

            motor.Run(speed, tacho);
            Thread.Sleep((int) (tacho*WaitMultiplier));

            motor.Poll();
            Debug.WriteLine("OnPoll {0}", motor.TachoCount);

            return motor.TachoCount.Value;
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