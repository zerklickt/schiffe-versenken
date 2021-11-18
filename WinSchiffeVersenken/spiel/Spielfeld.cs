using System;
using System.Drawing;

namespace WinSchiffeVersenken
{
    class Spielfeld
    {
        Spiel sp;
        private int size;
        private int amount4s = 0;
        private int amount3s = 0;
        private int amount2s = 0;
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

        public int getAmount4s()
        {
            return amount4s;
        }

        public int getAmount3s()
        {
            return amount3s;
        }

        public int getAmount2s()
        {
            return amount2s;
        }

        public void add4()
        {
            amount4s++;
        }

        public void add3()
        {
            amount3s++;
        }

        public void add2()
        {
            amount2s++;
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
                                            Form1.getLabelOut().Text = "ungültiges Schiffformat";
                                            clearUnused();
                                            return;
                                        }
                                    }
                                }
                                int count = counting(id);
                                int cachej = j + count;
                                if (cachej > size)
                                {
                                    Form1.getLabelOut().Text = "schwerwiegender Fehler";
                                    clearUnused();
                                    return;
                                }

                                for (int l = j; l < size; l++)
                                {
                                    if (l < cachej)
                                    {
                                        if (buttons[i, l].getShipID() != id)
                                        {
                                            Form1.getLabelOut().Text = "schwerwiegender Fehler1";
                                            clearUnused();
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        if (buttons[i, l].getShipID() == id)
                                        {
                                            Form1.getLabelOut().Text = "schwerwiegender Fehler2";
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

                                                Form1.getLabelOut().Text = "ungültiges Schiffformat";
                                                clearUnused();
                                                return;
                                            }
                                        }
                                    }
                                }
                                int count2 = counting(id);
                                int cachej2 = i + count2;
                                if (cachej2 > size)
                                {
                                    Form1.getLabelOut().Text = "schwerwiegender Fehler";
                                    clearUnused();
                                    return;
                                }

                                for (int l = i; l < size; l++)
                                {
                                    if (l < cachej2)
                                    {
                                        if (buttons[l, j].getShipID() != id)
                                        {
                                            Form1.getLabelOut().Text = "schwerwiegender Fehler1";
                                            clearUnused();
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        if (buttons[l, j].getShipID() == id)
                                        {
                                            Form1.getLabelOut().Text = "schwerwiegender Fehler2";
                                            clearUnused();
                                            return;
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

            switch (counting(id))
            {
                case 2:
                    if (amount2s < Settings.SHIPS_2)
                        amount2s++;
                    else
                    {
                        Form1.getLabelOut().Text = "Keine 2er-Schiffe mehr möglich!";
                        clearUnused();
                        return;
                    }
                    break;
                case 3:
                    if (amount3s < Settings.SHIPS_3)
                        amount3s++;
                    else
                    {
                        Form1.getLabelOut().Text = "Keine 3er-Schiffe mehr möglich!";

                        clearUnused();
                        return;
                    }
                    break;
                case 4:
                    if (amount4s < Settings.SHIPS_4)
                        amount4s++;
                    else
                    {
                        Form1.getLabelOut().Text = "Keine 4er-Schiffe mehr möglich!";

                        clearUnused();
                        return;
                    }
                    break;
                default:
                    Form1.getLabelOut().Text = "Keine gültige Schiffsgröße!";
                    clearUnused();
                    break;
            }
            sp.getcurrUser().addShip(counting(id));
            Form1.getLabelOut().Text = "Neues Schiff hinzugefügt";

            if(amount4s == Settings.SHIPS_4 && amount3s == Settings.SHIPS_3 && amount2s == Settings.SHIPS_2)
            {
                /*
                 * 
                 * Sende Nachricht an Server, dass CLient alle Schiffe gesetzt hat und bereit ist zu spielen.
                 * 
                 */
                sp.setLinksEingeloggt(true);
            }
            return;
        }

        private int counting(int id)
        {
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
            return count;
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
