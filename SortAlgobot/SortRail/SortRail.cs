using System.Collections.Generic;
using SortAlgoBot.Exceptions;

namespace SortAlgoBot.SortRail
{
    public class SortRail : Dictionary<RailPosition, SortRailLegoPosition>
    {
        private const int TachoPerPosition = 110;
        private int _currentTacho;

        public SortRail()
        {
            CurrentTacho = 0;

            Add(RailPosition.Home, new SortRailLegoPosition(0));
            Add(RailPosition.One, new SortRailLegoPosition(9));
            Add(RailPosition.Two, new SortRailLegoPosition(12));
            Add(RailPosition.Three, new SortRailLegoPosition(15));
            Add(RailPosition.Four, new SortRailLegoPosition(18));
            Add(RailPosition.Five, new SortRailLegoPosition(21));
            Add(RailPosition.Six, new SortRailLegoPosition(24));
            Add(RailPosition.Seven, new SortRailLegoPosition(27));
            Add(RailPosition.Eight, new SortRailLegoPosition(30));
            Add(RailPosition.Nine, new SortRailLegoPosition(33));
            Add(RailPosition.Ten, new SortRailLegoPosition(36));
            Add(RailPosition.Eleven, new SortRailLegoPosition(39));
            Add(RailPosition.Twelve, new SortRailLegoPosition(42));
            Add(RailPosition.Pivot, new SortRailLegoPosition(45));
        }

        public int CurrentTacho
        {
            get { return _currentTacho; }
            set
            {
                ValidateTachoBounderies(value);
                _currentTacho = value;
            }
        }

        public int GetTachoToPosition(RailPosition position)
        {
            SortRailLegoPosition sortRailPosition = this[position];
            int absoluteTachoToPosition =
                sortRailPosition.Position*TachoPerPosition;
            int result = absoluteTachoToPosition - CurrentTacho;

            return result;
        }

        private void ValidateTachoBounderies(int value)
        {
            if (ContainsKey(RailPosition.Pivot)
                && ContainsKey(RailPosition.Home))
            {
                int upperBoundery =
                    this[RailPosition.Pivot].Position*TachoPerPosition;
                int lowerBoundery =
                    this[RailPosition.Home].Position*TachoPerPosition;

                if (value < lowerBoundery || value > upperBoundery)
                    throw new TachoOutOfBoundsException();
            }
        }
    }
}