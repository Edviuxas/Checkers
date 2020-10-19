using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Checkers_WinForms
{
    public partial class Form1 : Form
    {
        Board board;
        public Form1()
        {
            InitializeComponent();
            board = new Board(this, lblMessage, lblTurn);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            board.DrawBoard();
            lblTurn.Text = "Blue's turn";
        }
    }
}
