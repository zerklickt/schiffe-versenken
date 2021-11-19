using SimpleTcp;
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
        private string namebuffer;
        private NetworkClient networkClient;

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
            networkClient = new NetworkClient(this);
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
            networkClient.sendSerialized(new Message(2, "" + ((Feld)sender).getX() + ";" + ((Feld)sender).getY()));
            //sp.GetSpielfeld().checkClick((Feld)sender);
            reload();
        }



        public void DataReceived(object sender, DataReceivedEventArgs e)
        {
            Message m = NetworkClient.FromByteArray<Message>(e.Data);
            if (m.getType() == 1)
            {
                //Name packet: 0 = name;
                namebuffer = m.getPayload();
            }
            else if (m.getType() == 2)
            {
                //Hit Packet: 0 = x; 1 = y;
                string[] sts = m.getPayload().Split(";");
                Message ma = sp.GetSpielfeld().receiveHitPacket(int.Parse(sts[0]), int.Parse(sts[1]));
                networkClient.sendSerialized(ma);
            }
            else if (m.getType() == 3)
            {
                //Received answer to Hit packet: 0 = x; 1 = y; 2 = shipID; 3 = status
                string[] sts = m.getPayload().Split(";");
                int status = int.Parse(sts[3]);
                if(int.Parse(sts[2]) == -1)
                {
                    Form1.getButtonsRight()[int.Parse(sts[0]), int.Parse(sts[1])].setStatus(Status.MISS);
                    return;
                }

                Form1.getButtonsRight()[int.Parse(sts[0]), int.Parse(sts[1])].setShipID(int.Parse(sts[2]));
                if(status == 2)
                {
                    Form1.getButtonsRight()[int.Parse(sts[0]), int.Parse(sts[1])].setStatus(Status.SUNK);
                    foreach(Feld fd in Form1.getButtonsRight())
                    {
                        if(fd.getShipID() == int.Parse(sts[2]))
                        {
                            fd.setStatus(Status.SUNK);
                        }
                    }
                }
                if (status == 1)
                {
                    Form1.getButtonsRight()[int.Parse(sts[0]), int.Parse(sts[1])].setStatus(Status.HIT);
                }
                reload();
            }
            else if (m.getType() == 4)
            {
                Form1.getLabelOut().Text = "Du hast gewonnen!";
            }
        }



        private void pBoxClick(object sender, EventArgs e)
        {
            if (sp.istLinksEingeloggt())
            {
                Form1.getLabelOut().Text = "Keine Änderung mehr möglich";
                return;
            }
            int cache = pictureBoxes[((FeldLinks) sender).getX(),((FeldLinks) sender).getY()].getShipID();
            if (cache == -1)
            {
                ((PictureBox)sender).BackColor = Color.Black;
                pictureBoxes[((FeldLinks)sender).getX(), ((FeldLinks)sender).getY()].setShipID(sp);
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

        /*
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
                    if (Form1.getPicBoxes()[f.getX(), f.getY()].getShipID() != -1)
                    {
                        Schiffe s = sp.getcurrUser().getShips()[Form1.getPicBoxes()[f.getX(), f.getY()].getShipID()];
                        if (s.istversenkt())
                        {
                            f.BackColor = Color.Red;
                        }
                    }
                }
            }
        }
        */
        public void reload()
        {
            Form1.getNameBox().Text = namebuffer;
            bool t = sp.istLinksEingeloggt();
            /*
            foreach (FeldLinks f in Form1.getPicBoxes())
            {
                if (f.getStatus() == Status.HIT)
                {
                    if (!t)
                        f.BackColor = Color.LightSalmon;
                    else
                        f.BackColor = Color.LightPink;

                }
                else if (f.getStatus() == Status.SUNK)
                {
                    if (!t)
                        f.BackColor = Color.Red;
                    else
                        f.BackColor = Color.OrangeRed;
                }
                else if (f.getStatus() == Status.MISS)
                {
                    if (!t)
                        f.BackColor = Color.Blue;
                    else
                        f.BackColor = Color.LightSkyBlue;
                }
            }
            */

            bool u = sp.istRechtsEingeloggt();
            foreach (Feld f in Form1.getButtonsRight())
            {
                if(f.getStatus() == Status.HIT)
                {
                    if(!u)
                        f.BackColor = Color.LightSalmon;
                    else
                        f.BackColor = Color.LightPink;

                } else if (f.getStatus() == Status.SUNK)
                {
                    if (!u)
                        f.BackColor = Color.Red;
                    else
                        f.BackColor = Color.OrangeRed;
                }
                else if (f.getStatus() == Status.MISS)
                {
                    if (!u)
                        f.BackColor = Color.Blue;
                    else
                        f.BackColor = Color.LightSkyBlue;
                }
            }
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if(!networkClient.isConnected())
                networkClient.connect();
        }

        private void buttonSetName_Click(object sender, EventArgs e)
        {
            networkClient.sendSerialized(new Message(1, this.textBoxName.Text));
        }
    }
}
