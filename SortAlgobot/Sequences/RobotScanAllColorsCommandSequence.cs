using SortAlgoBot.Commands;

namespace SortAlgoBot.Sequences
{
    public class RobotScanAllColorsCommandSequence : IRobotCommand
    {
        private readonly SortRobot _robot;
        private readonly SortRail _sortRail;

        public RobotScanAllColorsCommandSequence(SortRobot robot, SortRail sortRail)
        {
            _robot = robot;
            _sortRail = sortRail;
        }

        #region IRobotCommand Members

        public void Execute()
        {
            #region Sequence

            // REPEAT 12 TIMES
            //      01. Go to position 12
            //      02. Scan color and save in sortList
            // END
            // 03. Go to Home position 

            #endregion

            for (int i = 12; i > 0; i--)
            {
                var gotoPosition = new RobotMoveToPosition(_robot, _sortRail, (BallPosition) i);
                var readColor = new RobotReadColor(_robot);

                gotoPosition.Execute();
                readColor.Execute();

                _sortRail.SortList[i - 1] = readColor.Result;
            }

            var goHome = new RobotMoveToPosition(_robot, _sortRail, BallPosition.Home);
            goHome.Execute();
        }

        #endregion
    }
}