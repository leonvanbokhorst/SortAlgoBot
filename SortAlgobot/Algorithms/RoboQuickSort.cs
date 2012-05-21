using System.Collections.Generic;
using SortAlgoBot.Common;

namespace SortAlgoBot.Algorithms
{
    public class RoboSortAlgorithm : IRoboSortAlgorithm
    {
        private readonly List<int> _sortList;

        public RoboSortAlgorithm(List<int> unsortedList)
        {
            _sortList = unsortedList;
        }

        #region IRoboSortAlgorithm Members

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

        public void OnPivotPicked(int leftPointer, int rightPointer)
        {
            SortAlgoEventHandler handler = PivotPicked;

            if (handler != null)
            {
                handler(leftPointer, rightPointer);
            }
        }

        public void Execute()
        {
            QuickSort(0, _sortList.Count-1);
            OnDone(0,0);
        }

        #endregion

        private void QuickSort(int leftIndex, int rightIndex)
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
        }
    }
}