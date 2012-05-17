using System.Threading;
using NKH.MindSqualls.MotorControl;

namespace SortAlgoBot.Commands
{
    public class RobotLiftBallCommand
    {
        #region IRobotCommand Members

        public void Execute(McNxtBrick brick)
        {
            brick.MotorB.Run(power: -10, tachoLimit: 25);
            Thread.Sleep(1500);

            brick.MotorB.Run(power: 10, tachoLimit: 25);
            Thread.Sleep(1000);
        }

        #endregion
    }
}