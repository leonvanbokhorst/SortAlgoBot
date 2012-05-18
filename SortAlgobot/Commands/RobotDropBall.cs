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
            _robot.BallDropper.Run(power: 100, tachoLimit: 3200);
            Thread.Sleep(6000);
        }

        private void RetractLinearActuator()
        {
            _robot.BallDropper.Run(power: -100, tachoLimit: 3200);
            Thread.Sleep(6000);
        }
    }
}