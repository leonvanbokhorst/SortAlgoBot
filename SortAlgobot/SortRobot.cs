using System;
using System.Threading;
using NKH.MindSqualls;
using NKH.MindSqualls.MotorControl;

namespace SortAlgoBot
{
	public class SortRobot : IDisposable
	{
		private readonly McNxtBrick _brick;

		public SortRobot()
		{
			_brick = new McNxtBrick(NxtCommLinkType.USB, 0)
			         	{
			         		MotorA = new McNxtMotor(),
			         		MotorB = new McNxtMotor(),
			         		MotorC = new McNxtMotor(),
			         		Sensor3 = new Nxt2ColorSensor()
			         	};

			Brick.Connect();
			Brick.CommLink.KeepAlive();

			if (!Brick.IsMotorControlRunning())
			{
				Brick.StartMotorControl();
			}
		}

		public Nxt2ColorSensor ColorSensor
		{
			get { return (Nxt2ColorSensor) _brick.Sensor3; }
		}

		public McNxtMotor BallDropper
		{
			get { return (McNxtMotor) _brick.MotorC; }
		}

		public McNxtMotor BallLift
		{
			get { return (McNxtMotor) _brick.MotorB; }
		}

		public McNxtMotor DriveGear
		{
			get { return (McNxtMotor) _brick.MotorA; }
		}

		public McNxtBrick Brick
		{
			get { return _brick; }
		}
		#region IDisposable Members

		public void Dispose()
		{
			if (Brick.IsMotorControlRunning())
			{
				Brick.StopMotorControl();
			}

			Thread.Sleep(1000);
			Brick.Disconnect();
		}

		#endregion
	}
}