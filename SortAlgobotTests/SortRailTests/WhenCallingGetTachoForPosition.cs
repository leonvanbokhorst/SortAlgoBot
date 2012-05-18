using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortAlgoBot;

namespace SortAlgobotTests.SortRailTests
{
    public partial class SortRailTests
    {
        #region Nested type: WhenCallingGetTachoForPosition

        [TestClass]
        public class WhenCallingGetTachoForPosition
        {
            [TestMethod]
            [ExpectedException(typeof (KeyNotFoundException))]
            public void ShouldFailOnPosition15()
            {
                // Arange
                var sortRail = new SortRail();

                // Act
                sortRail.GetTachoToPosition((BallPosition) 15);

                // Assert
                // Expected exception thrown
            }

            [TestMethod]
            public void ShouldReturn0ForBallHomeByCurrentTacho0()
            {
                // Arange
                var sortRail = new SortRail {CurrentTacho = 0};
                const int expected = 0;

                // Act
                int result = sortRail.GetTachoToPosition(BallPosition.Home);

                // Assert
                Assert.AreEqual(expected, result);
            }

            [TestMethod]
            public void ShouldReturn2640ForBall6ByCurrentTacho0()
            {
                // Arange
                var sortRail = new SortRail {CurrentTacho = 0};
                const int expected = 2640;

                // Act
                int result = sortRail.GetTachoToPosition(BallPosition.Six);

                // Assert
                Assert.AreEqual(expected, result);
            }

            [TestMethod]
            public void ShouldReturn4950ForBallPivotByCurrentTacho0()
            {
                // Arange
                var sortRail = new SortRail {CurrentTacho = 0};
                const int expected = 4950;

                // Act
                int result = sortRail.GetTachoToPosition(BallPosition.Swap);

                // Assert
                Assert.AreEqual(expected, result);
            }

            [TestMethod]
            public void ShouldReturn0ForBallPivotByCurrentTacho4950()
            {
                // Arange
                var sortRail = new SortRail {CurrentTacho = 4950};
                const int expected = 0;

                // Act
                int result = sortRail.GetTachoToPosition(BallPosition.Swap);

                // Assert
                Assert.AreEqual(expected, result);
            }

            [TestMethod]
            public void ShouldReturn0ForBallPivotByCurrentTacho2640()
            {
                // Arange
                var sortRail = new SortRail {CurrentTacho = 2640};
                const int expected = 0;

                // Act
                int result = sortRail.GetTachoToPosition(BallPosition.Six);

                // Assert
                Assert.AreEqual(expected, result);
            }

            [TestMethod]
            public void ShouldReturnMin1000ForBallHomeByCurrentTacho1000()
            {
                // Arange
                var sortRail = new SortRail {CurrentTacho = 1000};
                const int expected = -1000;

                // Act
                int result = sortRail.GetTachoToPosition(BallPosition.Home);

                // Assert
                Assert.AreEqual(expected, result);
            }

            [TestMethod]
            public void ShouldReturnMin1000ForBall6ByCurrentTacho3640()
            {
                // Arange
                var sortRail = new SortRail {CurrentTacho = 3640};
                const int expected = -1000;

                // Act
                int result = sortRail.GetTachoToPosition(BallPosition.Six);

                // Assert
                Assert.AreEqual(expected, result);
            }

            [TestMethod]
            public void ShouldReturn1000ForBall6ByCurrentTacho1640()
            {
                // Arange
                var sortRail = new SortRail {CurrentTacho = 1640};
                const int expected = 1000;

                // Act
                int result = sortRail.GetTachoToPosition(BallPosition.Six);

                // Assert
                Assert.AreEqual(expected, result);
            }
        }

        #endregion
    }
}