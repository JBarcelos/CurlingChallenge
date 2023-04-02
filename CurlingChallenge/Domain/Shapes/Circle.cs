using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurlingChallenge.Domain.Shapes
{
    public class Circle : Shape
    {
        public Circle(double size, double x, double y) : base(size, x, y)
        {

        }

        public override Rect Rect => new Rect(X - Size, Y - Size, 2 * Size, 2 * Size);

        public override void Draw(ICanvas canvas, RectF dirtyRect)
        {
            canvas.DrawCircle((float)X, (float)Y, (float)Size);
        }

        public override double GetIntersectHeight(double position)
        {
            var dx = position - X;
            var dy = Math.Sqrt(4 * Size * Size - dx * dx);
            return Y + dy;
        }

        public override bool Intersects(double position) => Math.Abs(position - X) <= 2 * Size;
    }
}
