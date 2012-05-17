using System.Collections.Generic;

namespace SortAlgoBot.Algorithms
{
    public class RoboSortAlgorithm
    {
        private static int _leftPointer;
        private static int _rightPointer;
        private static int _pivot;
        private static int _swapValue;
        private static List<int> _sortList;

        public static List<int> QuickSort(int leftIndex, int rightIndex)
        {
            _leftPointer = leftIndex;
            _rightPointer = rightIndex;
            _pivot = _sortList[leftIndex];

            while (_leftPointer <= _rightPointer)
            {
                while (_sortList[_leftPointer] < _pivot)
                {
                    _leftPointer++;
                }

                while (_pivot < _sortList[_rightPointer])
                {
                    _rightPointer--;
                }

                if (_leftPointer <= _rightPointer)
                {
                    // Toegevoegd: Enkel in geval van ongelijke waarden
                    //if (sortList[leftPointer] != sortList[rightPointer])
                    //{

                    _swapValue = _sortList[_leftPointer];

                    _sortList[_leftPointer] = _sortList[_rightPointer];
                    _sortList[_rightPointer] = _swapValue;

                    //}
                    //else
                    //{
                    //    lozeStap++;
                    //}

                    _leftPointer++;
                    _rightPointer--;
                }
            }

            if (leftIndex < _rightPointer)
            {
                QuickSort(leftIndex, _rightPointer);
            }

            if (_leftPointer < rightIndex)
            {
                QuickSort(_leftPointer, rightIndex);
            }

            return _sortList;
        }
    }
}