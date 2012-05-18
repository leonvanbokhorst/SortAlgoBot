using System.Collections.Generic;

namespace SortAlgoBot
{
    public class SortRail : Dictionary<BallPosition, SortRailLegoPosition>
    {
        private const int TachoPerPosition = 110;
        private readonly int _lowerBoundery;
        private readonly int _upperBoundery;
        private int _currentTacho;

        public SortRail()
        {
            CurrentTacho = 0;
            SortList = new List<int> {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};

            Add(BallPosition.Home, new SortRailLegoPosition(0));
            Add(BallPosition.Zero, new SortRailLegoPosition(6));
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
            Add(BallPosition.Swap, new SortRailLegoPosition(45));

            _upperBoundery =
                this[BallPosition.Swap].Position * TachoPerPosition;
            _lowerBoundery =
                this[BallPosition.Home].Position * TachoPerPosition;
        }

        public List<int> SortList { get; set; }

        public int CurrentTacho
        {
            get { return _currentTacho; }
            set
            {
                if (value < _lowerBoundery)
                {
                    value = _lowerBoundery;
                }

                if (value > _upperBoundery)
                {
                    value = _upperBoundery;
                }

                _currentTacho = value;
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
    }
}