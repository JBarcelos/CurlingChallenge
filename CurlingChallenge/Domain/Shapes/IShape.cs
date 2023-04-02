using Microsoft.Maui.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurlingChallenge.Domain.Shapes
{
    public interface IShape : IDrawable
    {
        double Size { get; }
        double X { get; }
        double Y { get; }
        Rect Rect { get; }
        bool Intersects(double position);
        double GetIntersectHeight(double position);
    }
}
