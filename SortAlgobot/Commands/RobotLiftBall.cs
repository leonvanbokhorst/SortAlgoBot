using System.Threading;

namespace SortAlgoBot.Commands
{
    public class RobotLiftBall : IRobotCommand
    {
        private readonly SortRobot _robot;

        public RobotLiftBall(SortRobot robot)
        {
            _robot = robot;
        }

        #region IRobotCommand Members

        public void Execute()
        {
            LiftUp();
            LiftDown();
        }

        #endregion

        private void LiftUp()
        {
            _robot.BallLift.Run(power: -10, tachoLimit: 25);
            Thread.Sleep(1200);
        }

        private void LiftDown()
        {
            _robot.BallLift.Run(power: 4, tachoLimit: 25);
            Thread.Sleep(500);
        }
    }
}