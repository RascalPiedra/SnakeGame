using SnakeGame.Database;
using SnakeGame.Models;

using System.Collections.Generic;
using System.Data.SQLite;

namespace SnakeGame.Services
{
    public class ScoreService
    {
        DatabaseHelper db = new DatabaseHelper();

        public void AddScore(Score score)
        {
            using (SQLiteConnection baglanti = db.GetConnection())
            {
                baglanti.Open();

                string komut =
                    @"INSERT INTO Scores
                    (Username, Score, Date)
                    VALUES
                    (@username, @score, @date)";

                SQLiteCommand cmd = new SQLiteCommand(komut, baglanti);

                score.Username = score.Username == " " || score.Username == "" ? "Bilinmiyor" : score.Username;
                cmd.Parameters.AddWithValue("@username", score.Username);

                cmd.Parameters.AddWithValue("@score", score.PlayerScore);

                cmd.Parameters.AddWithValue("@date", score.Date);

                cmd.ExecuteNonQuery();
            }
        }

        public List<Score> GetScores()
        {
            List<Score> scores = new List<Score>();

            using (SQLiteConnection baglanti = db.GetConnection())
            {
                baglanti.Open();

                string komut = "SELECT * FROM Scores ORDER BY Score DESC";

                SQLiteCommand cmd = new SQLiteCommand(komut, baglanti);

                SQLiteDataReader okuyucu = cmd.ExecuteReader();

                while (okuyucu.Read())
                {
                    scores.Add(new Score
                    {
                        Id = okuyucu.GetInt32(0),

                        Username = okuyucu.GetString(1),

                        PlayerScore = okuyucu.GetInt32(2),

                        Date = okuyucu.GetString(3)
                    });
                }
            }

            return scores;
        }

        public void DeleteScore(int id)
        {
            using (SQLiteConnection baglanti = db.GetConnection())
            {
                baglanti.Open();

                string komut = "DELETE FROM Scores WHERE Id=@id";

                SQLiteCommand cmd = new SQLiteCommand(komut, baglanti);

                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            }
        }
    }
}