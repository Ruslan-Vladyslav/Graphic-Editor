

using System;
using System.Collections.Generic;
using System.Drawing;


namespace Lab5
{
    class PointShape : Shape
    {
        public override void Show(Graphics graph, Pen pen)
        {
            graph.FillEllipse(Brushes.Black, xs1 - 1, ys1 - 1, 4, 4);
        }
    }

}
