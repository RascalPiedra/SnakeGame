using System;
using System.Drawing;

namespace SnakeGame.Models
{
    public class Food : GameObject//Ceren
    {
        Random rand = new Random();

        public Point Spawn()
        {
            X = rand.Next(0, 20);

            Y = rand.Next(0, 20);

            return new Point(X, Y);
        }
    }
}