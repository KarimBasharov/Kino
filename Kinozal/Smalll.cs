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
    public partial class Smalll : Form
    {
        private List<Label> _labels;
        private int xOffset = 10;
        private int yOffset = 10;

        public Smalll()
        {
            InitializeComponent();

            _labels = new List<Label>();
            for (var i = 0; i <= 24; i++)
            {

                Label a = new Label()
                { 
                    Name = "lbl" + i, 
                        Height = 50, 
                        Width = 50, 
                        MinimumSize = new Size(50, 50), 
                        BorderStyle = BorderStyle.Fixed3D, 
                        BackColor = Color.LightYellow
                };
                a.MouseClick += A_MouseClick;
                _labels.Add(a);
                // 581, 517
                var x = 0;
                var y = 0;

                foreach (var lbl in _labels)
                {
                    if (x >= 250)
                    {
                        x = 0;
                        y = y + lbl.Height + 2;
                    }

                    lbl.Location = new Point(x, y);
                    this.Controls.Add(lbl);
                    x += lbl.Width;
                }
            }
        }

        private void A_MouseClick(object sender, MouseEventArgs e)
        {
            var a = (Label)sender;
            a.BackColor = Color.Green;
            //var answer = MessageBox.Show("Хотите взять это место?", "Сохранение", MessageBoxButtons.YesNo);
            //if (answer == DialogResult.Yes)
            //{
            //    var a = (Label)sender;
            //    a.BackColor = Color.Yellow;
            //}
        }

        private void Smalll_Load(object sender, EventArgs e)
        {
            timer1.Interval = 5000;
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
    }
}
