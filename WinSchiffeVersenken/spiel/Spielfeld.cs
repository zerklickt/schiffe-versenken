using System.Drawing;

namespace WinSchiffeVersenken
{
    class Spielfeld
    {
        Spiel sp;
        private int size;
        private Feld[,] buttons;

        public Spielfeld(Spiel sp)
        {
            this.sp = sp;
        }

        public Feld[,] getButtons()
        {
            return buttons;
        }

        public bool fire(int x, int y)
        {
            
            return false;
        }

        public void checkClick(Feld feld)
        {
            if (feld.getShipID() != -1)
            {
                Schiffe s = sp.getMe().getShips()[feld.getShipID()];
                s.getroffen();
                s.istversenktfunct();
                if (s.istversenkt())
                {
                    feld.setStatus(Status.SUNK);
                    feld.BackColor = Color.Red;
                }
                else
                {
                    feld.setStatus(Status.HIT);
                    feld.BackColor = Color.LightSalmon;
                }
            }
            else
            {
                feld.setStatus(Status.MISS);
                feld.BackColor = Color.Blue;
            }
            feld.Enabled = false;
        }
    }
}
