using Microsoft.Maui.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurlingChallenge.Domain.Shapes
{
    public class Triangle : Shape
    {
        public Triangle(double size, double x, double y) : base(size, x, y)
        {
        }

        public override Rect Rect
        {
            get
            {
                var half = Size / 2;
                var sqrt3 = Math.Sqrt(3);
                var triangleHeight = Size * sqrt3 / 2;
                var baseY = Y - Size / (2 * sqrt3);

                return new Rect(X - half, baseY, Size, triangleHeight);
            }
        }

        public override void Draw(ICanvas canvas, RectF dirtyRect)
        {
            var half = Size / 2;
            var sqrt3 = Math.Sqrt(3);
            var baseY = (float)(Y - Size / (2 * sqrt3));
            var apexY = (float)(Y + Size / sqrt3);

            canvas.DrawLine((float)(X - half), baseY, (float)(X + half), baseY);
            canvas.DrawLine((float)(X - half), baseY, (float)X, apexY);
            canvas.DrawLine((float)(X + half), baseY, (float)X, apexY);
        }

        public override double GetIntersectHeight(double position)
        {
            var dx = Math.Abs(position - X);
            var sqrt3 = Math.Sqrt(3);
            var centroidHeight = Size / (2 * sqrt3);

            if(dx <= Size / 2)
            {
                var triangleHeight = Size * sqrt3 / 2;
                return Y + triangleHeight;
            }
            else if(dx > Size / 2 && dx <= Size)
            {
                var dy = sqrt3 * (Size - dx);
                return Y + dy;
            }

            return centroidHeight;
        }

        public override bool Intersects(double position) => Math.Abs(position - X) <= Size;
    }
}
