using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurlingChallenge.Domain.Curling
{
    public class CurlingRenderer : IDrawable
    {
        public ICurling Curling { get; set; }

        public CurlingRenderer(ICurling curling)
        {
            Curling = curling;
        }

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            PreDraw(canvas, dirtyRect);

            if (Curling == null || !Curling.Shapes.Any())
                return;

            foreach (var shape in Curling.Shapes)
            {
                shape.Draw(canvas, dirtyRect);
            }
        }

        protected virtual void PreDraw(ICanvas canvas, RectF dirtyRect)
        {
            canvas.ResetState();

            var resources = Application.Current.Resources.MergedDictionaries.First();

            canvas.FillColor = (Color)resources["Gray300"];
            canvas.FillRectangle(dirtyRect);

            if (Curling == null || !Curling.Shapes.Any())
                return;

            //scale to fit image in output box and maintain aspect ratio
            var rects = Curling.Shapes.Select(shape => shape.Rect);
            var minX = rects.Min(r => r.X);
            var width = rects.Max(r => r.Right) - minX;
            var height = rects.Max(r => r.Bottom) - rects.Min(r => r.Y);

            var scale = Math.Min(dirtyRect.Height / height, dirtyRect.Width / width);

            canvas.StrokeSize = 1 / (float)scale;
            canvas.Scale((float)scale, (float)-scale);
            canvas.Translate((float)-minX, -dirtyRect.Height / (float)scale);
        }
    }
}
