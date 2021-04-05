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
        SqlConnection connect = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\karim\Source\Repos\Kinoo\Kinozal\AppData\Database1.mdf; Integrated Security = True");
        SqlCommand command;

        SqlDataAdapter adapter, adapter2, adapter3;
        int Id = 0;

        /*Button btn1, btn2, btn3;*/
        Label movielbl, sessionlbl, placelbl, infalbl;
        public ComboBox moviebox, sessionbox, roombox;
        DataGridView moviedata;
        PictureBox picturebox1;
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

            picturebox1 = new PictureBox
            {
                Location = new Point(450, 30),
                Size = new Size(450, 450),
                SizeMode = PictureBoxSizeMode.Zoom
            };
            this.Controls.Add(picturebox1);

            infalbl = new Label
            {
                Text = "",
                Location = new Point(900, 135),
                Height = 450,
                Width = 450
            };
            infalbl.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
            this.Controls.Add(infalbl);

            moviedata = new DataGridView
            {
                Location = new Point(11, 135),
                Height = 85,
                Width = 325
            };
            this.Controls.Add(moviedata);

            movielbl = new Label
            {
                Text = "Фильм",
                Location = new Point(11, 30),
                Width = 94
            };
            movielbl.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
            this.Controls.Add(movielbl);

            sessionlbl = new Label
            {
                Text = "Сессия",
                Location = new Point(11, 60),
                Width = 98
            };
            sessionlbl.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
            this.Controls.Add(sessionlbl);

            placelbl = new Label
            {
                Text = "Зал",
                Location = new Point(11, 90),
                Width = 91
            };
            placelbl.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
            this.Controls.Add(placelbl);

            moviebox = new ComboBox
            {
                Location = new Point(110, 30),
                Width = 220
            };
            this.Controls.Add(moviebox);
            this.moviebox.SelectedIndexChanged += Moviebox_SelectedIndexChanged;

            roombox = new ComboBox
            {
                Location = new Point(110, 90),
                Width = 220
            };
            roombox.Items.Add("Маленький");
            roombox.Items.Add("Средний");
            roombox.Items.Add("Большой");

            this.Controls.Add(roombox);
            this.roombox.SelectedIndexChanged += Roombox_SelectedIndexChanged;

            sessionbox = new ComboBox
            {
                Location = new Point(110, 60),
                Width = 220
            };
            this.Controls.Add(sessionbox);
            this.sessionbox.SelectedIndexChanged += Sessionbox_SelectedIndexChanged;

            DisplayData();
            InitializeComponent();
            //this.Height = 191;
            //this.Width = 367;
            this.Height = 450;
            this.Width = 1050;
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
                DateTime sesio = DateTime.Parse(sessionbox.SelectedItem.ToString());
                int mo = moviebox.SelectedIndex;
                int ol = roombox.SelectedIndex;
                Smalll small = new Smalll(ol, mo, sesio);
                small.Show();
            }
            else if (roombox.SelectedIndex == 1)
            {
                DateTime sesio = DateTime.Parse(sessionbox.SelectedItem.ToString());
                int mo = moviebox.SelectedIndex;
                int ol = roombox.SelectedIndex;
                Mediumm mediumm = new Mediumm(ol, mo, sesio);
                mediumm.Show();
            }
            else if (roombox.SelectedIndex == 2)
            {
                DateTime sesio = DateTime.Parse(sessionbox.SelectedItem.ToString());
                int mo = moviebox.SelectedIndex;
                int ol = roombox.SelectedIndex;
                Bigg bigg = new Bigg(ol, mo, sesio);
                bigg.Show();
            }
        }

        private void Sessionbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (moviebox.SelectedIndex == 0)
            {
                DataTable table = new DataTable();
                adapter3 = new SqlDataAdapter();
                command = new SqlCommand("SELECT Date FROM Session WHERE Id = @moo", connect);
                command.Parameters.AddWithValue("@moo", SqlDbType.Int).Value = sessionbox.SelectedIndex + 1;
                adapter3.SelectCommand = command;
                adapter3.Fill(table);
                moviedata.DataSource = table;
            }
            if (moviebox.SelectedIndex == 1)
            {
                DataTable table = new DataTable();
                adapter3 = new SqlDataAdapter();
                command = new SqlCommand("SELECT Date FROM Session WHERE Id = @moo", connect);
                command.Parameters.AddWithValue("@moo", SqlDbType.Int).Value = sessionbox.SelectedIndex + 4;
                adapter3.SelectCommand = command;
                adapter3.Fill(table);
                moviedata.DataSource = table;
            }
            if (moviebox.SelectedIndex == 2)
            {
                DataTable table = new DataTable();
                adapter3 = new SqlDataAdapter();
                command = new SqlCommand("SELECT Date FROM Session WHERE Id = @moo", connect);
                command.Parameters.AddWithValue("@moo", SqlDbType.Int).Value = sessionbox.SelectedIndex + 7;
                adapter3.SelectCommand = command;
                adapter3.Fill(table);
                moviedata.DataSource = table;
            }
            if (moviebox.SelectedIndex == 3)
            {
                DataTable table = new DataTable();
                adapter3 = new SqlDataAdapter();
                command = new SqlCommand("SELECT Date FROM Session WHERE Id = @moo", connect);
                command.Parameters.AddWithValue("@moo", SqlDbType.Int).Value = sessionbox.SelectedIndex + 10;
                adapter3.SelectCommand = command;
                adapter3.Fill(table);
                moviedata.DataSource = table;
            }
            if (moviebox.SelectedIndex == 4)
            {
                DataTable table = new DataTable();
                adapter3 = new SqlDataAdapter();
                command = new SqlCommand("SELECT Date FROM Session WHERE Id = @moo", connect);
                command.Parameters.AddWithValue("@moo", SqlDbType.Int).Value = sessionbox.SelectedIndex + 13;
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
                    infalbl.Text = "Жизнь десятилетнего Гарри Поттера нельзя назвать сладкой: его родители умерли, едва ему исполнился год, а от дяди и тётки, взявших сироту на воспитание, достаются лишь тычки да подзатыльники. " +
                        "Но в одиннадцатый день рождения Гарри всё меняется.";
                    picturebox1.Image = new Bitmap("harry.jpg");

                    //infalbl.Text = "Babl";

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
                    infalbl.Text = "Уэйд Уилсон — наёмник. Будучи побочным продуктом программы вооружённых сил под названием «Оружие X», Уилсон приобрёл невероятную силу, проворство и способность к исцелению. " +
                        "Но страшной ценой: его клеточная структура постоянно меняется, а здравомыслие сомнительно. " +
                        "Всё, чего Уилсон хочет, — это держаться на плаву в социальной выгребной яме. Но течение в ней слишком быстрое.";

                    picturebox1.Image = new Bitmap("dead.png");

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
                    infalbl.Text = "Тандзиро с друзьями из отряда уничтожителей демонов расследует серию загадочных исчезновений внутри мчащегося поезда. " +
                        "Но компания ещё не знает, что в составе находится один из двенадцати Лунных демонов, и он приготовил для них ловушку.";

                    picturebox1.Image = new Bitmap("kime.jpg");

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
                else if (moviebox.SelectedIndex == 3)
                {
                    infalbl.Text = "Когда в городке Дерри, штат Мэн, начинают пропадать дети, несколько ребят сталкиваются со своими величайшими страхами и вынуждены помериться силами со злобным клоуном Пеннивайзом, чьи проявления жестокости и список жертв уходят в глубь веков.";

                    picturebox1.Image = new Bitmap("it.jpg");

                    sessionbox.Items.Clear();
                    DataTable table = new DataTable();
                    adapter = new SqlDataAdapter();
                    command = new SqlCommand("SELECT duration, age FROM Movie WHERE Id = @mo", connect);
                    command.Parameters.AddWithValue("@mo", SqlDbType.Int).Value = moviebox.SelectedIndex + 1;
                    adapter.SelectCommand = command;
                    adapter.Fill(table);
                    moviedata.DataSource = table;

                    adapter3 = new SqlDataAdapter("SELECT Date FROM Session Where Film = 4", connect);
                    DataTable session_table = new DataTable();
                    adapter3.Fill(session_table);
                    foreach (DataRow row in session_table.Rows)
                    {
                        sessionbox.Items.Add(row["Date"]);
                    }
                }
                else if (moviebox.SelectedIndex == 4)
                {
                    infalbl.Text = "После исторической встречи с командой Мстителей Питер Паркер возвращается домой, стараясь зажить обычной жизнью под опекой своей тети Мэй. " +
                        "Но теперь за Питером приглядывает еще кое-что… Тони Старк видел Человека-Паука в деле и должен стать его наставником. " +
                        "Когда новый злодей Стервятник угрожает уничтожить все, что дорого Питеру, приходит время доказать всем, что такое настоящий супергерой.";

                    picturebox1.Image = new Bitmap("spider.jpg");

                    sessionbox.Items.Clear();
                    DataTable table = new DataTable();
                    adapter = new SqlDataAdapter();
                    command = new SqlCommand("SELECT duration, age FROM Movie WHERE Id = @mo", connect);
                    command.Parameters.AddWithValue("@mo", SqlDbType.Int).Value = moviebox.SelectedIndex + 1;
                    adapter.SelectCommand = command;
                    adapter.Fill(table);
                    moviedata.DataSource = table;

                    adapter3 = new SqlDataAdapter("SELECT Date FROM Session Where Film = 5", connect);
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
