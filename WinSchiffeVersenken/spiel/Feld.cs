using System.Windows.Forms;

namespace WinSchiffeVersenken
{
    class Feld : Button
    {

        private int x, y, shipID;
        private Status status;

        public Feld(int x, int y, Status status = Status.DEFAULT, int shipID = -1)
        {
            this.x = x;
            this.y = y;
            this.status = status;
            this.shipID = shipID;
        }

        public int getStatusInt()
        {
            return (int) this.status;
        }

        public Status getStatus()
        {
            return this.status;
        }

        public void setStatus(int status)
        {
            switch (status)
            {
                case 1:
                    this.status = Status.MISS;
                    break;
                case 2:
                    this.status = Status.HIT;
                    break;
                case 3:
                    this.status = Status.SUNK;
                    break;
                default:
                    this.status = Status.DEFAULT;
                    break;
            }
        }

        public void setStatus(Status status)
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

        public void setShipID(Spiel sp)
        {
            int cache = sp.getcurrUser().getamountships();
            this.shipID = cache;
        }

        public void setShipID(int v)
        {
            this.shipID = v;
        }
    }
}
