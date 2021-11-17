using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinSchiffeVersenken
{
    class Feld
    {

        private int status, x, y;
        public Feld(int x, int y, int status = (int) Status.DEFAULT)
        {
            this.x = x;
            this.y = y;
            this.status = status;
        }

        public int getStatus()
        {
            
            return this.status;
        }

        public void setStatus(int status)
        {
            this.status = status;
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
