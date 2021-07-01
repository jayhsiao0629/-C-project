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
    class Menu : Form
    {
        private int width
        {
            get
            {
                return Width;
            }
            set
            {
                if (value > 0)
                {
                    Width = value;
                }
                else
                {
                    Width = 500;
                }
            }
        }

        private int height
        {
            get
            {
                return Height;
            }
            set
            {
                if (value > 0)
                {
                    Height = value;
                }
                else
                {
                    Height = 500;
                }
            }
        }

        public List<Form> forms = new List<Form>();

        public Menu()
        {
            Text = "表單 Hub 1";
            StartPosition = FormStartPosition.CenterScreen;
            width = 500;
            height = 500;
        }
        public Menu(int w, int h)
        {
            Text = "Tic Tac Toe";
            StartPosition = FormStartPosition.CenterScreen;
            width = w;
            height = h;
            BackColor = Color.FromArgb(255,255,153);
        }
        public void Create_Button()
        {
            for (int i = 1; i <= forms.Count; i++)
            {
                Button btn = new Button();
                Label lb = new Label();
                btn.Font = new Font("新細明體", 12);
                if (i == 1)
                {
                    lb.Text = "01";
                    btn.Text = "第1種模式:  "+"\n\n"+ "  Player v.s. Player";
                }
                else if(i == 2)
                {
                    lb.Text = "02";
                    btn.Text = "第2種模式: "+"\n\n"+ " Player v.s. Computer ";
                }
                btn.Click += Button_Click;
                btn.Location = new Point(135, 10 + (i - 1) * 200);
                btn.Size = new Size(200, 200);
                btn.BackColor = Color.WhiteSmoke;
                Controls.Add(btn);
            }
            
        }
        private void Button_Click(object sender, EventArgs e)
        {
            int index = int.Parse(((Button)sender).Text.Substring(1, 1));
            forms[index - 1].ShowDialog();
        }
        public void Show()
        {
            ShowDialog();
        }
    }
}
