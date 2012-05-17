using System.Diagnostics;
using System.Threading;
using NKH.MindSqualls.MotorControl;

namespace SortAlgoBot.Helpers
{
    public class MotorHelper
    {
        private static int _runningTacho;

        public static int RunAndWaitOnCompletion(
            McNxtMotor motor, uint tacho, MotorDirection direction)
        {
            _runningTacho = 0;
            sbyte speed = GetSpeed(direction);

            motor.Run(speed, tacho);
            WaitForMotorToFinish(motor);

            Debug.WriteLine("Real tacho {0} degrees", motor.TachoCount);

            return motor.TachoCount.Value;
        }

        private static void WaitForMotorToFinish(McNxtMotor motor)
        {
            do
            {
                if (motor.TachoCount != null)
                    _runningTacho = motor.TachoCount.Value;

                Debug.Write("-");
                Thread.Sleep(1000); // now wait a second!

                motor.Poll();
            } while (motor.TachoCount.HasValue
                     && motor.TachoCount.Value != _runningTacho);
            Debug.WriteLine("");
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