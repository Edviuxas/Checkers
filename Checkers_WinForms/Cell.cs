using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Checkers_WinForms
{
    class Cell
    {
        private Checker content = null;
        private PictureBox pictureBox;
        private Point position;
        //int x;
        //int y;
        public Cell()
        {
            
        }

        public Cell(Point point)
        {
            this.position = point;
        }

        #region Getters and Setters
        public PictureBox PictureBox { get => pictureBox; set => pictureBox = value; }
        public Point Position { get => position; set => position = value; }
        internal Checker Content { get => content; set => content = value; }

        #endregion
    }
}
