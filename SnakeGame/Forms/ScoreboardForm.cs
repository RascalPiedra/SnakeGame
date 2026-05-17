using SnakeGame.Models;
using SnakeGame.Services;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SnakeGame.Forms
{
    public partial class ScoreboardForm : Form
    {
        ScoreService service = new ScoreService();

        List<Score> currentScores;

        Label lblTitle;
        Label lblColumns;

        public ScoreboardForm()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;

            TasarimiUygula();

            LoadScores();
        }

        private void TasarimiUygula()
        {
            this.Text = "Skor Tablosu";

            this.BackColor = Color.Black;

            this.ClientSize = new Size(900, 550);

            lblTitle = new Label();

            lblTitle.Text = "SKOR TABLOSU";

            lblTitle.Font = new Font("Arial", 26, FontStyle.Bold);

            lblTitle.ForeColor = Color.Lime;

            lblTitle.AutoSize = true;
            
            lblTitle.Location = new Point(250, 40);

            this.Controls.Add(lblTitle);

            lblColumns = new Label();

            lblColumns.Text =
                "ID  |  KULLANICI ADI  |  SKOR  |  TARİH";

            lblColumns.Font =
                new Font("Consolas", 12, FontStyle.Bold);

            lblColumns.ForeColor = Color.White;

            lblColumns.AutoSize = true;

            lblColumns.Location = new Point(90, 120);

            this.Controls.Add(lblColumns);

            listBoxScores.Location = new Point(90, 160);

            listBoxScores.Size = new Size(700, 250);

            listBoxScores.BackColor = Color.FromArgb(15, 15, 15);

            listBoxScores.ForeColor = Color.Lime;

            listBoxScores.BorderStyle = BorderStyle.FixedSingle;

            listBoxScores.Font =
                new Font("Consolas", 12, FontStyle.Bold);

            btnDelete.Text = "Skoru Sil";

            btnDelete.Size = new Size(180, 45);

            btnDelete.Location = new Point(310, 450);

            btnDelete.BackColor = Color.DarkRed;

            btnDelete.ForeColor = Color.White;

            btnDelete.FlatStyle = FlatStyle.Flat;

            btnDelete.Font =
                new Font("Arial", 11, FontStyle.Bold);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;

            Pen kalem =
                new Pen(Color.FromArgb(25, 0, 255, 0));

            for (int x = 0; x < this.Width; x += 40)
            {
                g.DrawLine(kalem, x, 0, x, this.Height);
            }

            for (int y = 0; y < this.Height; y += 40)
            {
                g.DrawLine(kalem, 0, y, this.Width, y);
            }
        }

        private void LoadScores()
        {
            listBoxScores.Items.Clear();

            currentScores = service.GetScores();

            foreach (Score s in currentScores)
            {
                listBoxScores.Items.Add(
                    s.Id + " | " +
                    s.Username + " | " +
                    s.PlayerScore + " | " +
                    s.Date);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listBoxScores.SelectedIndex == -1)
                return;

            int index = listBoxScores.SelectedIndex;

            int id = currentScores[index].Id;

            service.DeleteScore(id);

            LoadScores();
        }

        private void listBoxScores_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}