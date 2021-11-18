using System;
using System.Drawing;

namespace WinSchiffeVersenken
{
    class Spielfeld
    {
        Spiel sp;
        private int size;
        private Feld[,] buttons = Form1.getButtonsRight();

        public Spielfeld(Spiel sp)
        {
            this.size = Settings.SIZE;
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
                Schiffe s = sp.getcurrUser().getShips()[feld.getShipID()];
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

        public bool alreadyoccup(int x, int y)
        {
            if (buttons[x, y].getShipID() != -1)
            {
                return false;
            }
            return true;
        }

        public void Checkeinput()
        {
            int id = this.sp.getcurrUser().getamountships();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (id == buttons[i, j].getShipID())
                    {
                        switch (Adjacent(i, j))
                        {
                            case 0:
                                Form1.getLabelOut().Text = "Kein angrenzes Feld gefunden";
                                clearUnused();
                                return;
                                break;
                            case 1:
                                for (int k = i + 1; k < size; k++)
                                {
                                    for (int l = 0; l < size; l++)
                                    {
                                        if (buttons[k, l].getShipID() == id)
                                        {
                                            Form1.getLabelOut().Text = "Das Schiff ist nicht zusammenhängend";
                                            clearUnused();
                                            return;
                                        }
                                    }
                                }
                                goto br;
                                break;
                            case 2:
                                for (int k = i; k < size; k++)
                                {
                                    for (int l = 0; l < size; l++)
                                    {
                                        if (l != j)
                                        {
                                            if (buttons[k, l].getShipID() == id)
                                            {

                                                Form1.getLabelOut().Text = "Das Schiff ist nicht zusammenhängend";
                                                clearUnused();
                                                return;
                                            }
                                        }
                                    }
                                }
                                goto br;
                                break;

                            default:
                                break;
                        }
                    }
                }
            }
            br:
            int count = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (id == buttons[i, j].getShipID())
                    {
                        count++;
                    }
                }
            }
            sp.getcurrUser().addShip(count);
            return;
        }
        private int Adjacent(int reihe, int hoehe)
        {
            int id = this.sp.getcurrUser().getamountships();
            int check = 0;
            int db = -5;
            for (int i = hoehe + 1; i < size; i++)
            {
                db = buttons[reihe, i].getShipID();
                if (buttons[reihe, i].getShipID() == id)
                {
                    check = 1;
                }
            }
            if (check == 1)
            {
                return check;
            }
            check = 0;
            for (int i = reihe + 1; i < size; i++)
            {
                if (buttons[i, hoehe].getShipID() == id)
                {
                    check = 2;
                }
            }
            if (check == 2)
            {
                return check;
            }
            return 0;
        }

        private void clearUnused()
        {
            for(int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if(buttons[i,j].getShipID() == sp.getcurrUser().getamountships())
                    {
                        buttons[i, j].setShipID(-1);
                        Form1.getPicBoxes()[i, j].BackColor = System.Drawing.SystemColors.ButtonHighlight;
                    }
                }
            }
        }
    }
}
