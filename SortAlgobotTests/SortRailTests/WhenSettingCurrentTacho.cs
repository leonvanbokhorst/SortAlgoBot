using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortAlgoBot;

namespace SortAlgobotTests.SortRailTests
{
    public partial class SortRailTests
    {
        #region Nested type: WhenSettingCurrentTacho

        [TestClass]
        public class WhenSettingCurrentTacho
        {
            //[TestMethod]
            public void Should0WhenCurrentTachoIsSetBelowZero()
            {
                // Arange
                var sortRail = new SortRail();
                const int tooLowTachoValue = -1;
                const int expected = 0;

                // Act
                sortRail.CurrentTacho = tooLowTachoValue;

                // Assert
                Assert.AreEqual(expected, sortRail.CurrentTacho);
            }

            //[TestMethod]
            public void ShouldBe4950WhenCurrentTachoIsSetAbove4950()
            {
                // Arange
                var sortRail = new SortRail();
                const int tooHighTachoValue = 4951;
                const int expected = 4950;

                // Act
                sortRail.CurrentTacho = tooHighTachoValue;

                // Assert
                Assert.AreEqual(expected, sortRail.CurrentTacho);
            }

            [TestMethod]
            public void ShouldBe1000WhenCurrentTachoIsSetTo1000()
            {
                // Arange
                var sortRail = new SortRail();
                const int setValue = 1000;
                const int expected = 1000;

                // Act
                sortRail.CurrentTacho += setValue;

                // Assert
                Assert.AreEqual(expected, sortRail.CurrentTacho);
            }
        }

        #endregion
    }
}