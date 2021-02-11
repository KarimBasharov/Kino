using System;
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
    public partial class Form1 : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\opilane\source\repos\KarimBasharov\Kinozal\Kinozal\AppData\Database1.mdf; Integrated Security = True");
        SqlCommand command;

        SqlDataAdapter adapter, adapter2;
        SaveFileDialog save;
        int Id = 0;

        Button btn1, btn2, btn3;
        Label lbl;
        ComboBox moviebox;
        DataGridView moviedata;
        public Form1()
        {
            //connect.Open();
            //adapter = new SqlDataAdapter("SELECT Saalinimetus FROM Saalid", connect);
            //DataTable Saalidd = new DataTable();
            //adapter.Fill(Saalidd);
            //saalide_list = new ListBox();
            //saalide_list.Location = new Point(10,10);
            //saalide_list.Font = new Font(DefaultFont.FontFamily, 14);
            //new Font(DefaultFont.FontFamily, 14);
            //foreach (DataRow row in Saalid.Rows)
            //{
            //    saalide_list.Items.Add(row["Saalinimetus"])
            //}
            //connect.Close();
            moviedata = new DataGridView
            {
                Location = new Point(451, 30),
                Height = 212,
                Width = 411
            };
            this.Controls.Add(moviedata);
            moviebox = new ComboBox
            {
                Location = new Point(321, 30)
            };
            this.Controls.Add(moviebox);
            this.moviebox.SelectedIndexChanged += Moviebox_SelectedIndexChanged;

            DisplayData();
            InitializeComponent();
            //this.Height = 191;
            //this.Width = 367;
            this.Height = 406;
            this.Width = 900;
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

        private void Moviebox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (moviebox.SelectedIndex != -1)
            {
                /*command = new SqlCommand("SELECT * FROM opilane WHERE GruppId = @grupp", connect);
                connect.Open();
                command.Parameters.AddWithValue("@grupp", comboBox1.SelectedIndex + 1);
                command.ExecuteNonQuery();
                connect.Close();*/
                DataTable table = new DataTable();
                adapter = new SqlDataAdapter();
                command = new SqlCommand("SELECT duration, age FROM Movie WHERE Id = @mo", connect);
                command.Parameters.AddWithValue("@mo", SqlDbType.Int).Value = moviebox.SelectedIndex + 1;
                adapter.SelectCommand = command;
                adapter.Fill(table);
                moviedata.DataSource = table;
            }
        }

        private void Btn3_Click(object sender, EventArgs e)
        {
            Bigg bigg = new Bigg();
            bigg.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 2000;
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
        private void DisplayData()
        {
            connect.Open();
            DataTable table = new DataTable();
            adapter = new SqlDataAdapter("SELECT * FROM Movie", connect);
            adapter.Fill(table);
            moviedata.DataSource = table;

            adapter2 = new SqlDataAdapter("SELECT name FROM Movie", connect);
            DataTable movie_table = new DataTable();
            adapter2.Fill(movie_table);
            foreach (DataRow row in movie_table.Rows)
            {
                moviebox.Items.Add(row["name"]);
            }
            connect.Close();
        }

    }
}
