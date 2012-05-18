using System.Collections.Generic;

namespace SortAlgoBot.Algorithms
{
    public class RoboSortAlgorithm
    {
        //#region Delegates

        #region Delegates

        public delegate void SortAlgoEventHandler(int leftPointer, int rightPointer);

        #endregion

        //#endregion
        private readonly List<int> _sortList;
        private readonly SortRail _sortRail;

        public RoboSortAlgorithm(List<int> unsortedList)
        {
            _sortList = unsortedList;
            _sortRail = new SortRail();
        }

        public List<int> QuickSort(int leftIndex, int rightIndex)
        {
            int leftPointer = leftIndex;
            int rightPointer = rightIndex;
            int pivot = _sortList[leftIndex];

            OnPivotPicked(leftPointer, rightPointer);

            while (leftPointer <= rightPointer)
            {
                while (_sortList[leftPointer] < pivot)
                {
                    leftPointer++;
                }

                while (pivot < _sortList[rightPointer])
                {
                    rightPointer--;
                }

                if (leftPointer <= rightPointer)
                {
                    if (_sortList[leftPointer] != _sortList[rightPointer])
                    {
                        int swapValue = _sortList[leftPointer];
                        _sortList[leftPointer] = _sortList[rightPointer];
                        _sortList[rightPointer] = swapValue;

                        OnSwap(leftPointer, rightPointer);
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

        public event SortAlgoEventHandler PivotPicked;
        public event SortAlgoEventHandler Swap;
        public event SortAlgoEventHandler Done;

        public void OnDone(int leftPointer, int rightPointer)
        {
            SortAlgoEventHandler handler = Done;

            if (handler != null)
            {
                handler(leftPointer, rightPointer);
            }
        }

        public void OnSwap(int leftPointer, int rightpointer)
        {
            SortAlgoEventHandler handler = Swap;

            if (handler != null)
            {
                handler(leftPointer, rightpointer);
            }
        }

        private void OnPivotPicked(int leftPointer, int rightPointer)
        {
            SortAlgoEventHandler handler = PivotPicked;

            if (handler != null)
            {
                handler(leftPointer, rightPointer);
            }
        }
    }
}