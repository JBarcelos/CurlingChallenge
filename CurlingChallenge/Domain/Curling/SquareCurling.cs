using CurlingChallenge.Domain.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurlingChallenge.Domain.Curling
{
    public class SquareCurling : Curling<Square>
    {
        public override string DisplayLabel => "Square";
        protected override Square CreateShape(double size, double x, double y) => new Square(size, x, y);
        protected override double DefaultPosition(int size) => (double)size / 2;
    }
}
