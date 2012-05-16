using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortAlgoBot;

namespace SortAlgobotTests.SortRailTests
{
    public partial class SortRailTests
    {
        #region Nested type: WhenQueryingForPositions

        [TestClass]
        public class WhenQueryingForPositions
        {
            [TestMethod]
            [ExpectedException(typeof (KeyNotFoundException))]
            public void ShouldFailOnPosition15()
            {
                // Arange
                var sortRail = new SortRail();

                // Act
                SortRailLegoPosition result = sortRail[(BallPosition) 15];
            }

            [TestMethod]
            public void ShouldReturnPositionTacho15OnBall3()
            {
                // Arange
                var sortRail = new SortRail();
                const int excpected = 15;

                // Act
                SortRailLegoPosition result = sortRail[BallPosition.Three];

                // Assert
                Assert.AreEqual(excpected, result.Position);
            }

            [TestMethod]
            public void ShouldReturnPositionTacho0OnBallHome()
            {
                // Arange
                var sortRail = new SortRail();
                const int excpected = 0;

                // Act
                SortRailLegoPosition result = sortRail[BallPosition.Home];

                // Assert
                Assert.AreEqual(excpected, result.Position);
            }

            [TestMethod]
            public void ShouldReturnPositionTacho45OnBallPivot()
            {
                // Arange
                var sortRail = new SortRail();
                const int excpected = 45;

                // Act
                SortRailLegoPosition result = sortRail[BallPosition.Pivot];

                // Assert
                Assert.AreEqual(excpected, result.Position);
            }
        }

        #endregion
    }
}