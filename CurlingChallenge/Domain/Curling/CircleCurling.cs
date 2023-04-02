using CurlingChallenge.Domain.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurlingChallenge.Domain.Curling
{
    public class CircleCurling : Curling<Circle>
    {
        public override string DisplayLabel => "Circle";
        protected override Circle CreateShape(double size, double x, double y) => new Circle(size, x, y);
        protected override double DefaultPosition(int size) => size;
    }
}
