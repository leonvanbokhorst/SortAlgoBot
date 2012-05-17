using System.Threading;
using NKH.MindSqualls.MotorControl;

namespace SortAlgoBot.Commands
{
    public class RobotLiftBallCommand : IRobotCommand
    {
        #region IRobotCommand Members

        public void Execute(McNxtBrick brick, SortRail sortRail, BallPosition position)
        {
            brick.MotorB.Run(power: -8, tachoLimit: 25);
            Thread.Sleep(1500);

            brick.MotorB.Run(power: 5, tachoLimit: 25);
            Thread.Sleep(1000);
        }

        #endregion
    }
}