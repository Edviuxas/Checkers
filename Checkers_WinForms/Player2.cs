using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Checkers_WinForms
{
    class Player2
    {
        private List<Checker> playerCheckers = new List<Checker>();
        public static Bitmap checkerImage = Properties.Resources.Player2Tool;
        public static Bitmap kingCheckerImage = Properties.Resources.Player2Crown;

        internal List<Checker> PlayerCheckers { get => playerCheckers; set => playerCheckers = value; }

        public bool HasToJump(PictureBox[,] board)
        {
            foreach (Checker checker in playerCheckers)
            {
                if (!checker.IsKing)
                {
                    if (checker.Position.Y > 1)
                    {
                        if (checker.Position.X <= 1)
                        {
                            if (board[checker.Position.X + 2, checker.Position.Y - 2].Image == null)
                            {
                                if (board[checker.Position.X + 1, checker.Position.Y - 1].Image == Player1.checkerImage || board[checker.Position.X + 1, checker.Position.Y - 1].Image == Player1.kingCheckerImage)
                                    return true;
                            }
                        }
                        else if (checker.Position.X >= 6)
                        {
                            if (board[checker.Position.X - 2, checker.Position.Y - 2].Image == null)
                            {
                                if (board[checker.Position.X - 1, checker.Position.Y - 1].Image == Player1.checkerImage || board[checker.Position.X - 1, checker.Position.Y - 1].Image == Player1.kingCheckerImage)
                                    return true;
                            }
                        }
                        else
                        {
                            if (board[checker.Position.X + 2, checker.Position.Y - 2].Image == null)
                            {
                                if (board[checker.Position.X + 1, checker.Position.Y - 1].Image == Player1.checkerImage || board[checker.Position.X + 1, checker.Position.Y - 1].Image == Player1.kingCheckerImage)
                                    return true;
                            }
                            if (board[checker.Position.X - 2, checker.Position.Y - 2].Image == null)
                            {
                                if (board[checker.Position.X - 1, checker.Position.Y - 1].Image == Player1.checkerImage || board[checker.Position.X - 1, checker.Position.Y - 1].Image == Player1.kingCheckerImage)
                                    return true;
                            }
                            
                        }
                    }
                }
                else
                {
                    if (checker.Position.Y < 2 && checker.Position.X <= 1)
                    {
                        if (board[checker.Position.X + 2, checker.Position.Y + 2].Image == null)
                        {
                            if (board[checker.Position.X + 1, checker.Position.Y + 1].Image == Player1.checkerImage || board[checker.Position.X + 1, checker.Position.Y + 1].Image == Player1.kingCheckerImage)
                                return true;
                        }
                    }
                    else if (checker.Position.Y < 2 && checker.Position.X >= 6)
                    {
                        if (board[checker.Position.X - 2, checker.Position.Y + 2].Image == null)
                        {
                            if (board[checker.Position.X - 1, checker.Position.Y + 1].Image == Player1.checkerImage || board[checker.Position.X - 1, checker.Position.Y + 1].Image == Player1.kingCheckerImage)
                                return true;
                        }
                    }
                    else if (checker.Position.Y < 2 && checker.Position.X > 1 && checker.Position.X < 6)
                    {
                        if (board[checker.Position.X - 2, checker.Position.Y + 2].Image == null)
                        {
                            if (board[checker.Position.X - 1, checker.Position.Y + 1].Image == Player1.checkerImage || board[checker.Position.X - 1, checker.Position.Y + 1].Image == Player1.kingCheckerImage)
                                return true;
                        }
                        if (board[checker.Position.X + 2, checker.Position.Y + 2].Image == null)
                        {
                            if (board[checker.Position.X + 1, checker.Position.Y + 1].Image == Player1.checkerImage || board[checker.Position.X + 1, checker.Position.Y + 1].Image == Player1.kingCheckerImage)
                                return true;
                        }
                    }
                    else if (checker.Position.Y > 5 && checker.Position.X <= 1)
                    {
                        if (board[checker.Position.X + 2, checker.Position.Y - 2].Image == null)
                        {
                            if (board[checker.Position.X + 1, checker.Position.Y - 1].Image == Player1.checkerImage || board[checker.Position.X + 1, checker.Position.Y - 1].Image == Player1.kingCheckerImage)
                                return true;
                        }
                    }
                    else if (checker.Position.Y > 5 && checker.Position.X >= 6)
                    {
                        if (board[checker.Position.X - 2, checker.Position.Y - 2].Image == null)
                        {
                            if (board[checker.Position.X - 1, checker.Position.Y - 1].Image == Player1.checkerImage || board[checker.Position.X - 1, checker.Position.Y - 1].Image == Player1.kingCheckerImage)
                                return true;
                        }
                    }
                    else if (checker.Position.Y > 5 && checker.Position.X > 1 && checker.Position.X < 6)
                    {
                        if (board[checker.Position.X + 2, checker.Position.Y - 2].Image == null)
                        {
                            if (board[checker.Position.X + 1, checker.Position.Y - 1].Image == Player1.checkerImage || board[checker.Position.X + 1, checker.Position.Y - 1].Image == Player1.kingCheckerImage)
                                return true;
                        }
                        if (board[checker.Position.X - 2, checker.Position.Y - 2].Image == null)
                        {
                            if (board[checker.Position.X - 1, checker.Position.Y - 1].Image == Player1.checkerImage || board[checker.Position.X - 1, checker.Position.Y - 1].Image == Player1.kingCheckerImage)
                                return true;
                        }
                    }
                    else if (checker.Position.Y <= 5 && checker.Position.Y >= 2 && checker.Position.X <= 1)
                    {
                        if (board[checker.Position.X + 2, checker.Position.Y - 2].Image == null)
                        {
                            if (board[checker.Position.X + 1, checker.Position.Y - 1].Image == Player1.checkerImage || board[checker.Position.X + 1, checker.Position.Y - 1].Image == Player1.kingCheckerImage)
                                return true;
                        }
                        if (board[checker.Position.X + 2, checker.Position.Y + 2].Image == null)
                        {
                            if (board[checker.Position.X + 1, checker.Position.Y + 1].Image == Player1.checkerImage || board[checker.Position.X + 1, checker.Position.Y + 1].Image == Player1.kingCheckerImage)
                                return true;
                        }
                    }
                    else if (checker.Position.Y <= 5 && checker.Position.Y >= 2 && checker.Position.X >= 6)
                    {
                        if (board[checker.Position.X - 2, checker.Position.Y + 2].Image == null)
                        {
                            if (board[checker.Position.X - 1, checker.Position.Y + 1].Image == Player1.checkerImage || board[checker.Position.X - 1, checker.Position.Y + 1].Image == Player1.kingCheckerImage)
                                return true;
                        }
                        if (board[checker.Position.X - 2, checker.Position.Y - 2].Image == null)
                        {
                            if (board[checker.Position.X - 1, checker.Position.Y - 1].Image == Player1.checkerImage || board[checker.Position.X - 1, checker.Position.Y - 1].Image == Player1.kingCheckerImage)
                                return true;
                        }
                    }
                    else if (checker.Position.Y <= 5 && checker.Position.Y >= 2 && checker.Position.X > 1 && checker.Position.X < 6)
                    {
                        if (board[checker.Position.X + 2, checker.Position.Y - 2].Image == null)
                        {
                            if (board[checker.Position.X + 1, checker.Position.Y - 1].Image == Player1.checkerImage || board[checker.Position.X + 1, checker.Position.Y - 1].Image == Player1.kingCheckerImage)
                                return true;
                        }
                        if (board[checker.Position.X + 2, checker.Position.Y + 2].Image == null)
                        {
                            if (board[checker.Position.X + 1, checker.Position.Y + 1].Image == Player1.checkerImage || board[checker.Position.X + 1, checker.Position.Y + 1].Image == Player1.kingCheckerImage)
                                return true;
                        }
                        if (board[checker.Position.X - 2, checker.Position.Y + 2].Image == null)
                        {
                            if (board[checker.Position.X - 1, checker.Position.Y + 1].Image == Player1.checkerImage || board[checker.Position.X - 1, checker.Position.Y + 1].Image == Player1.kingCheckerImage)
                                return true;
                        }
                        if (board[checker.Position.X - 2, checker.Position.Y - 2].Image == null)
                        {
                            if (board[checker.Position.X - 1, checker.Position.Y - 1].Image == Player1.checkerImage || board[checker.Position.X - 1, checker.Position.Y - 1].Image == Player1.kingCheckerImage)
                                return true;
                        }
                    }
                }
            }
            return false;
        }

        internal List<Point> GetFreeCellsForMoves(Checker checker, PictureBox[,] newBoard)
        {
            List<Point> freeCells = new List<Point>();
            if (!checker.IsKing)
            {
                if (checker.Position.X == 0)
                {
                    if (newBoard[checker.Position.X + 1, checker.Position.Y - 1].Image == null)
                        freeCells.Add(new Point(checker.Position.X + 1, checker.Position.Y - 1));
                }
                else if (checker.Position.X == 7)
                {
                    if (newBoard[checker.Position.X - 1, checker.Position.Y - 1].Image == null)
                        freeCells.Add(new Point(checker.Position.X - 1, checker.Position.Y - 1));
                }
                else
                {
                    if (newBoard[checker.Position.X - 1, checker.Position.Y - 1].Image == null)
                        freeCells.Add(new Point(checker.Position.X - 1, checker.Position.Y - 1));
                    if (newBoard[checker.Position.X + 1, checker.Position.Y - 1].Image == null)
                        freeCells.Add(new Point(checker.Position.X + 1, checker.Position.Y - 1));
                }
            }
            else
            {
                if (checker.Position.Y == 0 && checker.Position.X == 0)
                {
                    if (newBoard[checker.Position.X + 1, checker.Position.Y + 1].Image == null)
                        freeCells.Add(new Point(checker.Position.X + 1, checker.Position.Y + 1));
                }
                else if (checker.Position.Y == 0 && checker.Position.X == 7)
                {
                    if (newBoard[checker.Position.X - 1, checker.Position.Y + 1].Image == null)
                        freeCells.Add(new Point(checker.Position.X - 1, checker.Position.Y + 1));
                }
                else if (checker.Position.Y == 0 && checker.Position.X > 0 && checker.Position.X < 7)
                {
                    if (newBoard[checker.Position.X - 1, checker.Position.Y + 1].Image == null)
                        freeCells.Add(new Point(checker.Position.X - 1, checker.Position.Y + 1));
                    if (newBoard[checker.Position.X + 1, checker.Position.Y + 1].Image == null)
                        freeCells.Add(new Point(checker.Position.X + 1, checker.Position.Y + 1));
                }
                else if (checker.Position.Y == 7 && checker.Position.X == 1)
                {
                    if (newBoard[checker.Position.X + 1, checker.Position.Y - 1].Image == null)
                        freeCells.Add(new Point(checker.Position.X + 1, checker.Position.Y - 1));
                }
                else if (checker.Position.Y == 7 && checker.Position.X == 7)
                {
                    if (newBoard[checker.Position.X - 1, checker.Position.Y - 1].Image == null)
                        freeCells.Add(new Point(checker.Position.X - 1, checker.Position.Y - 1));
                }
                else if (checker.Position.Y == 7 && checker.Position.X > 0 && checker.Position.X < 7)
                {
                    if (newBoard[checker.Position.X + 1, checker.Position.Y - 1].Image == null)
                        freeCells.Add(new Point(checker.Position.X + 1, checker.Position.Y - 1));
                    if (newBoard[checker.Position.X - 1, checker.Position.Y - 1].Image == null)
                        freeCells.Add(new Point(checker.Position.X - 1, checker.Position.Y - 1));
                }
                else if (checker.Position.Y < 7 && checker.Position.Y > 0 && checker.Position.X == 0)
                {
                    if (newBoard[checker.Position.X + 1, checker.Position.Y - 1].Image == null)
                        freeCells.Add(new Point(checker.Position.X + 1, checker.Position.Y - 1));
                    if (newBoard[checker.Position.X + 1, checker.Position.Y + 1].Image == null)
                        freeCells.Add(new Point(checker.Position.X + 1, checker.Position.Y + 1));

                }
                else if (checker.Position.Y < 7 && checker.Position.Y > 0 && checker.Position.X == 7)
                {
                    if (newBoard[checker.Position.X - 1, checker.Position.Y + 1].Image == null)
                        freeCells.Add(new Point(checker.Position.X - 1, checker.Position.Y + 1));

                    if (newBoard[checker.Position.X - 1, checker.Position.Y - 1].Image == null)
                        freeCells.Add(new Point(checker.Position.X - 1, checker.Position.Y - 1));
                }
                else if (checker.Position.Y < 7 && checker.Position.Y > 0 && checker.Position.X > 0 && checker.Position.X < 7)
                {
                    if (newBoard[checker.Position.X + 1, checker.Position.Y - 1].Image == null)
                        freeCells.Add(new Point(checker.Position.X + 1, checker.Position.Y - 1));
                    if (newBoard[checker.Position.X + 1, checker.Position.Y + 1].Image == null)
                        freeCells.Add(new Point(checker.Position.X + 1, checker.Position.Y + 1));
                    if (newBoard[checker.Position.X - 1, checker.Position.Y + 1].Image == null)
                        freeCells.Add(new Point(checker.Position.X - 1, checker.Position.Y + 1));
                    if (newBoard[checker.Position.X - 1, checker.Position.Y - 1].Image == null)
                        freeCells.Add(new Point(checker.Position.X - 1, checker.Position.Y - 1));
                }
            }
            return freeCells;
        }

        internal bool HasMoves(PictureBox[,] newBoard)
        {
            foreach (Checker checker in PlayerCheckers)
            {
                if (GetFreeCellsForMoves(checker, newBoard).Count != 0)
                    return true;
            }
            return false;
        }

        public Checker GetChecker(Point clickedPosition)
        {
            foreach (Checker checker in playerCheckers)
            {
                if (checker.Position == clickedPosition)
                    return checker;
            }
            return null;
        }

        internal bool IsValidMove(Checker selectedChecker, Point clickedLocation)
        {
            if (!selectedChecker.IsKing)
            {
                if (clickedLocation.Y - selectedChecker.Position.Y == -1 && Math.Abs(clickedLocation.X - selectedChecker.Position.X) == 1)
                    return true;
            }
            else
            {
                if (Math.Abs(clickedLocation.Y - selectedChecker.Position.Y) == 1 && Math.Abs(clickedLocation.X - selectedChecker.Position.X) == 1)
                    return true;
            }
            return false;
        }

        internal bool IsValidJump(Checker selectedChecker, Point clickedLocation, PictureBox[,] newBoard)
        {
            if (!selectedChecker.IsKing)
            {
                if (clickedLocation.Y - selectedChecker.Position.Y == -2)
                {
                    if (clickedLocation.X - selectedChecker.Position.X == 2)
                    {
                        if (newBoard[clickedLocation.X - 1, clickedLocation.Y + 1].Image == Player1.checkerImage || newBoard[clickedLocation.X - 1, clickedLocation.Y + 1].Image == Player1.kingCheckerImage)
                            return true;
                    }
                    else if (clickedLocation.X - selectedChecker.Position.X == -2)
                    {
                        if (newBoard[clickedLocation.X + 1, clickedLocation.Y + 1].Image == Player1.checkerImage || newBoard[clickedLocation.X + 1, clickedLocation.Y + 1].Image == Player1.kingCheckerImage)
                            return true;
                    }
                }
            }
            else
            {
                if (clickedLocation.Y - selectedChecker.Position.Y == 2 && clickedLocation.X - selectedChecker.Position.X == 2)
                {
                    if (newBoard[clickedLocation.X - 1, clickedLocation.Y - 1].Image == Player1.checkerImage || newBoard[clickedLocation.X - 1, clickedLocation.Y - 1].Image == Player1.kingCheckerImage)
                        return true;
                }
                else if (clickedLocation.Y - selectedChecker.Position.Y == 2 && clickedLocation.X - selectedChecker.Position.X == -2)
                {
                    if (newBoard[clickedLocation.X + 1, clickedLocation.Y - 1].Image == Player1.checkerImage || newBoard[clickedLocation.X + 1, clickedLocation.Y - 1].Image == Player1.kingCheckerImage)
                        return true;
                }
                else if (clickedLocation.Y - selectedChecker.Position.Y == -2 && clickedLocation.X - selectedChecker.Position.X == 2)
                {
                    if (newBoard[clickedLocation.X - 1, clickedLocation.Y + 1].Image == Player1.checkerImage || newBoard[clickedLocation.X - 1, clickedLocation.Y + 1].Image == Player1.kingCheckerImage)
                        return true;
                }
                else if (clickedLocation.Y - selectedChecker.Position.Y == -2 && clickedLocation.X - selectedChecker.Position.X == -2)
                {
                    if (newBoard[clickedLocation.X + 1, clickedLocation.Y + 1].Image == Player1.checkerImage || newBoard[clickedLocation.X + 1, clickedLocation.Y + 1].Image == Player1.kingCheckerImage)
                        return true;
                }
            }
            return false;
        }

        internal void ExecuteMove(Checker selectedChecker, Point clickedLocation, PictureBox[,] newBoard)
        {
            newBoard[selectedChecker.Position.X, selectedChecker.Position.Y].Image = null;
            selectedChecker.Position = clickedLocation;
            newBoard[clickedLocation.X, clickedLocation.Y].Image = selectedChecker.CurrentImage;
        }

        internal void ExecuteJump(Checker selectedChecker, Point clickedLocation, PictureBox[,] newBoard, Player1 player1)
        {
            newBoard[selectedChecker.Position.X, selectedChecker.Position.Y].Image = null;
            if (clickedLocation.X - selectedChecker.Position.X == 2 && clickedLocation.Y - selectedChecker.Position.Y == 2)
            {
                player1.RemoveCheckerFromList(new Point(clickedLocation.X - 1, clickedLocation.Y - 1));
                newBoard[clickedLocation.X - 1, clickedLocation.Y - 1].Image = null;
            }
            else if (clickedLocation.X - selectedChecker.Position.X == -2 && clickedLocation.Y - selectedChecker.Position.Y == 2)
            {
                player1.RemoveCheckerFromList(new Point(clickedLocation.X + 1, clickedLocation.Y - 1));
                newBoard[clickedLocation.X + 1, clickedLocation.Y - 1].Image = null;
            }
            else if (clickedLocation.X - selectedChecker.Position.X == -2 && clickedLocation.Y - selectedChecker.Position.Y == -2)
            {
                player1.RemoveCheckerFromList(new Point(clickedLocation.X + 1, clickedLocation.Y + 1));
                newBoard[clickedLocation.X + 1, clickedLocation.Y + 1].Image = null;
            }
            else if (clickedLocation.X - selectedChecker.Position.X == 2 && clickedLocation.Y - selectedChecker.Position.Y == -2)
            {
                player1.RemoveCheckerFromList(new Point(clickedLocation.X - 1, clickedLocation.Y + 1));
                newBoard[clickedLocation.X - 1, clickedLocation.Y + 1].Image = null;
            }
            selectedChecker.Position = clickedLocation;
            newBoard[clickedLocation.X, clickedLocation.Y].Image = selectedChecker.CurrentImage;
        }

        public void RemoveCheckerFromList(Point position)
        {
            foreach (Checker checker in playerCheckers)
            {
                if (checker.Position == position)
                {
                    playerCheckers.Remove(checker);
                    break;
                }
            }
        }

        internal bool CheckIfShouldBeKing(Checker selectedChecker)
        {
            if (selectedChecker.Position.Y == 0)
                return true;
            return false;
        }
    }
}
