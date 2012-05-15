using System;
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
        private const uint WaitMultiplier = 3;

        public static int RunAndWait(McNxtBrick brick,
                                     int tacho, MotorDirection direction)
        {
            sbyte speed = 50;
            if (direction == MotorDirection.Backward)
                speed = -50;

            brick.MotorA.Run(speed, (uint) tacho);
            Thread.Sleep((int) Math.Abs(tacho*WaitMultiplier));
            brick.MotorA.Poll();
            Debug.WriteLine("OnPoll {0}", brick.MotorA.TachoCount);

            return brick.MotorA.TachoCount.Value;
        }
    }
}