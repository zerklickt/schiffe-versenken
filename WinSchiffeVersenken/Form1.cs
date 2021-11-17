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
            InitializeComponent();
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

        private void btnClick(object sender, EventArgs e)
        {
            sp.GetSpielfeld().checkClick((Feld) sender);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        

    }
}
