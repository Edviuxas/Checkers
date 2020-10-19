using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers_WinForms
{
    class Checker
    {
        private Bitmap currentImage;
        private Point position;
        private Color color;
        private int belongsToPlayer;
        private bool isKing;
        private Cell correspondingCell;
        public Checker()
        {

        }

        public Color Color { get => color; set => color = value; }
        public int BelongsToPlayer { get => belongsToPlayer; set => belongsToPlayer = value; }
        public bool IsKing { get => isKing; set => isKing = value; }
        internal Cell CorrespondingCell { get => correspondingCell; set => correspondingCell = value; }
        public Point Position { get => position; set => position = value; }
        public Bitmap CurrentImage { get => currentImage; set => currentImage = value; }

        internal bool IsValidMove(Point clickedCellPoint)
        {
            if (!IsKing)
            {
                if (belongsToPlayer == 1)
                {
                    if (correspondingCell.Position.Y + 1 == clickedCellPoint.Y && (correspondingCell.Position.X + 1 == clickedCellPoint.X || correspondingCell.Position.X - 1 == clickedCellPoint.X))
                        return true;
                    else
                        return false;
                }
                else
                {
                    if (correspondingCell.Position.Y - 1 == clickedCellPoint.Y && (correspondingCell.Position.X + 1 == clickedCellPoint.X || correspondingCell.Position.X - 1 == clickedCellPoint.X))
                        return true;
                    else
                        return false;
                }
            }
            else
            {
                if (Math.Abs(clickedCellPoint.Y - correspondingCell.Position.Y) == 1 && Math.Abs(clickedCellPoint.X - correspondingCell.Position.X) == 1)
                    return true;
                else
                    return false;
            }
        }

        internal bool IsValidJump(Point clickedPosition, Cell[,] board)
        {
            //PRIDETI DAMKES PATIKRINIMA
            if (belongsToPlayer == 1)
            {
                if (clickedPosition.X - correspondingCell.Position.X == -2)
                {
                    if (board[clickedPosition.Y - 1, clickedPosition.X + 1].Content != null && board[clickedPosition.Y - 1, clickedPosition.X + 1].Content.BelongsToPlayer == 2)
                        return true;
                    else
                        return false;
                }
                else if (clickedPosition.X - correspondingCell.Position.X == 2)
                {
                    if (board[clickedPosition.Y - 1, clickedPosition.X - 1].Content != null && board[clickedPosition.Y - 1, clickedPosition.X - 1].Content.BelongsToPlayer == 2)
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
            else
            {
                if (clickedPosition.X - correspondingCell.Position.X == -2)
                {
                    if (board[clickedPosition.Y + 1, clickedPosition.X + 1].Content != null && board[clickedPosition.Y + 1, clickedPosition.X + 1].Content.BelongsToPlayer == 1)
                        return true;
                    else
                        return false;
                }
                else if (clickedPosition.X - correspondingCell.Position.X == 2)
                {
                    if (board[clickedPosition.Y + 1, clickedPosition.X - 1].Content != null && board[clickedPosition.Y + 1, clickedPosition.X - 1].Content.BelongsToPlayer == 1)
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
        }
    }
}
