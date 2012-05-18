using System;
using System.Diagnostics;
using SortAlgoBot.Helpers;

namespace SortAlgoBot.Commands
{
	public class RobotMoveToPosition : IRobotCommand
	{
		private readonly BallPosition _position;
		private readonly SortRobot _robot;
		private readonly SortRail _sortRail;

		public RobotMoveToPosition(SortRobot robot, SortRail sortRail, BallPosition position)
		{
			_robot = robot;
			_sortRail = sortRail;
			_position = position;
		}
		#region IRobotCommand Members

		public void Execute()
		{
			int tacho = _sortRail.GetTachoToPosition(_position);
			MotorDirection motorDirection = MotorHelper.SetMotorDirection(tacho);
			var absTacho = (uint) Math.Abs(tacho);

			if (absTacho != 0)
			{
				Debug.WriteLine("Go to ball {0} (tacho {1})",
				                _position, tacho);

				int resultTacho = MotorHelper.RunAndWaitOnCompletion(
					_robot.DriveGear,
					absTacho,
					motorDirection);

				_sortRail.CurrentTacho += resultTacho;
			}
		}

		#endregion
	}
}