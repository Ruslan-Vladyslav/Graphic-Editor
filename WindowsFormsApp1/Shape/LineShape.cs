

using System;
using System.Collections.Generic;
using System.Drawing;


namespace Lab5
{
    class LineShape : Shape
    {
        public override void Show(Graphics graph, Pen pen)
        {
            graph.DrawLine(pen, xs1, ys1, xs2, ys2);
        }
    }
}
