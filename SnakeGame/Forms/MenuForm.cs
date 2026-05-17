using System;
using System.Drawing;
using System.Windows.Forms;

namespace SnakeGame.Forms
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();

            this.Text = "Yılan Oyunu";
            this.BackColor = Color.Black;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.ClientSize = new Size(800, 500);

            BaslikOlustur();
            ButonlariDuzenle();
        }

        private void BaslikOlustur()
        {
            Label baslik = new Label();

            baslik.Text = "YILAN OYUNU";
            baslik.Font = new Font("Arial", 28, FontStyle.Bold);

            baslik.ForeColor = Color.Lime;

            baslik.AutoSize = true;

            baslik.Location = new Point(260, 70);

            this.Controls.Add(baslik);
        }

        private void ButonlariDuzenle()
        {
            ButonAyarla(btnStart, 180);
            ButonAyarla(btnScores, 260);
            ButonAyarla(btnExit, 340);

            btnStart.Text = "Oyuna Başla";
            btnScores.Text = "Skor Tablosu";
            btnExit.Text = "Çıkış";
        }

        private void ButonAyarla(Button btn, int y)
        {
            btn.Size = new Size(250, 50);

            btn.Location = new Point(275, y);

            btn.BackColor = Color.DarkGreen;
            btn.ForeColor = Color.White;

            btn.FlatStyle = FlatStyle.Flat;

            btn.Font = new Font("Arial", 12, FontStyle.Bold);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;

            Pen kalem = new Pen(Color.FromArgb(30, 0, 255, 0));

            for (int x = 0; x < this.Width; x += 40)
            {
                g.DrawLine(kalem, x, 0, x, this.Height);
            }

            for (int y = 0; y < this.Height; y += 40)
            {
                g.DrawLine(kalem, 0, y, this.Width, y);
            }
        }



        private void btnStart_Click(object sender, EventArgs e)
        {
            GameForm oyun = new GameForm();

            oyun.Show();
        }

        private void btnScores_Click(object sender, EventArgs e)
        {
            ScoreboardForm skorlar = new ScoreboardForm();

            skorlar.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}