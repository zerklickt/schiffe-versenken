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
    class Feld : Button
    {

        private int status, x, y, shipID;
        public Feld(int x, int y, int status = (int) Status.DEFAULT, int shipID = -1)
        {
            this.x = x;
            this.y = y;
            this.status = status;
            this.shipID = shipID;
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

        public int getShipID()
        {
            return shipID;
        }

        public void setShipID(int shipID)
        {
            this.shipID = shipID;
        }
    }
}
