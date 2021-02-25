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

        SqlDataAdapter adapter, adapter2, adapter3;
        int Id = 0;

        /*Button btn1, btn2, btn3;
        Label lbl;*/
        public ComboBox moviebox, sessionbox, roombox;
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

            roombox = new ComboBox
            {
                Location = new Point(321, 90)
            };
            roombox.Items.Add("Маленький");
            roombox.Items.Add("Средний");
            roombox.Items.Add("Большой");

            this.Controls.Add(roombox);
            this.roombox.SelectedIndexChanged += Roombox_SelectedIndexChanged;

            sessionbox = new ComboBox
            {
                Location = new Point(321, 60)
            };
            this.Controls.Add(sessionbox);
            this.sessionbox.SelectedIndexChanged += Sessionbox_SelectedIndexChanged;

            DisplayData();
            InitializeComponent();
            //this.Height = 191;
            //this.Width = 367;
            this.Height = 406;
            this.Width = 900;
            /*btn1 = new Button
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
            this.Controls.Add(lbl);*/
        }

        private void Roombox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (roombox.SelectedIndex == 0)
            {
                Smalll small = new Smalll();
                small.Show();
            }
            else if (roombox.SelectedIndex == 1)
            {
                Mediumm mediumm = new Mediumm();
                mediumm.Show();
            }
            else if (roombox.SelectedIndex == 2)
            {
                Bigg bigg = new Bigg();
                bigg.Show();
            }
        }

        private void Sessionbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (moviebox.SelectedIndex == 0)
            {
                DataTable table = new DataTable();
                adapter3 = new SqlDataAdapter();
                command = new SqlCommand("SELECT Date, Time FROM Session WHERE Id = @moo", connect);
                command.Parameters.AddWithValue("@moo", SqlDbType.Int).Value = sessionbox.SelectedIndex + 1;
                adapter3.SelectCommand = command;
                adapter3.Fill(table);
                moviedata.DataSource = table;
            }
            if (moviebox.SelectedIndex == 1)
            {
                DataTable table = new DataTable();
                adapter3 = new SqlDataAdapter();
                command = new SqlCommand("SELECT Date, Time FROM Session WHERE Id = @moo", connect);
                command.Parameters.AddWithValue("@moo", SqlDbType.Int).Value = sessionbox.SelectedIndex + 4;
                adapter3.SelectCommand = command;
                adapter3.Fill(table);
                moviedata.DataSource = table;
            }
            if (moviebox.SelectedIndex == 2)
            {
                DataTable table = new DataTable();
                adapter3 = new SqlDataAdapter();
                command = new SqlCommand("SELECT Date, Time FROM Session WHERE Id = @moo", connect);
                command.Parameters.AddWithValue("@moo", SqlDbType.Int).Value = sessionbox.SelectedIndex + 8;
                adapter3.SelectCommand = command;
                adapter3.Fill(table);
                moviedata.DataSource = table;
            }
            //adapter3 = new SqlDataAdapter("SELECT Date, Time FROM Session", connect);
            //DataTable session_table = new DataTable();
            //adapter3.Fill(session_table);
            //foreach (DataRow row in session_table.Rows)
            //{
            //    sessionbox.Items.Add(row["Date"]);
            //}
        }
        private void Moviebox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (moviebox.SelectedIndex != -1)
            {
                if (moviebox.SelectedIndex == 0)
                {
                    sessionbox.Items.Clear();
                    DataTable table = new DataTable();
                    adapter = new SqlDataAdapter();
                    command = new SqlCommand("SELECT duration, age FROM Movie WHERE Id = @mo", connect);
                    command.Parameters.AddWithValue("@mo", SqlDbType.Int).Value = moviebox.SelectedIndex + 1;
                    adapter.SelectCommand = command;
                    adapter.Fill(table);
                    moviedata.DataSource = table;

                    adapter3 = new SqlDataAdapter("SELECT Date FROM Session Where Film=1", connect);
                    DataTable session_table = new DataTable();
                    adapter3.Fill(session_table);
                    foreach (DataRow row in session_table.Rows)
                    {
                        sessionbox.Items.Add(row["Date"]);
                    }
                }
                else if (moviebox.SelectedIndex == 1)
                {
                    sessionbox.Items.Clear();
                    DataTable table = new DataTable();
                    adapter = new SqlDataAdapter();
                    command = new SqlCommand("SELECT duration, age FROM Movie WHERE Id = @mo", connect);
                    command.Parameters.AddWithValue("@mo", SqlDbType.Int).Value = moviebox.SelectedIndex + 1;
                    adapter.SelectCommand = command;
                    adapter.Fill(table);
                    moviedata.DataSource = table;

                    adapter3 = new SqlDataAdapter("SELECT Date FROM Session Where Film = 2", connect);
                    DataTable session_table = new DataTable();
                    adapter3.Fill(session_table);
                    foreach (DataRow row in session_table.Rows)
                    {
                        sessionbox.Items.Add(row["Date"]);
                    }
                }
                else if (moviebox.SelectedIndex == 2)
                {
                    sessionbox.Items.Clear();
                    DataTable table = new DataTable();
                    adapter = new SqlDataAdapter();
                    command = new SqlCommand("SELECT duration, age FROM Movie WHERE Id = @mo", connect);
                    command.Parameters.AddWithValue("@mo", SqlDbType.Int).Value = moviebox.SelectedIndex + 1;
                    adapter.SelectCommand = command;
                    adapter.Fill(table);
                    moviedata.DataSource = table;

                    adapter3 = new SqlDataAdapter("SELECT Date FROM Session Where Film = 3", connect);
                    DataTable session_table = new DataTable();
                    adapter3.Fill(session_table);
                    foreach (DataRow row in session_table.Rows)
                    {
                        sessionbox.Items.Add(row["Date"]);
                    }
                }
                /*command = new SqlCommand("SELECT * FROM opilane WHERE GruppId = @grupp", connect);
                connect.Open();
                command.Parameters.AddWithValue("@grupp", comboBox1.SelectedIndex + 1);
                command.ExecuteNonQuery();
                connect.Close();*/
                //DataTable table = new DataTable();
                //adapter = new SqlDataAdapter();
                //command = new SqlCommand("SELECT duration, age FROM Movie WHERE Id = @mo", connect);
                //command.Parameters.AddWithValue("@mo", SqlDbType.Int).Value = moviebox.SelectedIndex + 1;
                //adapter.SelectCommand = command;
                //adapter.Fill(table);
                //moviedata.DataSource = table;
            }
        }

        /*private void Btn3_Click(object sender, EventArgs e)
        {
            Bigg bigg = new Bigg();
            bigg.Show();
        }*/

        private void Form1_Load(object sender, EventArgs e)
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
        
        /*private void Btn2_Click(object sender, EventArgs e)
        {
            Mediumm mediumm = new Mediumm();
            mediumm.Show();
        }*/

        /*private void Btn1_Click(object sender, EventArgs e)
        {
            Smalll small = new Smalll();
            small.Show();
        }*/
        private void DisplayData()
        {
            connect.Open();
            //DataTable table = new DataTable();
            //adapter = new SqlDataAdapter("SELECT * FROM Movie", connect);
            //adapter.Fill(table);
            //moviedata.DataSource = table;

            adapter2 = new SqlDataAdapter("SELECT name FROM Movie", connect);
            DataTable movie_table = new DataTable();
            adapter2.Fill(movie_table);
            foreach (DataRow row in movie_table.Rows)
            {
                moviebox.Items.Add(row["name"]);
            }
            connect.Close();
        }
        /*private void ClearCombo()
        {
            sessionbox.Items.Clear();
        }*/

    }
}
