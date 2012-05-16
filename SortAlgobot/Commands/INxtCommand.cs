using System;
using NKH.MindSqualls.MotorControl;
using SortAlgoBot.Helpers;

namespace SortAlgoBot.Commands
{
    public interface IRobotCommand
    {
        void Execute(McNxtBrick brick, SortRail sortRail, BallPosition position);
    }

    public class RobotToPosition : IRobotCommand
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

            int resultTacho = MotorHelper.RunAndWait(
                brick,
                Math.Abs(tacho),
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