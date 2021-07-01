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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        bool turn = true; // true = X turn; false = Y turn
        int turn_count = 0;
        Button b;
        static string playername;
        int click_count = 0;

        public static void setplayername(string n1)
        {
            playername = n1;
            
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = (Int32.Parse(toolStripStatusLabel1.Text) + 1).ToString();
            click_count = 0;
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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button_enter(object sender, EventArgs e)
        {
            b = (Button)sender;
            if (turn)
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
            if (b.Enabled)
            {
                b.Text = "button";
            }
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label4.Text = "0";
            label5.Text = "0";
            label6.Text = "0";
            toolStripStatusLabel1.Text = "1";
            click_count = 0;
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

        private void Form3_Load(object sender, EventArgs e)
        {
            counter = 0;
            timer1.Interval = 1000;
            timer1.Enabled = true;
            timer1.Start();
        }
        private void computer_make_move()
        {
            Button move = null;
          
            move = look_for_win_or_block("O");
            if( move == null)
            {
                move = look_for_win_or_block("X");
                if(move == null)
                {
                    move = look_for_corner();
                    if(move == null)
                    {
                        move = look_for_open_space();
                    }
                }
                
            }
            click_count++;
            if (click_count!=5)
            {
                move.PerformClick();
            }
        }
        
        private Button look_for_win_or_block(string mark)
        {
            Console.WriteLine("Looking for win or block:  " + mark);
            //HORIZONTAL TESTS
            if ((button1.Text == mark) && (button2.Text == mark) && (button3.Text == "button"))
                return button3;
            if ((button2.Text == mark) && (button3.Text == mark) && (button1.Text == "button"))
                return button1;
            if ((button1.Text == mark) && (button3.Text == mark) && (button2.Text == "button"))
                return button2;

            if ((button4.Text == mark) && (button5.Text == mark) && (button6.Text == "button"))
                return button6;
            if ((button5.Text == mark) && (button6.Text == mark) && (button4.Text == "button"))
                return button4;
            if ((button4.Text == mark) && (button6.Text == mark) && (button5.Text == "button"))
                return button5;

            if ((button7.Text == mark) && (button8.Text == mark) && (button9.Text == "button"))
                return button9;
            if ((button8.Text == mark) && (button9.Text == mark) && (button7.Text == "button"))
                return button7;
            if ((button7.Text == mark) && (button9.Text == mark) && (button8.Text == "button"))
                return button8;

            //VERTICAL TESTS
            if ((button1.Text == mark) && (button4.Text == mark) && (button7.Text == "button"))
                return button7;
            if ((button4.Text == mark) && (button7.Text == mark) && (button1.Text == "button"))
                return button1;
            if ((button1.Text == mark) && (button7.Text == mark) && (button4.Text == "button"))
                return button4;

            if ((button2.Text == mark) && (button5.Text == mark) && (button8.Text == "button"))
                return button8;
            if ((button5.Text == mark) && (button8.Text == mark) && (button2.Text == "button"))
                return button2;
            if ((button2.Text == mark) && (button8.Text == mark) && (button5.Text == "button"))
                return button5;

            if ((button3.Text == mark) && (button6.Text == mark) && (button9.Text == "button"))
                return button9;
            if ((button6.Text == mark) && (button9.Text == mark) && (button3.Text == "button"))
                return button3;
            if ((button3.Text == mark) && (button9.Text == mark) && (button6.Text == "button"))
                return button6;

            //DIAGONAL TESTS
            if ((button1.Text == mark) && (button5.Text == mark) && (button9.Text == "button"))
                return button9;
            if ((button5.Text == mark) && (button9.Text == mark) && (button1.Text == "button"))
                return button1;
            if ((button1.Text == mark) && (button9.Text == mark) && (button5.Text == "button"))
                return button5;

            if ((button3.Text == mark) && (button5.Text == mark) && (button7.Text == "button"))
                return button7;
            if ((button5.Text == mark) && (button7.Text == mark) && (button3.Text == "button"))
                return button3;
            if ((button3.Text == mark) && (button7.Text == mark) && (button5.Text == "button"))
                return button5;

            return null;
        }
        private Button look_for_corner()
        {
            Console.WriteLine("Looking for corner");
            if (button1.Text == "O")
            {
                if (button3.Text == "button")
                    return button3;
                if (button9.Text == "button")
                    return button9;
                if (button7.Text == "button")
                    return button7;
            }
            if (button3.Text == "O")
            {
                if (button1.Text == "button")
                    return button1;
                if (button9.Text == "button")
                    return button9;
                if (button7.Text == "button")
                    return button7;
            }

            if (button9.Text == "O")
            {
                if (button1.Text == "button")
                    return button3;
                if (button3.Text == "button")
                    return button3;
                if (button7.Text == "button")
                    return button7;
            }

            if (button7.Text == "O")
            {
                if (button1.Text == "button")
                    return button3;
                if (button3.Text == "button")
                    return button3;
                if (button9.Text == "button")
                    return button9;
            }

            if (button1.Text == "button")
                return button1;
            if (button3.Text == "button")
                return button3;
            if (button7.Text == "button")
                return button7;
            if (button9.Text == "button")
                return button9;

            return null;
        }
        private Button look_for_open_space()
        {
            Console.WriteLine("Looking for open space");
            Button b = null;
            foreach (Control c in Controls)
            {
                b = c as Button;
                if (b != null)
                {
                    if (b.Text == "button")
                        return b;
                }//end if
            }//end if

            return null;
        }

        private void button_click(object sender, EventArgs e)
        {           
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
            turn_count++;
            check_for_winner();

            if (!turn)
            {
                computer_make_move();
            }       
        }

        private void check_for_winner()
        {
            bool thereisawinner = false;
            //horizontal check
            if ((button1.Text == button2.Text) && (button2.Text == button3.Text) && (!button1.Enabled))
            {
                thereisawinner = true;
                button1.BackColor = Color.FromArgb(102, 255, 0);
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
        private void timer1_Tick(object sender, EventArgs e)
        {
            counter = counter + 1;
            toolStripTextBox1.Text = "Playing time   " + counter.ToString();
        }
        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
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
            Form f4 = new Form4();
            f4.ShowDialog();
            label1.Text = playername + "";
            label4.Text = "0";
            label5.Text = "0";
            label6.Text = "0";
            toolStripStatusLabel1.Text = "0";
        }
    }
}
