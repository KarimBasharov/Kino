﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
        SqlConnection connect = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\opilane\source\repos\KarimBasharov\Kinozal\Kinozal\AppData\Database1.mdf; Integrated Security = True");
        SqlCommand command;
        SqlDataAdapter adapter, adapter2;
        Button btn;
        Form1 f1 = new Form1();

        public Smalll()
        {
            InitializeComponent();

            Button btn = new Button
            {
                Location = new Point(451, 31),
                Text = "Сохранить"
            };
            this.Controls.Add(btn);
            btn.MouseClick += Btn_MouseClick;

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

        private void Btn_MouseClick(object sender, MouseEventArgs e)
        {
            foreach(var el in _labels)
            {
                if(el.BackColor == Color.Red)
                {
                    connect.Open();
                    command = new SqlCommand("INSERT INTO Placee(Place, Hall) VALUES(@pla,@hal)", connect);
                    command.Parameters.AddWithValue("@pla", el);
                    command.Parameters.AddWithValue("@hal", f1.roombox.SelectedIndex);
                    command.ExecuteNonQuery();
                    connect.Close();
                }
            }

            

        }

        private void A_MouseClick(object sender, MouseEventArgs e)
        {
            var a = (Label)sender;
            if (a.BackColor == Color.LightYellow)
            {
                a.BackColor = Color.Red;
            }
            else if (a.BackColor == Color.Red)
            {
                DialogResult dialog = MessageBox.Show("Хотите отменить свой выбор?", "" ,MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    a.BackColor = Color.LightYellow;
                }
                else if(dialog == DialogResult.No)
                {
                    a.BackColor = Color.Red;
                }
            }
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
