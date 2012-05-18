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

        //private bool RobotGotoIndexPositionAndReadStoreColor(int index)
        //{
        //    // Ga naar leftindex 
        //    BallPosition leftIndexColorPosition = GetColorReadPosition(index);
        //    var c1 = new RobotMoveToPosition(_brick, _sortRail, leftIndexColorPosition);
        //    c1.Execute();
        //    // Lees Pivot kleur 
        //    var c2 = new RobotReadColor(_brick);
        //    c2.Execute();
        //    // en sla op als waarde 0 is
        //    if (_sortList[index] == 0)
        //    {
        //        _sortList[index] = c2.Result;
        //    }

        //    return true;
        //}

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