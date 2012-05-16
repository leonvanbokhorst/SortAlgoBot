using SortAlgoBot.Exceptions;

namespace SortAlgoBot
{
    public class SortRailLegoPosition
    {
        public SortRailLegoPosition(int position)
        {
            if (position < 0 || position > 45)
                throw new LegoPositionOutOfBoundsException();

            Position = position;
        }

        public int Position { get; private set; }
    }
}