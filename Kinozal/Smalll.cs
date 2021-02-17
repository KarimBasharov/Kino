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
            var answer = MessageBox.Show("Хотите взять это место?", "Сохранение", MessageBoxButtons.YesNo);
            if (answer == DialogResult.Yes)
            {
                var a = (Label)sender;
                a.BackColor = Color.Yellow;
            }
        }
    }
}
