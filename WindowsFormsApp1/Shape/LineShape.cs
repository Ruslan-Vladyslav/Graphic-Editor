

using System;
using System.Collections.Generic;
using System.Drawing;


namespace Lab5
{
    public class LineShape : Shape, ILineDraw
    {
        private long x1, y1, x2, y2;

        public override long GetX1 => x1;
        public override long GetY1 => y1;
        public override long GetX2 => x2;
        public override long GetY2 => y2;

        public override void Set(long x1, long y1, long x2, long y2)
        {
            SetLine(x1, y1, x2, y2);
        }

        public override void Show(Graphics g, Pen pen, bool isSolid)
        {
            DrawLine(g, pen, isSolid);
        }

        public void DrawLine(Graphics g, Pen pen, bool isSolid)
        {
            g.DrawLine(pen, (int)x1, (int)y1, (int)x2, (int)y2);
        }

        public void SetLine(long x1, long y1, long x2, long y2)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
        }
    }
}
