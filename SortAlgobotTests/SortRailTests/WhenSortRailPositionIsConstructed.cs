using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortAlgoBot.Exceptions;
using SortAlgoBot.SortRail;

namespace SortAlgobotTests.SortRailTests
{
    public partial class SortRailTests
    {
        #region Nested type: WhenSortRailPositionIsConstructed

        [TestClass]
        public class WhenSortRailPositionIsConstructed
        {
            [TestMethod]
            [ExpectedException(typeof (LegoPositionOutOfBoundsException))]
            public void ShouldFailOnNegativePosition()
            {
                // Arange
                const int tooLowValue = -1;

                // Act
                var sortRailPosition = new SortRailLegoPosition(tooLowValue);
            }

            [TestMethod]
            [ExpectedException(typeof (LegoPositionOutOfBoundsException))]
            public void ShouldFailOnPositionLargerThan45()
            {
                // Arange
                const int tooHighValue = 46;

                // Act
                var sortRailPosition = new SortRailLegoPosition(tooHighValue);
            }
        }

        #endregion
    }
}