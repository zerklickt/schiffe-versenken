using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinSchiffeVersenken
{
    public partial class Form1 : Form
    {
        public int x = 0, y = 0;
        private Spiel sp;
        private User me;

        public Form1()
        {

            /*
             * 
             * ==============================================================================================================
             * WENN PROGRAMM NICHT ORDNUNGSGEMÄSS STARTET (BZW. AUSSIEHT), FOLGENDES TUN:
             * 
             *                                                                      / /
             *      //InitializeComponent()                                    _   / /
             *      privateInit()                                             | | / /
             *                                                                | |__/__
             *                                                                |_______|
             * ==============================================================================================================
             * #niceASCIIart ich weiss danke
             */

            //InitializeComponent();
            privateInit();

            /*
             * ==============================================================================================================
             */
            me = new User("testuser", "password");
            sp = new Spiel(me, new User("testuser2", "passwort2"));
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                x = Convert.ToInt32(textBox9.Text);
                y = Convert.ToInt32(textBox10.Text);
            }
            catch { }
            Form1.pictureBoxes[x-1, y-1].BackColor = Color.Black;
            buttons[x - 1, y - 1].setShipID(sp);
        }

        private void btnClick(object sender, EventArgs e)
        {
            sp.GetSpielfeld().checkClick((Feld)sender);
            //reload();
        }

        private void pBoxClick(object sender, EventArgs e)
        {
            ((PictureBox)sender).BackColor = Color.Black;
            for(int x = 0; x < Settings.SIZE; x++)
            {
                for(int y = 0; y < Settings.SIZE; y++)
                {
                    if(Form1.pictureBoxes[x, y].Equals(((PictureBox)sender)))
                    {
                        buttons[x, y].setShipID(sp);
                        return;
                    }
                }
            }
        }

        private void nextShip(object sender, EventArgs e)
        {
            sp.GetSpielfeld().Checkeinput();
        }

        private void reload()
        {
            foreach (Feld d in Form1.getButtons())
            {
                foreach(Schiffe s in sp.getMe().getShips())
                {
                    if(s.getid() == d.getShipID())
                    {
                        if (s.istversenkt())
                        {
                            d.setStatus(Status.SUNK);
                            d.BackColor = Color.Red;
                        } else {
                            d.setStatus(Status.HIT);
                            d.BackColor = Color.LightSalmon;
                        }
                    }
                }
            }
        }
    }
}
