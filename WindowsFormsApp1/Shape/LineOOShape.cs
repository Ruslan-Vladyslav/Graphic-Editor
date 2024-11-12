
using System;
using System.Collections.Generic;
using System.Drawing;



namespace Lab5
{
    class LineOOShape : LineShape
    {
        private const int radius = 7;

        public override void Show(Graphics graph, Pen pen)
        {
            LineShape mainline = new LineShape();

            mainline.Set(xs1, ys1, xs2, ys2);
            mainline.Show(graph, pen);

            EllipseShape ellipse1 = new EllipseShape();
            EllipseShape ellipse2 = new EllipseShape();

            DrawLineCircle(ellipse1, graph, xs1, ys1, pen);
            DrawLineCircle(ellipse2, graph, xs2, ys2, pen);
        }

        private void DrawLineCircle(EllipseShape shape, Graphics g, long x, long y, Pen pen)
        {
            shape.Show(g, pen);

            using (Brush brush = new SolidBrush(Color.FromArgb(253, 67, 67)))
            {
                g.FillEllipse(brush, x - radius, y - radius, 2 * radius, 2 * radius);
                g.DrawEllipse(Pens.Black, x - radius, y - radius, 2 * radius, 2 * radius);
            }
        }
    }
}