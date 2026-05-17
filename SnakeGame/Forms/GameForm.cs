using Microsoft.VisualBasic;
using SnakeGame.Models;
using SnakeGame.Services;

using System;
using System.Drawing;
using System.Windows.Forms;

namespace SnakeGame.Forms
{
    public partial class GameForm : Form //Ceren
    {
        Snake snake = new Snake();

        Food food = new Food();

        Point foodCords;

        int dx = 1;
        int dy = 0;

        int score = 0;

        Timer sure = new Timer();

        public GameForm()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;

            this.Width = 420;
            this.Height = 440;

            this.BackColor = Color.Black;

            this.DoubleBuffered = true;

            foodCords = food.Spawn();

            sure.Interval = 100;

            sure.Tick += UpdateGame;

            sure.Start();

            this.KeyDown += GameForm_KeyDown;
        }

        private void UpdateGame(object sender, EventArgs e)
        {
            snake.Move(dx, dy);

            if (snake.Govde[0] == foodCords)
            {
                snake.Grow();

                foodCords = food.Spawn();

                score += 10;
            }

            if (snake.Govde[0].X < 0 ||
                snake.Govde[0].Y < 0 ||
                snake.Govde[0].X >= 20 ||
                snake.Govde[0].Y >= 20)
            {
                sure.Stop();

                SaveScore();

                MessageBox.Show("Oyun Bitti\nSkor: " + score);

                this.Close();
            }

            Invalidate();
        }

        private void SaveScore()       //Özgür
        {
            string username = Interaction.InputBox(
                    "Kullanıcı Adı Gir",
                    "Skoru Kaydet",
                    "Oyuncu");

            ScoreService service = new ScoreService();

            service.AddScore(new Score
            {
                Username = username,

                PlayerScore = score,

                Date = DateTime.Now.ToString()
            });
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            foreach (Point p in snake.Govde)
            {
                g.FillRectangle(Brushes.LimeGreen, p.X * 20, p.Y * 20, 18, 18);
            }

            g.FillEllipse(Brushes.Red, foodCords.X * 20, foodCords.Y * 20, 18, 18);

            g.DrawString("Skor: " + score, new Font("Arial", 16), Brushes.White, 10, 10);
        }

        public Keys lastkey;
        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.W || e.KeyCode == Keys.Up) && lastkey != Keys.Down)
            {
                lastkey = Keys.Up;
                dx = 0;
                dy = -1;
            }

            if ((e.KeyCode == Keys.S || e.KeyCode == Keys.Down) && lastkey != Keys.Up)
            {
                lastkey = Keys.Down;
                dx = 0;
                dy = 1;
            }

            if ((e.KeyCode == Keys.A || e.KeyCode == Keys.Left) && lastkey != Keys.Right)
            {
                lastkey = Keys.Left;
                dx = -1;
                dy = 0;
            }

            if ((e.KeyCode == Keys.D || e.KeyCode == Keys.Right) && lastkey != Keys.Left)
            {
                lastkey = Keys.Right;
                dx = 1;
                dy = 0;
            }
        }
    }
}