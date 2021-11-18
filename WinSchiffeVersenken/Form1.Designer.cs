
using System.Windows.Forms;

namespace WinSchiffeVersenken
{
    partial class Form1
    {

        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        //=======
        //
        //=======
        private void privateInit()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            Form1.labelOut = new System.Windows.Forms.Label();
            Form1.labelOpponent = new System.Windows.Forms.Label();
            this.labelOpponentHeader = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();



            Form1.pictureBoxes = new FeldLinks[Settings.SIZE, Settings.SIZE];
            for (int x = 0; x < Settings.SIZE; x++)
            {
                for (int y = 0; y < Settings.SIZE; y++)
                {
                    Form1.pictureBoxes[x, y] = new FeldLinks(x, y);
                }
            }
            this.textBoxes = new TextBox[Settings.SIZE + 1, Settings.SIZE + 1];
            for (int x = 0; x < Settings.SIZE + 1; x++)
            {
                for (int y = 0; y < Settings.SIZE + 1; y++)
                {
                    if (!(x == 0 || y == 0))
                        continue;
                    if (x == 0 && y == 0)
                        continue;
                    this.textBoxes[x, y] = new TextBox();
                }
            }

            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();


            this.button1 = new System.Windows.Forms.Button();

            Form1.buttons = new Feld[Settings.SIZE, Settings.SIZE];
            for (int x = 0; x < Settings.SIZE; x++)
            {
                for (int y = 0; y < Settings.SIZE; y++)
                {
                    Form1.buttons[x, y] = new Feld(x, y);
                }
            }
            this.button2 = new System.Windows.Forms.Button();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.buttonSetName = new System.Windows.Forms.Button();
            foreach (FeldLinks box in Form1.pictureBoxes)
            {
                ((System.ComponentModel.ISupportInitialize)(box)).BeginInit();
            }

            this.SuspendLayout();

            int z = 0;
            for (int x = 0; x < Settings.SIZE; x++)
            {
                for (int y = 0; y < Settings.SIZE; y++)
                {
                    Form1.pictureBoxes[x, y].BackColor = System.Drawing.SystemColors.ButtonHighlight;
                    Form1.pictureBoxes[x, y].Location = new System.Drawing.Point(95 + x * 55, 82 + 52 * y);
                    Form1.pictureBoxes[x, y].Name = "x" + (x + 1) + "y" + (y + 1);
                    Form1.pictureBoxes[x, y].Size = new System.Drawing.Size(49, 46);
                    Form1.pictureBoxes[x, y].TabIndex = z + 1;
                    Form1.pictureBoxes[x, y].TabStop = false;
                    Form1.pictureBoxes[x, y].Click += new System.EventHandler(this.pBoxClick);
                    z++;
                }
            }


            int t = 0;
            for (int x = 0; x < Settings.SIZE + 1; x++)
            {
                for (int y = 0; y < Settings.SIZE + 1; y++)
                {
                    if (!(x == 0 || y == 0))
                        continue;
                    if (x == 0 && y == 0)
                        continue;
                    this.textBoxes[x, y].BackColor = System.Drawing.SystemColors.ControlLightLight;
                    this.textBoxes[x, y].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    this.textBoxes[x, y].Location = new System.Drawing.Point(40 + 55 * x, 45 + 52 * y);
                    this.textBoxes[x, y].Name = "textBox" + t;
                    this.textBoxes[x, y].Enabled = false;
                    this.textBoxes[x, y].Size = new System.Drawing.Size(49, 13);
                    this.textBoxes[x, y].TabIndex = 17;
                    if (x == 0)
                        this.textBoxes[x, y].Text = "      y" + y;
                    else
                        this.textBoxes[x, y].Text = "      x" + x;
                    t++;
                }
            }

            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(Settings.SIZE * 55 + 164, 64);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(86, 20);
            this.textBox9.TabIndex = 25;
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(Settings.SIZE * 55 + 164, 96);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(86, 20);
            this.textBox10.TabIndex = 26;
            // 
            // textBox11
            // 
            this.textBox11.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox11.Location = new System.Drawing.Point(Settings.SIZE * 55 + 110, 67);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(48, 13);
            this.textBox11.TabIndex = 27;
            this.textBox11.Text = "X-Koord.";
            // 
            // textBox12
            // 
            this.textBox12.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox12.Location = new System.Drawing.Point(Settings.SIZE * 55 + 110, 99);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(48, 13);
            this.textBox12.TabIndex = 28;
            this.textBox12.Text = "Y-Koord.";
            // 
            // textBoxName
            // 
            this.textBoxName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxName.Location = new System.Drawing.Point(Settings.SIZE * 55 - 330, 20);
            this.textBoxName.Name = "textBox12";
            this.textBoxName.Size = new System.Drawing.Size(48, 13);
            this.textBoxName.TabIndex = 28;
            this.textBoxName.Text = "";

            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(Settings.SIZE * 55 + 164, 141);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 22);
            this.button1.TabIndex = 29;
            this.button1.Text = "platzieren";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(Settings.SIZE * 55 - 224, 20);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(84, 22);
            this.buttonConnect.TabIndex = 29;
            this.buttonConnect.Text = "Verbinden";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // buttonSetName
            //
            this.buttonSetName.Location = new System.Drawing.Point(Settings.SIZE * 55 - 280, 20);
            this.buttonSetName.Name = "buttonSetName";
            this.buttonSetName.Size = new System.Drawing.Size(54, 22);
            this.buttonSetName.TabIndex = 29;
            this.buttonSetName.Text = "Name ändern";
            this.buttonSetName.UseVisualStyleBackColor = true;
            this.buttonSetName.Click += new System.EventHandler(this.buttonSetName_Click);

            int i = 0;
            for (int x = 0; x < Settings.SIZE; x++)
            {
                for (int y = 0; y < Settings.SIZE; y++)
                {
                    Form1.buttons[x, y].Location = new System.Drawing.Point(Settings.SIZE * 55 + 300 + x * 55, 75 + y * 53);
                    Form1.buttons[x, y].Name = "_x" + (x + 1) + "y" + (y + 1);
                    //Form1.buttons[x, y].Margin = new System.Windows.Forms.Padding(0);
                    Form1.buttons[x, y].Size = new System.Drawing.Size(55, 53);
                    Form1.buttons[x, y].TabIndex = 30 + i;
                    Form1.buttons[x, y].Text = "";
                    Form1.buttons[x, y].UseVisualStyleBackColor = true;
                    Form1.buttons[x, y].Click += new System.EventHandler(this.btnClick);
                    i++;
                }
            }
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(Settings.SIZE * 55 + 164, 187);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(84, 40);
            this.button2.TabIndex = 54;
            this.button2.Text = "Nächstes Schiff";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.nextShip);


            // 
            // labelOut
            // 
            Form1.labelOut.AutoSize = false;
            Form1.labelOut.Location = new System.Drawing.Point(Settings.SIZE * 55 + 110, 287);
            Form1.labelOut.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            Form1.labelOut.Name = "label1";
            Form1.labelOut.Size = new System.Drawing.Size(180, 30);
            Form1.labelOut.TabIndex = 0;
            Form1.labelOut.Text = "Willkomen bei Schiffe Versenken!";
            // 
            // labelOpponentHeader
            // 
            this.labelOpponentHeader.AutoSize = true;
            this.labelOpponentHeader.Location = new System.Drawing.Point(Settings.SIZE * 55 + Settings.SIZE * 55 / 2 + 200, 20);
            this.labelOpponentHeader.Name = "label1";
            this.labelOpponentHeader.Size = new System.Drawing.Size(39, 14);
            this.labelOpponentHeader.TabIndex = 0;
            this.labelOpponentHeader.Text = "Dein Gegner: ";

            // 
            // labelOpponent
            // 
            Form1.labelOpponent.AutoSize = true;
            Form1.labelOpponent.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            Form1.labelOpponent.Location = new System.Drawing.Point(Settings.SIZE * 55 + Settings.SIZE * 55 / 2 + 310, 20);
            Form1.labelOpponent.Name = "labelOpponent";
            Form1.labelOpponent.Size = new System.Drawing.Size(39, 14);
            Form1.labelOpponent.TabIndex = 0;
            Form1.labelOpponent.Text = "Gegnername";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelName.Location = new System.Drawing.Point(100, 20);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(39, 14);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Name: ";

            // 
            // 
            // Form1
            // 
            //this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            //this.ClientSize = new System.Drawing.Size(951, 338);
            this.ClientSize = new System.Drawing.Size(Settings.SIZE * 55 * 2 + 350, Settings.SIZE * 55 + 130);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$battleship.ico")));

            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonSetName);
            this.Controls.Add(this.buttonConnect);

            foreach (TextBox box in this.textBoxes)
            {
                this.Controls.Add(box);
            }

            this.Controls.Add(this.textBox12);
            this.Controls.Add(this.textBox11);
            this.Controls.Add(this.textBox10);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.textBoxName);

            this.Controls.Add(Form1.labelOut);
            this.Controls.Add(Form1.labelOpponent);
            this.Controls.Add(this.labelOpponentHeader);
            this.Controls.Add(this.labelName);

            foreach (Feld btn in Form1.buttons)
            {
                this.Controls.Add(btn);
            }
            this.Controls.Add(this.button1);

            foreach (FeldLinks btn in Form1.pictureBoxes)
            {
                this.Controls.Add(btn);
            }
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);//
            this.Name = "Form1";
            this.Text = "WORLD OF WARSHIPZZZZ";

            foreach (FeldLinks btn in Form1.pictureBoxes)
            {
                ((System.ComponentModel.ISupportInitialize)(btn)).EndInit();
            }
            this.ResumeLayout(false);
            this.PerformLayout();
        }









        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {

            Form1.pictureBoxes = new FeldLinks[Settings.SIZE, Settings.SIZE];
            for (int x = 0; x < Settings.SIZE; x++)
            {
                for (int y = 0; y < Settings.SIZE; y++)
                {
                    Form1.pictureBoxes[x, y] = new FeldLinks(x,y);
                }
            }
            
            this.textBoxes = new TextBox[Settings.SIZE, Settings.SIZE];
            for (int x = 0; x < Settings.SIZE; x++)
            {
                for (int y = 0; y < Settings.SIZE; y++)
                {
                    if (!(x == 0 || y == 0))
                        continue;
                    this.textBoxes[x, y] = new TextBox();
                }
            }
            
            this.button1 = new System.Windows.Forms.Button();
            
            Form1.buttons = new Feld[Settings.SIZE, Settings.SIZE];
            for(int x = 0; x < Settings.SIZE; x++)
            {
                for(int y = 0; y < Settings.SIZE; y++)
                {
                    Form1.buttons[x, y] = new Feld(x, y);
                }
            }
            
            this.button2 = new System.Windows.Forms.Button();
            foreach(FeldLinks box in Form1.pictureBoxes)
            {
                ((System.ComponentModel.ISupportInitialize)(box)).BeginInit();
            }
            
            this.SuspendLayout();

            int z = 0;
            for (int x = 0; x < Settings.SIZE; x++)
            {
                for (int y = 0; y < Settings.SIZE; y++)
                {
                    Form1.pictureBoxes[x, y].BackColor = System.Drawing.SystemColors.ButtonHighlight;
                    Form1.pictureBoxes[x, y].Location = new System.Drawing.Point(95 + x * 55, 82 + 52 * y);
                    Form1.pictureBoxes[x, y].Name = "x" + (x+1) + "y" + (y+1);
                    Form1.pictureBoxes[x, y].Size = new System.Drawing.Size(49, 46);
                    Form1.pictureBoxes[x, y].TabIndex = z + 1;
                    Form1.pictureBoxes[x, y].TabStop = false;
                    Form1.pictureBoxes[x, y].Click += new System.EventHandler(this.pBoxClick);
                    z++;
                }
            }

            int t = 0;
            for (int x = 0; x < Settings.SIZE; x++)
            {
                for (int y = 0; y < Settings.SIZE; y++)
                {
                    if (!(x == 0 || y == 0))
                        continue;
                    if (x == 0 && y == 0)
                        continue;
                    this.textBoxes[x,y].BackColor = System.Drawing.SystemColors.ControlLightLight;
                    this.textBoxes[x,y].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    this.textBoxes[x, y].Location = new System.Drawing.Point(30 + 55 * x, 45 + 53 * y);
                    this.textBoxes[x, y].Name = "textBox" + t;
                    this.textBoxes[x, y].Size = new System.Drawing.Size(49, 13);
                    this.textBoxes[x, y].TabIndex = 17;
                    if (x == 0)
                        this.textBoxes[x, y].Text = "      x" + (x + 1);
                    else
                        this.textBoxes[x, y].Text = "      y" + (y + 1);
                    t++;
                }
            }
            
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(397, 141);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 22);
            this.button1.TabIndex = 29;
            this.button1.Text = "platzieren";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);

            int i = 0;
            for(int x = 0; x < Settings.SIZE; x++)
            {
                for(int y = 0; y < Settings.SIZE; y++)
                {
                    Form1.buttons[x, y].Location = new System.Drawing.Point(635 + x * 55, 75 + y * 53);
                    Form1.buttons[x, y].Name = "_x" + (x+1) + "y" + (y+1);
                    Form1.buttons[x, y].Size = new System.Drawing.Size(49, 47);
                    Form1.buttons[x, y].TabIndex = 30 + i;
                    Form1.buttons[x, y].Text = "button2";
                    Form1.buttons[x, y].UseVisualStyleBackColor = true;
                    Form1.buttons[x, y].Click += new System.EventHandler(this.btnClick);
                    i++;
                }
            }
            
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(397, 187);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(84, 40);
            this.button2.TabIndex = 54;
            this.button2.Text = "Nächstes Schiff";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // 
            // Form1
            // 
            //this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            //this.ClientSize = new System.Drawing.Size(951, 338);
            this.ClientSize = new System.Drawing.Size(1110, 364);
            this.Controls.Add(this.button2);

            foreach(TextBox box in this.textBoxes)
            {
                this.Controls.Add(box);
            }

            foreach (Feld btn in Form1.buttons)
            {
                this.Controls.Add(btn);
            }
            
            this.Controls.Add(this.button1);

            foreach (FeldLinks btn in Form1.pictureBoxes)
            {
                this.Controls.Add(btn);
            }
            
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);//
            this.Name = "Form1";
            this.Text = "Form1";

            foreach (FeldLinks btn in Form1.pictureBoxes)
            {
                ((System.ComponentModel.ISupportInitialize)(btn)).EndInit();
            }
            
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private static FeldLinks[,] pictureBoxes;
        private TextBox[,] textBoxes;
        
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.TextBox textBoxName;

        private static System.Windows.Forms.Label labelOut;
        private System.Windows.Forms.Label labelOpponentHeader;
        private static System.Windows.Forms.Label labelOpponent;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Button buttonSetName;
        private System.Windows.Forms.Button button1;
        private static Feld[,] buttons;
        
        internal static Label getLabelOut()
        {
            return labelOut;
        }

        internal static FeldLinks[,] getPicBoxes()
        {
            return pictureBoxes;
        }

        internal static Feld[,] getButtonsRight()
        {
            return buttons;
        }
        
        internal static Label getNameBox()
        {
            return labelOpponent;
        }
    }
}
