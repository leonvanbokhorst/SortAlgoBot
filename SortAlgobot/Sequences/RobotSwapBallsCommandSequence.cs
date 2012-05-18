using System.Collections.Generic;
using SortAlgoBot.Commands;

namespace SortAlgoBot.Sequences
{
    public class RobotSwapBallsCommandSequence : IRobotCommand
    {
        private readonly BallPosition _leftBallPosition;
        private readonly BallPosition _rightBallPosition;
        private readonly SortRobot _robot;
        private readonly SortRail _sortRail;

        public RobotSwapBallsCommandSequence(SortRobot robot, SortRail sortRail, BallPosition leftBallPosition,
                                             BallPosition rightBallPosition)
        {
            _robot = robot;
            _sortRail = sortRail;
            _leftBallPosition = leftBallPosition;
            _rightBallPosition = rightBallPosition;
        }

        #region IRobotCommand Members

        public void Execute()
        {
            #region Sequence

            // 01. Go to leftpointer position
            // 02. Drop leftpointer ball
            // 03. Go to Swap position
            // 04. Lift ball
            // 05. Go to rightpointer position
            // 06. Drop rightpointer ball
            // 07. Go to leftpointer position
            // 08. Lift ball
            // 09. Go to Swap position
            // 10. Drop swap ball
            // 11. Go to rightpointer position
            // 12. Lift ball
            // 13. Go to Home position 

            #endregion

            var commandSequencer =
                new List<IRobotCommand>
                    {
                        new RobotMoveToPosition(_robot, _sortRail, _leftBallPosition),
                        new RobotDropBall(_robot),
                        new RobotMoveToPosition(_robot, _sortRail, BallPosition.Swap),
                        new RobotLiftBall(_robot),
                        new RobotMoveToPosition(_robot, _sortRail, _rightBallPosition),
                        new RobotDropBall(_robot),
                        new RobotMoveToPosition(_robot, _sortRail, _leftBallPosition),
                        new RobotLiftBall(_robot),
                        new RobotMoveToPosition(_robot, _sortRail, BallPosition.Swap),
                        new RobotDropBall(_robot),
                        new RobotMoveToPosition(_robot, _sortRail, _rightBallPosition),
                        new RobotLiftBall(_robot),
                    };

            foreach (IRobotCommand robotCommand in commandSequencer)
            {
                robotCommand.Execute();
            }
        }

        #endregion
    }
}