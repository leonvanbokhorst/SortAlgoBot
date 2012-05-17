using System;
using System.Diagnostics;
using NKH.MindSqualls.MotorControl;
using SortAlgoBot.Helpers;

namespace SortAlgoBot.Commands
{
    public class RobotToPositionCommand : IRobotCommand
    {
        #region IRobotCommand Members

        public void Execute(McNxtBrick brick, SortRail sortRail, BallPosition position)
        {
            int tacho = sortRail.GetTachoToPosition(position);
            MotorDirection motorDirection = MotorDirection.Forward;

            if (tacho < 0)
            {
                motorDirection = MotorDirection.Backward;
            }

            var absTacho = (uint) Math.Abs(tacho);

            Debug.WriteLine("Heading for position {0} with tacho {1}",
                            position,
                            tacho);

            int resultTacho = MotorHelper.RunAndWaitOnCompletion(
                (McNxtMotor) brick.MotorA,
                absTacho,
                motorDirection);

            sortRail.CurrentTacho += resultTacho;
        }

        #endregion

        // 20+20+5 = 46 lego posities in 45 stappen dus delen door 45
        // 1 home posities = 8 lego posities
        // 1 lego positie is 110 tacho
        // total tacho 4950
    }
}