using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurlingChallenge.Domain.Shapes
{
    public class Square : Shape
    {
        public Square(double size, double x, double y) : base(size, x, y)
        {
        }

        public override Rect Rect => new Rect(X - Size / 2, Y - Size / 2, Size, Size);

        public override void Draw(ICanvas canvas, RectF dirtyRect) => canvas.DrawRectangle(Rect);

        public override double GetIntersectHeight(double position) => Y + Size;

        public override bool Intersects(double position) => Math.Abs(position - X) <= Size;
    }
}
