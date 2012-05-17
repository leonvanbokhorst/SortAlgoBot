using System.Collections.Generic;
using System.Threading;
using NKH.MindSqualls;
using NKH.MindSqualls.MotorControl;
using SortAlgoBot.Commands;

namespace SortAlgoBot.Algorithms
{
    public class RoboSortAlgorithm
    {
        private readonly List<int> _sortList = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private McNxtBrick _brick;
        private SortRail _sortRail;

        public RoboSortAlgorithm()
        {
            InitRobot();
            _sortRail = new SortRail();
        }

        public void InitRobot()
        {
            _brick = new McNxtBrick(NxtCommLinkType.USB, 0)
            {
                MotorA = new McNxtMotor(),
                MotorB = new McNxtMotor(),
                MotorC = new McNxtMotor(),
                Sensor3 = new Nxt2ColorSensor()
            };

            _brick.Connect();
            _brick.CommLink.KeepAlive();

            if (!_brick.IsMotorControlRunning())
                _brick.StartMotorControl();
        }

        public void CleanupRobot()
        {
            if (_brick.IsMotorControlRunning())
                _brick.StopMotorControl();

            Thread.Sleep(1000);
            _brick.Disconnect();
        }

        public List<int> QuickSort(int leftIndex, int rightIndex)
        {
            int leftPointer;
            int rightPointer;
            int pivot;
            int swapValue;

            leftPointer = leftIndex;
            rightPointer = rightIndex;

            // TODO ROBOT ACTION
            RobotGotoIndexPositionAndReadStoreColor(leftIndex);
            pivot = _sortList[leftIndex];

            //RobotGoHome();

            while (leftPointer <= rightPointer)
            {
                while (RobotGotoIndexPositionAndReadStoreColor(leftPointer) && _sortList[leftPointer] < pivot)
                {
                    leftPointer++;
                }

                while (RobotGotoIndexPositionAndReadStoreColor(rightPointer) && pivot < _sortList[rightPointer])
                {
                    rightPointer--;
                }

                if (leftPointer <= rightPointer)
                {
                    // Enkel in geval van ongelijke waarden
                    if (_sortList[leftPointer] != _sortList[rightPointer])
                    {
                        swapValue = _sortList[leftPointer];
                        _sortList[leftPointer] = _sortList[rightPointer];
                        _sortList[rightPointer] = swapValue;

                        // TODO ACTION Bring to swap
                        // Ga naar leftpointer position
                        var c2 = new RobotToPositionCommand();
                        c2.Execute(_brick, _sortRail, GetBallPosition(leftPointer));

                        // Drop leftpointer bal
                        var c3 = new RobotDropBallCommand();
                        c3.Execute(_brick);

                        // Ga naar Swap
                        var c4 = new RobotToPositionCommand();
                        c4.Execute(_brick, _sortRail, BallPosition.Swap);

                        // Lift bal in positie
                        var c5 = new RobotLiftBallCommand();
                        c5.Execute(_brick);

                        // TODO ACTION wissel
                        // Haal rightpointer op
                        var c6 = new RobotToPositionCommand();
                        c6.Execute(_brick, _sortRail, GetBallPosition(rightPointer));

                        // Drop rightpointer bal
                        var c7 = new RobotDropBallCommand();
                        c7.Execute(_brick);

                        // Ga naar leftpointer positie
                        var c8 = new RobotToPositionCommand();
                        c8.Execute(_brick, _sortRail, GetBallPosition(leftPointer));

                        // Lift bal in positie
                        var c9 = new RobotLiftBallCommand();
                        c9.Execute(_brick);

                        // TODO ACTION swap terug
                        // Haal swap op
                        var c10 = new RobotToPositionCommand();
                        c10.Execute(_brick, _sortRail, BallPosition.Swap);

                        // Drop swap bal
                        var c11 = new RobotDropBallCommand();
                        c11.Execute(_brick);

                        // Ga naar rightpointer positie
                        var c12 = new RobotToPositionCommand();
                        c12.Execute(_brick, _sortRail, GetBallPosition(rightPointer));

                        // Lift bal in positie
                        var c13 = new RobotLiftBallCommand();
                        c13.Execute(_brick);

                        // TODO ACTION
                        //RobotGoHome();
                    }

                    leftPointer++;
                    rightPointer--;
                }
            }

            if (leftIndex < rightPointer)
            {
                QuickSort(leftIndex, rightPointer);
            }

            if (leftPointer < rightIndex)
            {
                QuickSort(leftPointer, rightIndex);
            }

            return _sortList;
        }

        public void RobotGoHome()
        {
            var goHome = new RobotToPositionCommand();
            goHome.Execute(_brick, _sortRail, BallPosition.Home);
        }

        private bool RobotGotoIndexPositionAndReadStoreColor(int index)
        {
            // Ga naar leftindex 
            BallPosition leftIndexColorPosition = GetColorPosition(index);
            var c1 = new RobotToPositionCommand();
            c1.Execute(_brick, _sortRail, leftIndexColorPosition);
            // Lees Pivot kleur 
            var c2 = new RobotReadColorCommand();
            var pivotColor = c2.Execute(_brick);
            // en sla op als waarde 0 is
            if (_sortList[index] == 0)
                _sortList[index] = (int)pivotColor;

            return true;
        }

        private BallPosition GetBallPosition(int leftIndex)
        {
            return (BallPosition)(leftIndex + 2);
        }

        private BallPosition GetColorPosition(int leftIndex)
        {
            return (BallPosition)(leftIndex + 1);
        }
    }
}