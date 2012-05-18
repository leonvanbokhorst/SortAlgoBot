using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortAlgoBot;
using SortAlgoBot.Algorithms;
using SortAlgoBot.Commands;
using SortAlgoBot.Commands.Sequences;
using SortAlgoBot.Helpers;

namespace SortAlgobotTests.NxtIntegrationTests
{
    [TestClass]
    public class NxtTests
    {
        private SortRobot _robot;
        private SortRail _sortRail;

        [TestInitialize]
        public void InitRobot()
        {
            _robot = new SortRobot();
            _sortRail = new SortRail();
        }

        [TestCleanup]
        public void CleanupRobot()
        {
            _robot.Dispose();
        }

        [TestMethod]
        public void ReadAndSort()
        {
            var scanColorSequence = new RobotScanAllColorsCommandSequence(_robot, _sortRail);
            scanColorSequence.Execute();
            var algo = new RoboSortAlgorithm(_sortRail.SortList);
            algo.PivotPicked += AlgoPivotPicked;
            algo.Swap += AlgoSwap;

            algo.QuickSort(0, 11);
        }

        private void AlgoSwap(int leftPointer, int rightPointer)
        {
            var swapBallsCommandSequence = new RobotSwapBallsCommandSequence(
                _robot,
                _sortRail,
                MotorHelper.GetBallPosition(leftPointer),
                MotorHelper.GetBallPosition(rightPointer));

            swapBallsCommandSequence.Execute();
        }

        private void AlgoPivotPicked(int leftPointer, int rightPointer)
        {
            var beepCommand = new RobotBeep(_robot);
            beepCommand.Execute();
        }

        [TestMethod]
        public void ShouldReadColorBallOnPositionSix()
        {
            var sortRail = new SortRail();

            var moveToColorReadSixCommand = new RobotMoveToPosition(_robot, sortRail, BallPosition.Six - 1);
            moveToColorReadSixCommand.Execute();

            var readColorCommand = new RobotReadColor(_robot);
            readColorCommand.Execute();

            var moveBackHomeCommand = new RobotMoveToPosition(_robot, sortRail, BallPosition.Home);
            moveBackHomeCommand.Execute();
        }

        [TestMethod]
        public void ShouldDeliverBallOnPositionSix()
        {
            var sortRail = new SortRail();

            var moveToSixCommand = new RobotMoveToPosition(_robot, sortRail, BallPosition.Six);
            moveToSixCommand.Execute();

            var liftBallCommand = new RobotLiftBall(_robot);
            liftBallCommand.Execute();

            var moveBackHomeCommand = new RobotMoveToPosition(_robot, sortRail, BallPosition.Home);
            moveBackHomeCommand.Execute();
        }

        [TestMethod]
        public void ShouldLiftBallAndFallBack()
        {
            var command = new RobotLiftBall(_robot);
            command.Execute();
        }

        [TestMethod]
        public void ShouldDropBallAndTurnBack()
        {
            var command = new RobotDropBall(_robot);
            command.Execute();
        }

        [TestMethod]
        public void ShouldMoveTheRobotForwardToPos8()
        {
            var sortRail = new SortRail();

            var commandEight = new RobotMoveToPosition(_robot, sortRail, BallPosition.Eight);
            commandEight.Execute();
        }
    }
}