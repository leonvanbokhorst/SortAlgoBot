using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortAlgoBot;

namespace SortAlgobotTests.SortRailTests
{
    public partial class SortRailTests
    {
        #region Nested type: WhenSortRailIsConstructed

        [TestClass]
        public class WhenSortRailIsConstructed
        {
            [TestMethod]
            public void ShouldHold15Positions()
            {
                // Arange
                var sortRail = new SortRail();
                const int expected = 15;

                // Act
                // None

                // Assert
                Assert.AreEqual(expected, sortRail.Count);
            }

            [TestMethod]
            public void ShouldHaveCurrentTachoZero()
            {
                // Arange
                var sortRail = new SortRail();
                const int expected = 0;

                // Act
                // None

                // Assert
                Assert.AreEqual(expected, sortRail.CurrentTacho);
            }
        }

        #endregion
    }
}