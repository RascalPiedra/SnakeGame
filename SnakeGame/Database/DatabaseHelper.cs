using System.Data.SQLite;

namespace SnakeGame.Database
{
    public class DatabaseHelper
    {
        private string baglantiBilgi = "Data Source=snake.db;Version=3;";

        public SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(baglantiBilgi);
        }

        public void CreateTable()
        {
            using (SQLiteConnection baglanti = GetConnection())
            {
                baglanti.Open();

                string komut =
                    @"CREATE TABLE IF NOT EXISTS Scores(
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Username TEXT,
                        Score INTEGER,
                        Date TEXT
                    )";

                SQLiteCommand cmd = new SQLiteCommand(komut, baglanti);

                cmd.ExecuteNonQuery();
            }
        }
    }
}