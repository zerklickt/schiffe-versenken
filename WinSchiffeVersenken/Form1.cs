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
            me = new User("testuser");
            sp = new Spiel(me, new User("testuser2"));
            reload();
        }


        //Will be removed soon, since out of service
        private void textBox9_TextChanged(object sender, EventArgs e)
        {
        }

        //Will be removed soon, since out of service
        private void textBox10_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sp.setLinksEingeloggt(true);
            reload();
        }

        private void btnClick(object sender, EventArgs e)
        {
            sp.GetSpielfeld().checkClick((Feld)sender);
            reload();
        }

        private void pBoxClick(object sender, EventArgs e)
        {
            if (sp.istLinksEingeloggt())
            {
                Form1.getLabelOut().Text = "Keine Änderung mehr möglich";
                return;
            }
            int cache = buttons[((FeldLinks) sender).getX(),((FeldLinks) sender).getY()].getShipID();
            if (cache == -1)
            {
                ((PictureBox)sender).BackColor = Color.Black;
                buttons[((FeldLinks)sender).getX(), ((FeldLinks)sender).getY()].setShipID(sp);
            }
            else
            {
                Form1.getLabelOut().Text = "Feld ist schon belegt";
            }
        }

        private void nextShip(object sender, EventArgs e)
        {
            sp.GetSpielfeld().Checkeinput();
            reload();

        }

        public void reload()
        {
            bool t = sp.istLinksEingeloggt();
            foreach(FeldLinks f in Form1.getPicBoxes())
            {
                if (t)
                {
                    if(Form1.getButtonsRight()[f.getX(), f.getY()].getShipID() != -1)
                        f.BackColor = Color.DarkGray;
                    else
                        f.BackColor = Color.WhiteSmoke ;
                }
            }

            bool u = sp.istLinksEingeloggt();
            foreach (Feld f in Form1.getButtonsRight())
            {
                if (u)
                {
                    if (Form1.getButtonsRight()[f.getX(), f.getY()].getShipID() != -1)
                        switch (f.getStatus())
                        {
                            case Status.HIT:
                                f.BackColor = Color.LightSalmon;
                                break;
                        }
                    else
                        f.BackColor = Color.WhiteSmoke;
                }
            }
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {

        }

        private void buttonSetName_Click(object sender, EventArgs e)
        {

        }
    }
}
