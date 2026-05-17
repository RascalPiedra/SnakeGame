using SnakeGame.Database;
using SnakeGame.Forms;

using System;
using System.Windows.Forms;

namespace SnakeGame
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            DatabaseHelper db = new DatabaseHelper();

            db.CreateTable();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new MenuForm());
        }
    }
}