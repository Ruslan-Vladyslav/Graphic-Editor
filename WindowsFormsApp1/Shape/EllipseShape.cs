

using System;
using System.Collections.Generic;
using System.Drawing;


namespace Lab5
{
    class EllipseShape : Shape
    {
        public override void Show(Graphics graph, Pen pen)
        {
            if (pen.Color == Color.Black)
            {
                using (Brush brush = new SolidBrush(Color.FromArgb(192, 192, 192)))
                {
                    graph.FillEllipse(brush, xs1, ys1, xs2, ys2);
                }
            }

            graph.DrawEllipse(pen, xs1, ys1, xs2, ys2);
        }
    }
}
