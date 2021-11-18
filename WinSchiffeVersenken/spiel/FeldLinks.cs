using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace WinSchiffeVersenken.spiel
{
    class FeldLinks : PictureBox
    {
        private int x, y;

        public FeldLinks(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int getX()
        {
            return this.x;
        }

        public int getY()
        {
            return this.y;
        }

        public void setX(int x)
        {
            this.x = x;
        }

        public void setY(int y)
        {
            this.y = y;
        }
    }
}
