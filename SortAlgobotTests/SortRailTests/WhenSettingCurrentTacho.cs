using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortAlgoBot.Exceptions;
using SortAlgoBot.SortRail;

namespace SortAlgobotTests.SortRailTests
{
    public partial class SortRailTests
    {
        #region Nested type: WhenSettingCurrentTacho

        [TestClass]
        public class WhenSettingCurrentTacho
        {
            [TestMethod]
            [ExpectedException(typeof (TachoOutOfBoundsException))]
            public void ShouldThrowExceptionWhenCurrentTachoGetsBelowZero()
            {
                // Arange
                var sortRail = new SortRail();
                const int tooLowTachoValue = -1;

                // Act
                sortRail.CurrentTacho = tooLowTachoValue;

                // Assert
                // Should catch exception
            }

            [TestMethod]
            [ExpectedException(typeof (TachoOutOfBoundsException))]
            public void ShouldThrowExceptionWhenCurrentTachoGetsAbove4950()
            {
                // Arange
                var sortRail = new SortRail();
                const int tooHighTachoValue = 4951;

                // Act
                sortRail.CurrentTacho = tooHighTachoValue;

                // Assert
                // Should catch exception
            }
        }

        #endregion
    }
}