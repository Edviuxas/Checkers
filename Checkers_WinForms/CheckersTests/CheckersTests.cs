using Checkers_WinForms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace CheckersTests
{
    [TestClass]
    public class CheckersTests
    {
        [TestMethod]
        public void CheckIfCheckerShouldBeKing_Player2_ReturnsTrue()
        {
            Player player2 = new Player2();
            Checker checker = new Checker() { Position = new System.Drawing.Point(5, 2) };

            var result = player2.CheckIfCheckerShouldBeKing(checker);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckIfCheckerShouldBeKing_Player2_ReturnsFalse()
        {
            Player player1 = new Player1();
            Checker checker = new Checker() { Position = new Point(5, 5) };

            var result = player1.CheckIfCheckerShouldBeKing(checker);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckIfMoveIsValid_ValidKingMove_ReturnsTrue()
        {
            Player player1 = new Player1();
            Checker checker = new Checker() { Position = new Point(2, 2), IsKing = true };
            Point clickedLocation = new Point(3, 3);

            var result = player1.IsValidMove(checker, clickedLocation);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckIfMoveIsValid_InvalidMovePlayer1_ReturnsFalse()
        {
            Player player1 = new Player1();
            Checker checker = new Checker() { Position = new Point(3, 3), IsKing = false };
            Point clickedLocation = new Point(2, 2);

            var result = player1.IsValidMove(checker, clickedLocation);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckIfMoveIsValid_ValidMovePlayer2_ReturnsTrue()
        {
            Player player2 = new Player2();
            Checker checker = new Checker() { Position = new Point(3, 3), IsKing = false };
            Point clickedLocation = new Point(2, 2);

            var result = player2.IsValidMove(checker, clickedLocation);

            Assert.IsTrue(result);
        }

    }
}
