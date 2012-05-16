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
        [TestMethod]
        public void ShouldMoveTheRobotForwardToPos8AndBackHome()
        {
            var brick = new McNxtBrick(NxtCommLinkType.USB, 0);
            brick.Connect();
            brick.CommLink.KeepAlive();
            brick.MotorA = new McNxtMotor();
            var sortRail = new SortRail();

            if (!brick.IsMotorControlRunning())
                brick.StartMotorControl();

            var commandEight = new RobotToPosition();
            commandEight.Execute(brick, sortRail, BallPosition.Eight);

            var commandBack = new RobotToPosition();
            commandBack.Execute(brick, sortRail, BallPosition.Home);

            if (brick.IsMotorControlRunning())
                brick.StopMotorControl();

            Thread.Sleep(1000);
            brick.Disconnect();
        }

        [TestMethod]
        public void ShouldMoveTheRobotForwardToPos3And6AndBack1()
        {
            var brick = new McNxtBrick(NxtCommLinkType.USB, 0);
            brick.Connect();
            brick.CommLink.KeepAlive();
            brick.MotorA = new McNxtMotor();
            var sortRail = new SortRail();

            if (!brick.IsMotorControlRunning())
                brick.StartMotorControl();

            var command1 = new RobotToPosition();
            command1.Execute(brick, sortRail, BallPosition.Two);

            var command2 = new RobotToPosition();
            command2.Execute(brick, sortRail, BallPosition.One);

            var command3 = new RobotToPosition();
            command3.Execute(brick, sortRail, BallPosition.Three);

            var c4 = new RobotToPosition();
            c4.Execute(brick, sortRail, BallPosition.Seven);

            var c5 = new RobotToPosition();
            c5.Execute(brick, sortRail, BallPosition.Nine);

            var c6 = new RobotToPosition();
            c6.Execute(brick, sortRail, BallPosition.Eight);

            var c7 = new RobotToPosition();
            c7.Execute(brick, sortRail, BallPosition.Twelve);

            var c8 = new RobotToPosition();
            c8.Execute(brick, sortRail, BallPosition.Ten);

            var c9 = new RobotToPosition();
            c9.Execute(brick, sortRail, BallPosition.Eleven);

            var c13 = new RobotToPosition();
            c13.Execute(brick, sortRail, BallPosition.Four);

            var c10 = new RobotToPosition();
            c10.Execute(brick, sortRail, BallPosition.Six);

            var c11 = new RobotToPosition();
            c11.Execute(brick, sortRail, BallPosition.Five);

            var c12 = new RobotToPosition();
            c12.Execute(brick, sortRail, BallPosition.Home);

            if (brick.IsMotorControlRunning())
                brick.StopMotorControl();

            Thread.Sleep(1000);
            brick.Disconnect();
        }
    }
}