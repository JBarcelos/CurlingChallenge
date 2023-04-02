using IShape = CurlingChallenge.Domain.Shapes.IShape;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.Versioning;

namespace CurlingChallenge.Domain.Curling
{
    public abstract class Curling<TShape> : ICurling
        where TShape : IShape
    {
        public const int MIN_POSITION = 1;
        public const int MAX_POSITION = 1000;

        public IEnumerable<IShape> Shapes { get; private set; }

        public Curling()
        {
            Shapes = Enumerable.Empty<IShape>();
        }

        public abstract string DisplayLabel { get; }
        protected abstract double DefaultPosition(int size);
        protected abstract TShape CreateShape(double size, double x, double y);

        public void Simulate(int size, params int[] positions)
        {
            var shapes = new List<TShape>();

            foreach (var x in positions)
            {
                var intersects = shapes.Where(shape => shape.Intersects(x));
                var highest = intersects.Any() ? intersects.Max(shape => shape.GetIntersectHeight(x)) : DefaultPosition(size);
                shapes.Add(CreateShape(size, x, highest));
            }

            Shapes = shapes.AsEnumerable().Cast<IShape>();
        }

        public void Simulate(int size, int number)
        {
            var rng = new Random();
            Simulate(size, Enumerable.Range(0, number).Select(_ => rng.Next(MIN_POSITION, MAX_POSITION)).ToArray());
        }
    }
}
