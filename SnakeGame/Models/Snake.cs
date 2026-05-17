using System.Collections.Generic;
using System.Drawing;

namespace SnakeGame.Models
{
    public class Snake : GameObject
    {
        public List<Point> Govde { get; set; }

        public Snake()
        {
            Govde = new List<Point>();

            Govde.Add(new Point(10, 10));
        }

        public void Move(int dx, int dy)
        {
            for (int i = Govde.Count - 1; i > 0; i--)
            {
                Govde[i] = Govde[i - 1];
            }

            Govde[0] = new Point(
                Govde[0].X + dx,
                Govde[0].Y + dy);
        }

        public void Grow()
        {
            Govde.Add(Govde[Govde.Count - 1]);
        }
    }
}