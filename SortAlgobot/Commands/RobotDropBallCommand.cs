using System.Threading;
using NKH.MindSqualls.MotorControl;

namespace SortAlgoBot.Commands
{
    public class RobotDropBallCommand
    {
        #region IRobotCommand Members

        public void Execute(McNxtBrick brick)
        {
            brick.MotorC.Run(100, 3200);
            Thread.Sleep(6000);

            brick.MotorC.Run(-100, 3200);
            Thread.Sleep(3000);
        }

        #endregion
    }
}