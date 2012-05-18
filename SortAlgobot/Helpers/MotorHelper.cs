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

        public static BallPosition GetBallPosition(int leftIndex)
        {
            return (BallPosition) (leftIndex + 2);
        }

        public static BallPosition GetColorReadPosition(int leftIndex)
        {
            return (BallPosition) (leftIndex + 1);
        }

        public static MotorDirection SetMotorDirection(int tacho)
        {
            MotorDirection motorDirection = MotorDirection.Forward;

            if (tacho < 0)
            {
                motorDirection = MotorDirection.Backward;
            }

            return motorDirection;
        }

        public static void WaitForMotorToFinish(McNxtMotor motor)
        {
            do
            {
                if (motor.TachoCount != null)
                {
                    _runningTacho = motor.TachoCount.Value;
                }

                Thread.Sleep(200); // now wait half a second!

                motor.Poll();
            } while (motor.TachoCount.HasValue
                     && motor.TachoCount.Value != _runningTacho);
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