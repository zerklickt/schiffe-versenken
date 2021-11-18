using System;
using System.Drawing;

namespace WinSchiffeVersenken
{
    class Spielfeld
    {
        Spiel sp;
        private int size;
        private Feld[,] buttons = Form1.getButtons();

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

        public bool alreadyoccup(int x, int y)
        {
            if (buttons[x, y].getShipID() != -1)
            {
                return false;
            }
            return true;
        }

        public bool Checkeinput()
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
                                Console.WriteLine("fehler");
                                return false;
                                break;
                            case 1:
                                for (int k = i + 1; k < size; k++)
                                {
                                    for (int l = 0; l < size; l++)
                                    {
                                        if (buttons[k, l].getShipID() == id)
                                        {
                                            Console.WriteLine("fehler");
                                            return false;
                                        }
                                    }
                                }
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
                                                Console.WriteLine("fehler");
                                                return false;
                                            }
                                        }
                                    }
                                }
                                break;

                            default:
                                break;
                        }
                    }
                }
            }
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
            return true;
        }
        private int Adjacent(int reihe, int höhe)
        {
            int id = this.sp.getcurrUser().getamountships();
            int check = 0;
            for (int i = höhe + 1; i < size; i++)
            {
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
                if (buttons[i, höhe].getShipID() == id)
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
    }
}
