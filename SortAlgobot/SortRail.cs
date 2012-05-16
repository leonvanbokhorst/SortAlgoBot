using System;
using System.Collections.Generic;
using SortAlgoBot.Exceptions;

namespace SortAlgoBot
{
    public class SortRail : Dictionary<BallPosition, SortRailLegoPosition>
    {
        private const int TachoPerPosition = 110;
        private int _currentTacho;

        public SortRail()
        {
            CurrentTacho = 0;

            Add(BallPosition.Home, new SortRailLegoPosition(0));
            Add(BallPosition.One, new SortRailLegoPosition(9));
            Add(BallPosition.Two, new SortRailLegoPosition(12));
            Add(BallPosition.Three, new SortRailLegoPosition(15));
            Add(BallPosition.Four, new SortRailLegoPosition(18));
            Add(BallPosition.Five, new SortRailLegoPosition(21));
            Add(BallPosition.Six, new SortRailLegoPosition(24));
            Add(BallPosition.Seven, new SortRailLegoPosition(27));
            Add(BallPosition.Eight, new SortRailLegoPosition(30));
            Add(BallPosition.Nine, new SortRailLegoPosition(33));
            Add(BallPosition.Ten, new SortRailLegoPosition(36));
            Add(BallPosition.Eleven, new SortRailLegoPosition(39));
            Add(BallPosition.Twelve, new SortRailLegoPosition(42));
            Add(BallPosition.Pivot, new SortRailLegoPosition(45));
        }

        public int CurrentTacho
        {
            get { return _currentTacho; }
            set
            {
                var validatedValue = ValidateTachoBounderies(value);
                _currentTacho = validatedValue;
            }
        }

        public int GetTachoToPosition(BallPosition position)
        {
            SortRailLegoPosition sortRailPosition = this[position];
            int absoluteTachoToPosition =
                sortRailPosition.Position * TachoPerPosition;
            int result = absoluteTachoToPosition - CurrentTacho;

            return result;
        }

        private int ValidateTachoBounderies(int value)
        {
            var result = 0;

            if (ContainsKey(BallPosition.Pivot)
                && ContainsKey(BallPosition.Home))
            {
                int upperBoundery =
                    this[BallPosition.Pivot].Position * TachoPerPosition;
                int lowerBoundery =
                    this[BallPosition.Home].Position * TachoPerPosition;

                if (_currentTacho + value < lowerBoundery || _currentTacho + value > upperBoundery)
                {
                    if (value < 0)
                        result =
                            this[BallPosition.Home].Position * TachoPerPosition;
                    else
                        result =
                            this[BallPosition.Pivot].Position * TachoPerPosition;
                }
                else
                {
                    result = value;
                }

            }

            return result;
        }
    }
}