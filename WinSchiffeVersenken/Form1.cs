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
    public partial class Form1 : Form
    {

        private Spiel sp;
        private User me;
        public Form1()
        {
            InitializeComponent();
            _x1y1.setShipID(0);
            
            me = new User("testuser", "password");
            sp = new Spiel(me, new User("testuser2", "passwort2"));
            me.addShip(new Schiffe(3));
        }

        public int x = 0, y = 0;
        int[,] schiff = new int[4, 4];

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

            schiff[1, 2] = 1;
            schiff[1, 3] = 1;

            if (x == 1 && y == 1)
            {
                x1y1.BackColor = Color.Black;
            }
            if (x == 2 && y == 1)
            {
                x2y1.BackColor = Color.Black;
            }
            if (x == 3 && y == 1)
            {
                x3y1.BackColor = Color.Black;
            }
            if (x == 4 && y == 1)
            {
                x4y1.BackColor = Color.Black;
            }
            if (x == 1 && y == 2)
            {
                x1y2.BackColor = Color.Black;
            }
            if (x == 2 && y == 2)
            {
                x2y2.BackColor = Color.Black;
            }
            if (x == 3 && y == 2)
            {
                x3y2.BackColor = Color.Black;
            }
            if (x == 4 && y == 2)
            {
                x4y2.BackColor = Color.Black;
            }
            if (x == 1 && y == 3)
            {
                x1y3.BackColor = Color.Black;
            }
            if (x == 2 && y == 3)
            {
                x2y3.BackColor = Color.Black;
            }
            if (x == 3 && y == 3)
            {
                x3y3.BackColor = Color.Black;
            }
            if (x == 4 && y == 3)
            {
                x4y3.BackColor = Color.Black;
            }
            if (x == 1 && y == 4)
            {
                x1y4.BackColor = Color.Black;
            }
            if (x == 2 && y == 4)
            {
                x2y4.BackColor = Color.Black;
            }
            if (x == 3 && y == 4)
            {
                x3y4.BackColor = Color.Black;
            }
            if (x == 4 && y == 4)
            {
                x4y4.BackColor = Color.Black;
            }
        }

        private void _x1y1_Click(object sender, EventArgs e)
        {
            x = 1;
            y = 1;
            checkClick(_x1y1);
            
        }

        private void _x2y1_Click(object sender, EventArgs e)
        {
            x = 2;
            y = 1;
            checkClick(_x2y1);
        }

        private void _x3y1_Click(object sender, EventArgs e)
        {
            x = 3;
            y = 1;
            checkClick(_x3y1);
        }

        private void _x4y1_Click(object sender, EventArgs e)
        {
            x = 4;
            y = 1;
            checkClick(_x4y1);
        }

        private void _x1y2_Click(object sender, EventArgs e)
        {
            x = 1;
            y = 2;
            checkClick(_x1y2);
        }

        private void _x2y2_Click(object sender, EventArgs e)
        {
            
            x = 2;
            y = 2;
            checkClick(_x2y2);
        }

        private void _x3y2_Click(object sender, EventArgs e)
        {
            x = 3;
            y = 2;
            checkClick(_x3y2);
        }

        private void _x4y2_Click(object sender, EventArgs e)
        {
            x = 4;
            y = 2;
            checkClick(_x4y2);
        }

        private void _x1y3_Click(object sender, EventArgs e)
        {
            x = 1;
            y = 3;
            checkClick(_x1y3);
        }

        private void _x2y3_Click(object sender, EventArgs e)
        {
            x = 2;
            y = 3;
            checkClick(_x2y3);
        }

        private void _x3y3_Click(object sender, EventArgs e)
        {
            x = 3;
            y = 3;
            checkClick(_x3y3);
        }

        private void _x4y3_Click(object sender, EventArgs e)
        {
            x = 4;
            y = 3;
            checkClick(_x4y3);
        }

        private void _x1y4_Click(object sender, EventArgs e)
        {
            x = 1;
            y = 4;
            checkClick(_x1y4);
        }

        private void _x2y4_Click(object sender, EventArgs e)
        {
            x = 2;
            y = 4;
            checkClick(_x2y4);
        }

        private void _x3y4_Click(object sender, EventArgs e)
        {
            x = 3;
            y = 4;
            checkClick(_x3y4);
        }

        private void _x4y4_Click(object sender, EventArgs e)
        {
            x = 4;
            y = 4;
            checkClick(_x4y4);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void checkClick(Feld feld)
        {
            if (feld.getShipID() != -1)
            {
                Schiffe s = me.getShips()[feld.getShipID()];
                s.getroffen();
                s.istversenktfunct();
                if (s.istversenkt())
                {
                    feld.BackColor = Color.Red;
                } else
                {
                    feld.BackColor = Color.LightSalmon;
                }
            }
            else
            {
                feld.BackColor = Color.Blue;
            }
            feld.Enabled = false;
        }

    }
}
