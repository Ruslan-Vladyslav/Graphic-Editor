using System;
using System.Drawing;


namespace Lab5
{
    public class CubeShape : RectShape, ILineDraw
    {
        private const int offset = 30;

        private ILineDraw obj = new LineShape();

        public override void Show(Graphics g, Pen pen, bool isSolid)
        {
            long x1 = GetX1 + offset;
            long y1 = GetY1 - offset;
            long x2 = GetX2 + offset;
            long y2 = GetY2 - offset;

            Set(x1, y1, x2, y2);
            base.Show(g, pen, isSolid);

            Set(GetX1 - offset, GetY1 + offset, GetX2 - offset, GetY2 + offset);
            DrawLine(g, pen, (int)GetX1, (int)GetY2, (int)x1, (int)y2);
            base.Show(g, pen, isSolid);

            DrawConnectingLines(g, pen, x1, y1, x2, y2);
        }

        private void DrawConnectingLines(Graphics g, Pen pen, long x1, long y1, long x2, long y2)
        {
            DrawLine(g, pen, (int)GetX1, (int)GetY1, (int)x1, (int)y1); // t l
            DrawLine(g, pen, (int)GetX2, (int)GetY1, (int)x2, (int)y1); // t r
            DrawLine(g, pen, (int)GetX2, (int)GetY2, (int)x2, (int)y2); // d r
        }

        private void DrawLine(Graphics graph, Pen pen, long x1, long y1, long x2, long y2)
        {
            SetLine(x1, y1, x2, y2);
            DrawLine(graph, pen, false); 
        }

        public void DrawLine(Graphics g, Pen pen, bool isSolid)
        {
            obj.DrawLine(g, pen, isSolid);
        }
        public void SetLine(long x1, long y1, long x2, long y2)
        {
            obj.SetLine(x1, y1, x2, y2);
        }
    }
}