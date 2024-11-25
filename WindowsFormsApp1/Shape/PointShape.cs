

using System;
using System.Collections.Generic;
using System.Drawing;


namespace Lab5
{
    public class PointShape : Shape
    {
        private long x, y;

        public override long GetX1 => x;
        public override long GetY1 => y;
        public override long GetX2 => 0;
        public override long GetY2 => 0;

        public override void Set(long x1, long y1, long x2, long y2)
        {
            x = x1;
            y = y1;
        }

        public override void Show(Graphics g, Pen pen, bool isSolid)
        {
            const int radius = 2;

            if (pen.Color == Color.Black)
            {
                using (Brush brush = new SolidBrush(Color.Black))
                {
                    g.FillEllipse(brush, (int)x - radius, (int)y - radius, 2 * radius, 2 * radius);
                }
            } else
            {
                using (Brush brush = new SolidBrush(Color.Red))
                {
                    g.FillEllipse(brush, (int)x - radius, (int)y - radius, 2 * radius, 2 * radius);
                }
            }
        }
    }

}
