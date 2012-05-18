using SortAlgoBot.Common;

namespace SortAlgoBot.Algorithms
{
    public interface IRoboSortAlgorithm
    {
        event SortAlgoEventHandler PivotPicked;
        event SortAlgoEventHandler Swap;
        event SortAlgoEventHandler Done;
        void OnDone(int leftPointer, int rightPointer);
        void OnSwap(int leftPointer, int rightpointer);
        void OnPivotPicked(int leftPointer, int rightPointer);
        void Execute();
    }
}