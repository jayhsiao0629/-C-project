using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool turn = true; // true = X turn; false = Y turn
        int turn_count = 0;
        Button b;
        static string playername, playername2;        
        public static void setplayername(string n1, string n2)
        {
            playername = n1;
            playername2 = n2;
        }

        private void button_click(object sender, EventArgs e)
        {
            turn_count++;
            b = (Button)sender;
            if (turn)
            {
                b.Text = "X";
            }
            else
            {
                b.Text = "O";
            }
            turn = !turn;
            b.Enabled = false;

            bool thereisawinner = false;
            //horizontal check
            if ((button1.Text == button2.Text) && (button2.Text == button3.Text) && (!button1.Enabled))
            {
                thereisawinner = true;
                button1.BackColor = Color.FromArgb(102,255,0);
                button2.BackColor = Color.FromArgb(102, 255, 0);
                button3.BackColor = Color.FromArgb(102, 255, 0);

            }
            else if ((button4.Text == button5.Text) && (button5.Text == button6.Text) && (!button4.Enabled))
            {
                thereisawinner = true;
                button4.BackColor = Color.FromArgb(102, 255, 0);
                button5.BackColor = Color.FromArgb(102, 255, 0);
                button6.BackColor = Color.FromArgb(102, 255, 0);
            }
            else if ((button7.Text == button8.Text) && (button8.Text == button9.Text) && (!button7.Enabled))
            {
                thereisawinner = true;
                button7.BackColor = Color.FromArgb(102, 255, 0);
                button8.BackColor = Color.FromArgb(102, 255, 0);
                button9.BackColor = Color.FromArgb(102, 255, 0);
            }
            // vertical check
            else if ((button1.Text == button4.Text) && (button4.Text == button7.Text) && (!button1.Enabled))
            {
                thereisawinner = true;
                button1.BackColor = Color.FromArgb(102, 255, 0);
                button4.BackColor = Color.FromArgb(102, 255, 0);
                button7.BackColor = Color.FromArgb(102, 255, 0);
            }
            else if ((button2.Text == button5.Text) && (button5.Text == button8.Text) && (!button2.Enabled))
            {
                thereisawinner = true;
                button2.BackColor = Color.FromArgb(102, 255, 0);
                button5.BackColor = Color.FromArgb(102, 255, 0);
                button8.BackColor = Color.FromArgb(102, 255, 0);
            }
            else if ((button3.Text == button6.Text) && (button6.Text == button9.Text) && (!button3.Enabled))
            {
                thereisawinner = true;
                button3.BackColor = Color.FromArgb(102, 255, 0);
                button6.BackColor = Color.FromArgb(102, 255, 0);
                button9.BackColor = Color.FromArgb(102, 255, 0);
            }
            // diagonal check
            else if ((button1.Text == button5.Text) && (button5.Text == button9.Text) && (!button1.Enabled))
            {
                thereisawinner = true;
                button1.BackColor = Color.FromArgb(102, 255, 0);
                button5.BackColor = Color.FromArgb(102, 255, 0);
                button9.BackColor = Color.FromArgb(102, 255, 0);
            }
            else if ((button3.Text == button5.Text) && (button5.Text == button7.Text) && (!button7.Enabled))
            {
                thereisawinner = true;
                button3.BackColor = Color.FromArgb(102, 255, 0);
                button5.BackColor = Color.FromArgb(102, 255, 0);
                button7.BackColor = Color.FromArgb(102, 255, 0);

            }
            if (thereisawinner)
            {
                string winner = "";
                if (turn)
                {
                    winner = label3.Text;
                    label6.Text = (Int32.Parse(label6.Text) + 1).ToString();
                }
                else
                {
                    winner = label1.Text;
                    label4.Text = (Int32.Parse(label4.Text) + 1).ToString();

                }
                MessageBox.Show(winner + " Wins!");
                newGameToolStripMenuItem.PerformClick();
                
            }
            else
            {
                if (turn_count == 9)
                {
                    label5.Text = (Int32.Parse(label5.Text) + 1).ToString();

                    MessageBox.Show("No winner");
                    newGameToolStripMenuItem.PerformClick();
                }
            }
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = (Int32.Parse(toolStripStatusLabel1.Text) + 1).ToString();

            turn = true;
            turn_count = 0;
         
            foreach(Control c in panel1.Controls)
            {
                b = (Button)c;
                b.BackColor = Color.WhiteSmoke;
                b.Text = "button";
                b.Enabled = true;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_enter(object sender, EventArgs e)
        {
            b = (Button)sender;
            if(turn)
            {
                b.Text = "X";
            }
            else
            {
                b.Text = "O";
            }
        }

        private void button_leave(object sender, EventArgs e)
        {
            b = (Button)sender;
            if(b.Enabled)
            {
                b.Text = "button";
            }
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "1";
            label4.Text = "0";
            label5.Text = "0";
            label6.Text = "0";
            turn = true;
            turn_count = 0;
            foreach (Control c in panel1.Controls)
            {
                b = (Button)c;
                b.BackColor = Color.WhiteSmoke;
                b.Text = "button";
                b.Enabled = true;
            }

        }
        int counter = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            counter = 0;
            timer1.Interval = 1000;
            timer1.Enabled = true;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            counter = counter + 1;
            toolStripTextBox1.Text = "Playing time   "+counter.ToString();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult c;
            c = MessageBox.Show("是否要關閉頁面?", "關閉頁面", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (c == DialogResult.No)
            {
                e.Cancel = true;
            }
            else if (c == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
            toolStripStatusLabel1.Text = "1";
            label4.Text = "0";
            label5.Text = "0";
            label6.Text = "0";
            turn = true;
            turn_count = 0;
            foreach (Control a in panel1.Controls)
            {
                b = (Button)a;
                b.BackColor = Color.WhiteSmoke;
                b.Text = "button";
                b.Enabled = true;
            }
        }

        private void logInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f2 = new Form2();
            f2.ShowDialog();
            label1.Text = playername + "";
            label3.Text = playername2 + "";
            label4.Text = "0";
            label5.Text = "0";
            label6.Text = "0";
            toolStripStatusLabel1.Text = "0";
        }
    }
}
