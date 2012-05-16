using NKH.MindSqualls.MotorControl;

namespace SortAlgoBot.Commands
{
    public interface IRobotCommand
    {
        void Execute(McNxtBrick brick, SortRail sortRail, BallPosition position);
    }
}