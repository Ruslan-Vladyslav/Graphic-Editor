
using Lab5;
using System;
using System.Collections.Generic;
using System.Drawing;



namespace Lab5
{
    class LineOOShape : LineShape, IEllipseDraw
    {
        private const int radius = 7;
        private IEllipseDraw obj = new EllipseShape();


        public override void Show(Graphics graph, Pen pen, bool isSolid)
        {
            base.Show(graph, pen, isSolid);

            SetEllipse(GetX1 - radius, GetY1 - radius, GetX1 + radius, GetY1 + radius);
            DrawEllipse(graph, pen, isSolid);

            SetEllipse(GetX2 - radius, GetY2 - radius, GetX2 + radius, GetY2 + radius);
            DrawEllipse(graph, pen, isSolid);
        }

        public void DrawEllipse(Graphics g, Pen pen, bool isSolid)
        {
            obj.DrawEllipse(g, pen, isSolid);
        }

        public void SetEllipse(long x1, long y1, long x2, long y2)
        {
            obj.SetEllipse(x1, y1, x2, y2);
        }
    }
}