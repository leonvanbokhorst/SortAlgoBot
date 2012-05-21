using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortAlgoBot;
using SortAlgoBot.Algorithms;
using SortAlgoBot.Commands;
using SortAlgoBot.Helpers;
using SortAlgoBot.Sequences;

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

            // mock
            //_sortRail.SortList = new List<int>{3,2,5,4,5,4,3,3,2,5,2,4};

            var sortAlgorithm = new RoboSortAlgorithm(_sortRail.SortList);

            sortAlgorithm.PivotPicked += AlgoPivotPicked;
            sortAlgorithm.Swap += AlgoSwap;
            sortAlgorithm.Done += AlgoDone;

            sortAlgorithm.Execute();
        }

        private void AlgoDone(int leftPointer, int rightPointer)
        {
            var goHomeCommand = new RobotMoveToPosition(_robot, _sortRail, BallPosition.Home);
            goHomeCommand.Execute();
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
    }
}