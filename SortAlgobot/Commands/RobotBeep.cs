using System.Threading;

namespace SortAlgoBot.Commands
{
    public class RobotBeep : IRobotCommand
    {
        private readonly SortRobot _robot;

        public RobotBeep(SortRobot robot)
        {
            _robot = robot;
        }

        #region IRobotCommand Members

        public void Execute()
        {
            BeepA();
        }

        #endregion

        private void BeepA()
        {
            _robot.Brick.PlayTone(frequency: 480, duration: 25);
            Thread.Sleep(50);
        }
    }
}