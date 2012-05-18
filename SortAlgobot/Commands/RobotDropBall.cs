using System.Threading;

namespace SortAlgoBot.Commands
{
    public class RobotDropBall : IRobotCommand
    {
        private readonly SortRobot _robot;

        public RobotDropBall(SortRobot robot)
        {
            _robot = robot;
        }

        public int Result { get; set; }

        #region IRobotCommand Members

        public void Execute()
        {
            ExtendLinearActuator();
            RetractLinearActuator();
        }

        #endregion

        private void ExtendLinearActuator()
        {
            _robot.BallDropper.Run(power: 100, tachoLimit: 2100);
            Thread.Sleep(4000);
        }

        private void RetractLinearActuator()
        {
            _robot.BallDropper.Run(power: -100, tachoLimit: 2100);
            Thread.Sleep(1100);
        }
    }
}