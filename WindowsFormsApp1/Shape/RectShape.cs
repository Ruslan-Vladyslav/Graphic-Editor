

using System;
using System.Collections.Generic;
using System.Drawing;


namespace Lab5
{
    class RectShape : Shape
    {
        public override void Show(Graphics graph, Pen pen)
        {
            if (pen.Color == Color.Black)
            {
                using (Brush brush = new SolidBrush(Color.FromArgb(255, 255, 40)))
                {
                    graph.FillRectangle(brush, xs1, ys1, xs2, ys2);
                }
            }

            graph.DrawRectangle(pen, xs1, ys1, xs2, ys2);
        }
    }
}
