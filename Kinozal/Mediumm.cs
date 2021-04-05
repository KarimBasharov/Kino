using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kinozal
{
    public partial class Mediumm : Form
    {
        private List<Label> _labels;
        SqlConnection connect = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\karim\Source\Repos\Kinoo\Kinozal\AppData\Database1.mdf; Integrated Security = True");
        SqlCommand command;
        SqlDataAdapter adapter, adapter2;
        Button btn;
        Form1 f1 = new Form1();
        int ool;
        int moo;
        DateTime sesioo;

        List<string> pol = new List<string>();
        public Mediumm(int ol, int mo, DateTime date)
        {

            this.Height = 460;
            this.Width = 550;
            sesioo = date;
            moo = mo;

            ool = ol;

            connect.Open();
            command = new SqlCommand("SELECT Place From Placee Where Hall=@id AND MovieId=@mo AND Session=@ses", connect);
            command.Parameters.AddWithValue("@id", ool);
            command.Parameters.AddWithValue("@mo", moo);
            command.Parameters.AddWithValue("@ses", sesioo);
            command.ExecuteNonQuery();
            SqlDataReader reader;
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                pol.Add(reader.GetValue(0).ToString());
            }
            connect.Close();

            InitializeComponent();

            Button btn = new Button
            {
                Location = new Point(11, 260),
                Text = "Сохранить"
            };
            this.Controls.Add(btn);
            btn.MouseClick += Btn_MouseClick;

            _labels = new List<Label>();
            for (var i = 0; i <= 39; i++)
            {
                Label a = new Label()
                {
                    Name = "place" + i,
                    Height = 50,
                    Width = 50,
                    MinimumSize = new Size(50, 50),
                    BorderStyle = BorderStyle.Fixed3D,
                    BackColor = Color.LightYellow
                };
                a.MouseClick += A_MouseClick;
                _labels.Add(a);

                if (pol.Contains(a.Name))
                {
                    a.BackColor = Color.Red;
                }

                // 581, 517
                var x = 0;
                var y = 0;

                foreach (var lbl in _labels)
                {
                    if (x >= 400)
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
            foreach (var el in _labels)
            {
                if (el.BackColor == Color.Red)
                {
                    connect.Open();
                    command = new SqlCommand("INSERT INTO Placee(Place, Hall, MovieId, Session) VALUES(@pla,@hal,@mo,@sess)", connect);
                    command.Parameters.AddWithValue("@pla", el.Name);
                    command.Parameters.AddWithValue("@hal", ool);
                    command.Parameters.AddWithValue("@mo", moo);
                    command.Parameters.AddWithValue("@sess", sesioo);
                    command.ExecuteNonQuery();
                    connect.Close();
                }
            }

            MessageBox.Show("Ваш выбор был сохранен");

            this.Dispose();
        }

        private void A_MouseClick(object sender, MouseEventArgs e)
        {
            var a = (Label)sender;
            if (a.BackColor == Color.LightYellow)
            {
                a.BackColor = Color.Red;
            }
            //var answer = MessageBox.Show("Хотите взять это место?", "Сохранение", MessageBoxButtons.YesNo);
            //if (answer == DialogResult.Yes)
            //{
            //    var a = (Label)sender;
            //    a.BackColor = Color.Yellow;
            //}
        }
    }
}
