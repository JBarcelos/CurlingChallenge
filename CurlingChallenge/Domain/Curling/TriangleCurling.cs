using CurlingChallenge.Domain.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurlingChallenge.Domain.Curling
{
    public class TriangleCurling : Curling<Triangle>
    {
        public override string DisplayLabel => "Triangle";
        protected override Triangle CreateShape(double size, double x, double y) => new Triangle(size, x, y);
        protected override double DefaultPosition(int size) => size / (2 * Math.Sqrt(3));
    }
}
