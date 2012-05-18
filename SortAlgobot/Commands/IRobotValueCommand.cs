namespace SortAlgoBot.Commands
{
	public interface IRobotValueCommand : IRobotCommand
	{
		int Result { get; set; }
	}
}