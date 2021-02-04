using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kinozal
{
    public partial class Form1 : Form
    {
        Button btn1, btn2, btn3;
        Label lbl;
        public Form1()
        {
            InitializeComponent();
            this.Height = 191;
            this.Width = 367;
            btn1 = new Button
            {
                Text = "Маленький",
                Location = new Point(11, 70),
                Height = 40,
                Width = 100
            };
            this.Controls.Add(btn1);
            btn1.Click += Btn1_Click;
            btn2 = new Button
            {
                Text = "Средний",
                Location = new Point(111, 70),
                Height = 40,
                Width = 100
            };
            this.Controls.Add(btn2);
            btn2.Click += Btn2_Click;
            btn3 = new Button
            {
                Text = "Большой",
                Location = new Point(211, 70),
                Height = 40,
                Width = 100
            };
            this.Controls.Add(btn3);
            btn3.Click += Btn3_Click;
            lbl = new Label
            {
                Text = "Выберите размер кинозала",
                Location = new Point(22, 30),
                Width = 280,
            };
            lbl.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
            this.Controls.Add(lbl);
        }

        private void Btn3_Click(object sender, EventArgs e)
        {
            Bigg bigg = new Bigg();
            bigg.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int R, G, B;
            R = rnd.Next(0, 255);
            G = rnd.Next(0, 255);
            B = rnd.Next(0, 255);

            BackColor = Color.FromArgb(R, G, B);
        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            Mediumm mediumm = new Mediumm();
            mediumm.Show();
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            Smalll small = new Smalll();
            small.Show();
        }

    }
}
