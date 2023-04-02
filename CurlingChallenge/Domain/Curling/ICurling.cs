using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IShape = CurlingChallenge.Domain.Shapes.IShape;

namespace CurlingChallenge.Domain.Curling
{
    public interface ICurling
    {
        string DisplayLabel { get; }
        IEnumerable<IShape> Shapes { get; }
        void Simulate(int size, params int[] positions);
        void Simulate(int size, int number);
    }
}
