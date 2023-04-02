using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurlingChallenge.Domain.Shapes
{
    public abstract class Shape : IShape
    {
        public double Size { get; }
        public double X { get; }
        public double Y { get; }
        public abstract Rect Rect { get; }

        public Shape(double size, double x, double y)
        {
            Size = size;
            X = x;
            Y = y;
        }

        public abstract void Draw(ICanvas canvas, RectF dirtyRect);
        public abstract bool Intersects(double position);
        public abstract double GetIntersectHeight(double position);
    }
}
