using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Checkers_WinForms
{
    public class Board
    {
        Label lblMessage, lblTurn;
        PictureBox[,] newBoard = new PictureBox[8, 8];
        Cell[,] board = new Cell[8,8];
        Form mainForm;
        int playerTurn = 1;
        Player1 player1 = new Player1();
        Player2 player2 = new Player2();

        List<Cell> allCells = new List<Cell>();
        Checker selectedChecker = null;
        public Board(Form mainForm, Label lblMessage, Label lblTurn)
        {
            this.lblTurn = lblTurn;
            this.lblMessage = lblMessage;
            this.mainForm = mainForm;
        }

        public void DrawBoard()
        {
            int xLocation = 0;
            int yLocation = 40;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Cell cell = new Cell();
                    cell.Position = new Point(j,i);
                    //cell.X = j;
                    //cell.Y = i;
                    PictureBox pb = new PictureBox();
                    cell.PictureBox = pb;
                    pb.Click += Pb_Click;
                    pb.SizeMode = PictureBoxSizeMode.StretchImage;
                    pb.Location = new Point(xLocation, yLocation);
                    pb.Size = new Size(60, 60);
                    pb.Image = null;

                    if (i < 3)
                    {
                        if (i % 2 == 0)
                        {
                            if (j % 2 == 0)
                                pb.BackColor = Color.White;
                            else
                            {
                                pb.BackColor = Color.Black;
                                pb.Image = Player1.checkerImage;
                                Checker checker = new Checker();
                                checker.CurrentImage = Player1.checkerImage;
                                checker.Color = Color.Blue;
                                checker.BelongsToPlayer = 1;
                                checker.CorrespondingCell = cell;
                                checker.Position = new Point(j, i);
                                player1.PlayerCheckers.Add(checker);
                                cell.Content = checker;
                            }
                        }
                        else
                        {
                            if (j % 2 == 1)
                                pb.BackColor = Color.White;
                            else
                            {
                                pb.BackColor = Color.Black;
                                pb.Image = Player1.checkerImage;
                                Checker checker = new Checker();
                                checker.CurrentImage = Player1.checkerImage;
                                checker.Color = Color.Blue;
                                checker.BelongsToPlayer = 1;
                                checker.CorrespondingCell = cell;
                                checker.Position = new Point(j, i);
                                player1.PlayerCheckers.Add(checker);
                                cell.Content = checker;
                            }
                        }
                    }
                    else if (i > 2 && i < 5)
                    {
                        if (i % 2 == 0)
                        {
                            if (j % 2 == 0)
                                pb.BackColor = Color.White;
                            else
                                pb.BackColor = Color.Black;
                        }
                        else
                        {
                            if (j % 2 == 1)
                                pb.BackColor = Color.White;
                            else
                                pb.BackColor = Color.Black;
                        }
                    }
                    else
                    {
                        if (i % 2 == 0)
                        {
                            if (j % 2 == 0)
                                pb.BackColor = Color.White;
                            else
                            {
                                pb.BackColor = Color.Black;
                                pb.Image = Player2.checkerImage;
                                Checker checker = new Checker();
                                checker.CurrentImage = Player2.checkerImage;
                                checker.Color = Color.Red;
                                checker.BelongsToPlayer = 2;
                                checker.CorrespondingCell = cell;
                                checker.Position = new Point(j, i);
                                player2.PlayerCheckers.Add(checker);
                                cell.Content = checker;
                            }
                        }
                        else
                        {
                            if (j % 2 == 1)
                                pb.BackColor = Color.White;
                            else
                            {
                                pb.BackColor = Color.Black;
                                pb.Image = Player2.checkerImage;
                                Checker checker = new Checker();
                                checker.CurrentImage = Player2.checkerImage;
                                checker.Color = Color.Red;
                                checker.BelongsToPlayer = 2;
                                checker.CorrespondingCell = cell;
                                checker.Position = new Point(j, i);
                                player2.PlayerCheckers.Add(checker);
                                cell.Content = checker;
                            }
                        }
                    }
                    allCells.Add(cell);
                    mainForm.Controls.Add(pb);
                    xLocation += 60;
                    newBoard[j, i] = pb;
                    board[i,j] = cell;
                }
                yLocation += 60;
                xLocation = 0;
            }
        }

        private void Pb_Click(object sender, EventArgs e)
        {
            PictureBox clickedBox = (PictureBox)sender;
            if (clickedBox.BackColor != Color.White)
            {
                if (selectedChecker == null)
                {
                    if (clickedBox.Image != null)
                    {
                        if (playerTurn == 1)
                        {
                            if (clickedBox.Image != Player2.checkerImage)
                                selectedChecker = player1.getChecker(new Point(clickedBox.Location.X / 60, clickedBox.Location.Y / 60));
                        }
                        else
                        {
                            if (clickedBox.Image != Player1.checkerImage)
                                selectedChecker = player2.GetChecker(new Point(clickedBox.Location.X / 60, clickedBox.Location.Y / 60));
                        }
                    }
                }
                else
                {
                    if (clickedBox.Image == null)
                    {
                        if (playerTurn == 1)
                        {
                            if (!player1.HasToJump(newBoard))
                            {
                                if (player1.IsValidMove(selectedChecker, new Point(clickedBox.Location.X / 60, clickedBox.Location.Y / 60)))
                                {
                                    lblMessage.Text = "";
                                    player1.ExecuteMove(selectedChecker, new Point(clickedBox.Location.X / 60, clickedBox.Location.Y / 60), newBoard);
                                    playerTurn = 2;
                                    lblTurn.Text = "Red's turn";
                                    lblTurn.ForeColor = Color.Red;
                                    if (!player2.HasMoves(newBoard))
                                    {
                                        lblTurn.Text = "BLUE PLAYER WON";
                                        lblTurn.ForeColor = Color.DeepSkyBlue;
                                        lblMessage.Text = "RED HAS NO MOVES";
                                        EndGame();
                                    }
                                    if (player1.CheckIfShouldBeKing(selectedChecker))
                                    {
                                        selectedChecker.IsKing = true;
                                        selectedChecker.CurrentImage = Player1.kingCheckerImage;
                                        clickedBox.Image = Player1.kingCheckerImage;
                                    }
                                    selectedChecker = null;
                                }
                                else
                                    lblMessage.Text = "Invalid move";
                            }
                            else
                            {
                                if (player1.IsValidJump(selectedChecker, new Point(clickedBox.Location.X / 60, clickedBox.Location.Y / 60), newBoard))
                                {
                                    lblMessage.Text = "";
                                    player1.ExecuteJump(selectedChecker, new Point(clickedBox.Location.X / 60, clickedBox.Location.Y / 60), newBoard, player2);
                                    if (!player1.HasToJump(newBoard))
                                    {
                                        playerTurn = 2;
                                        lblTurn.Text = "Red's turn";
                                        lblTurn.ForeColor = Color.Red;
                                        if (player2.PlayerCheckers.Count == 0)
                                        {
                                            lblTurn.Text = "BLUE PLAYER HAS WON THE GAME";
                                            lblTurn.ForeColor = Color.DeepSkyBlue;
                                            EndGame();
                                        }
                                        else if (!player2.HasMoves(newBoard))
                                        {
                                            lblTurn.Text = "BLUE PLAYER WON";
                                            lblTurn.ForeColor = Color.DeepSkyBlue;
                                            lblMessage.Text = "RED HAS NO MOVES";
                                            EndGame();
                                        }
                                        if (player1.CheckIfShouldBeKing(selectedChecker))
                                        {
                                            selectedChecker.IsKing = true;
                                            selectedChecker.CurrentImage = Player1.kingCheckerImage;
                                            clickedBox.Image = Player1.kingCheckerImage;
                                        }
                                        selectedChecker = null;
                                    }
                                }
                                else
                                    lblMessage.Text = "Player has to make a jump";
                            }
                        }
                        else
                        {
                            if (!player2.HasToJump(newBoard))
                            {
                                if (player2.IsValidMove(selectedChecker, new Point(clickedBox.Location.X / 60, clickedBox.Location.Y / 60)))
                                {
                                    lblMessage.Text = "";
                                    player2.ExecuteMove(selectedChecker, new Point(clickedBox.Location.X / 60, clickedBox.Location.Y / 60), newBoard);
                                    playerTurn = 1;
                                    lblTurn.Text = "Blue's turn";
                                    lblTurn.ForeColor = Color.DeepSkyBlue;
                                    if (!player1.HasMoves(newBoard))
                                    {
                                        lblTurn.Text = "RED PLAYER WON";
                                        lblTurn.ForeColor = Color.Red;
                                        lblMessage.Text = "BLUE HAS NO MOVES";
                                        EndGame();
                                    }
                                    if (player2.CheckIfShouldBeKing(selectedChecker))
                                    {
                                        selectedChecker.IsKing = true;
                                        selectedChecker.CurrentImage = Player2.kingCheckerImage;
                                        clickedBox.Image = Player2.kingCheckerImage;
                                    }
                                    selectedChecker = null;
                                }
                                else
                                    lblMessage.Text = "Invalid move";
                            }
                            else
                            {
                                if (player2.IsValidJump(selectedChecker, new Point(clickedBox.Location.X / 60, clickedBox.Location.Y / 60), newBoard))
                                {
                                    lblMessage.Text = "";
                                    player2.ExecuteJump(selectedChecker, new Point(clickedBox.Location.X / 60, clickedBox.Location.Y / 60), newBoard, player1);
                                    if (!player2.HasToJump(newBoard))
                                    {
                                        playerTurn = 1;
                                        lblTurn.Text = "Blue's turn";
                                        lblTurn.ForeColor = Color.DeepSkyBlue;
                                        if (player1.PlayerCheckers.Count == 0)
                                        {
                                            lblTurn.Text = "RED PLAYER WON THE GAME";
                                            lblTurn.ForeColor = Color.Red;
                                            EndGame();
                                        }
                                        else if (!player1.HasMoves(newBoard))
                                        {
                                            lblTurn.Text = "RED PLAYER WON";
                                            lblTurn.ForeColor = Color.Red;
                                            lblMessage.Text = "BLUE HAS NO MOVES";
                                            EndGame();
                                        }

                                        if (player2.CheckIfShouldBeKing(selectedChecker))
                                        {
                                            selectedChecker.IsKing = true;
                                            selectedChecker.CurrentImage = Player2.kingCheckerImage;
                                            clickedBox.Image = Player2.kingCheckerImage;
                                        }
                                        selectedChecker = null;
                                    }
                                }
                                else
                                    lblMessage.Text = "Player has to make a jump";
                            }
                        }
                    }
                    else
                    {
                        if (playerTurn == 1 && (clickedBox.Image == Player1.checkerImage || clickedBox.Image == Player1.kingCheckerImage))
                            selectedChecker = player1.getChecker(new Point(clickedBox.Location.X / 60, clickedBox.Location.Y / 60));
                        else if (playerTurn == 2 && (clickedBox.Image == Player2.checkerImage || clickedBox.Image == Player2.kingCheckerImage))
                            selectedChecker = player2.GetChecker(new Point(clickedBox.Location.X / 60, clickedBox.Location.Y / 60));
                    }
                }
            }
            else
                lblMessage.Text = "Invalid move";
            }

        private void EndGame()
        {
            foreach (var control in mainForm.Controls)
            {
                if (control is PictureBox)
                {
                    PictureBox pb = (PictureBox)control;
                    pb.Enabled = false;
                }
            }
        }

        private void ExecuteMove(Checker selectedChecker, Cell clickedCell, Cell currentCell)
        {
            selectedChecker.CorrespondingCell = clickedCell;
            clickedCell.Content = selectedChecker;
            clickedCell.PictureBox.Image = currentCell.PictureBox.Image;
            currentCell.PictureBox.Image = null;
            currentCell.Content = null;
            if (playerTurn == 1)
                playerTurn = 2;
            else
                playerTurn = 1;
        }
    }
}
