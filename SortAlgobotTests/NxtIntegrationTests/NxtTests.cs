using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NKH.MindSqualls;
using NKH.MindSqualls.MotorControl;
using SortAlgoBot;
using SortAlgoBot.Commands;

namespace SortAlgobotTests.NxtIntegrationTests
{
    [TestClass]
    public class NxtTests
    {
        private McNxtBrick _brick;

        [TestInitialize]
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

        [TestCleanup]
        public void CleanupRobot()
        {
            if (_brick.IsMotorControlRunning())
                _brick.StopMotorControl();

            Thread.Sleep(1000);
            _brick.Disconnect();
        }

        [TestMethod]
        public void ShouldReadColorBallOnPositionSix()
        {
            var sortRail = new SortRail();

            var c1 = new RobotToPositionCommand();
            c1.Execute(_brick, sortRail, BallPosition.Six-1);

            var command = new RobotReadColorCommand();
            command.Execute(_brick, null, BallPosition.Home);

            var c2 = new RobotToPositionCommand();
            c2.Execute(_brick, sortRail, BallPosition.Home);
        }

        [TestMethod]
        public void ShouldDeliverBallOnPositionSix()
        {
            var sortRail = new SortRail();

            var c1 = new RobotToPositionCommand();
            c1.Execute(_brick, sortRail, BallPosition.Six);

            var command = new RobotLiftBallCommand();
            command.Execute(_brick, null, BallPosition.Home);

            var c2 = new RobotToPositionCommand();
            c2.Execute(_brick, sortRail, BallPosition.Home);
        }

        [TestMethod]
        public void ShouldLiftBallAndFallBack()
        {
            var command = new RobotLiftBallCommand();
            command.Execute(_brick, null, BallPosition.Home);
        }

        [TestMethod]
        public void ShouldDropBallAndTurnBack()
        {
            var command = new RobotDropBallCommand();
            command.Execute(_brick, null, BallPosition.Home);
        }

        [TestMethod]
        public void ShouldMoveTheRobotForwardToPos8AndBackHome()
        {
            var sortRail = new SortRail();

            var commandEight = new RobotToPositionCommand();
            commandEight.Execute(_brick, sortRail, BallPosition.Eight);

            var commandBack = new RobotToPositionCommand();
            commandBack.Execute(_brick, sortRail, BallPosition.Home);
        }

        [TestMethod]
        public void ShouldMoveTheRobotForwardToPos3And6AndBack1()
        {
            var sortRail = new SortRail();

            var command1 = new RobotToPositionCommand();
            command1.Execute(_brick, sortRail, BallPosition.Two);

            var command2 = new RobotToPositionCommand();
            command2.Execute(_brick, sortRail, BallPosition.One);

            var command3 = new RobotToPositionCommand();
            command3.Execute(_brick, sortRail, BallPosition.Three);

            var c4 = new RobotToPositionCommand();
            c4.Execute(_brick, sortRail, BallPosition.Seven);

            var c5 = new RobotToPositionCommand();
            c5.Execute(_brick, sortRail, BallPosition.Nine);

            var c6 = new RobotToPositionCommand();
            c6.Execute(_brick, sortRail, BallPosition.Eight);

            var c7 = new RobotToPositionCommand();
            c7.Execute(_brick, sortRail, BallPosition.Twelve);

            var c8 = new RobotToPositionCommand();
            c8.Execute(_brick, sortRail, BallPosition.Ten);

            var c9 = new RobotToPositionCommand();
            c9.Execute(_brick, sortRail, BallPosition.Eleven);

            var c13 = new RobotToPositionCommand();
            c13.Execute(_brick, sortRail, BallPosition.Four);

            var c10 = new RobotToPositionCommand();
            c10.Execute(_brick, sortRail, BallPosition.Six);

            var c11 = new RobotToPositionCommand();
            c11.Execute(_brick, sortRail, BallPosition.Five);

            var c12 = new RobotToPositionCommand();
            c12.Execute(_brick, sortRail, BallPosition.Home);

        }
    }
}