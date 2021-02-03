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
        PictureBox r1, r2, r3, r4, r5, r6;
        public Smalll()
        {
            InitializeComponent();
            this.Height = 489;
            this.Width = 816;

            r1 = new PictureBox
            {
                Height = 52,
                Width = 52,
                BackColor = Color.Green
            };
            this.Controls.Add(r1);
            r1.Click += R1_Click;
            r2 = new PictureBox
            {
                Location = new Point(55, 0),
                Height = 52,
                Width = 52,
                BackColor = Color.Green
            };
            this.Controls.Add(r2);
            r3 = new PictureBox
            {
                Location = new Point(110, 0),
                Height = 52,
                Width = 52,
                BackColor = Color.Green
            };
            this.Controls.Add(r3);
        }

        private void R1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Wow");
        }
    }
}
