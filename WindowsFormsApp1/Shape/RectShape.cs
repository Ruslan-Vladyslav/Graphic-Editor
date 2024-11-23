

using System;
using System.Collections.Generic;
using System.Drawing;


namespace Lab5
{
    public class RectShape : Shape
    {
        private long x1, y1, x2, y2;

        public override long GetX1 => x1;
        public override long GetY1 => y1;
        public override long GetX2 => x2;
        public override long GetY2 => y2;

        public override void Set(long x1, long y1, long x2, long y2)
        {
            this.x1 = Math.Min(x1, x2);
            this.y1 = Math.Min(y1, y2);
            this.x2 = Math.Max(x1, x2);
            this.y2 = Math.Max(y1, y2);
        }

        public override void Show(Graphics g, Pen pen, bool isSolid)
        {
            if (isSolid)
            {
                using (Brush grayBrush = new SolidBrush(Color.LightGray))
                {
                    g.FillRectangle(grayBrush, (int)x1, (int)y1, (int)(x2 - x1), (int)(y2 - y1));
                }
            }

            g.DrawRectangle(pen, (int)x1, (int)y1, (int)(x2 - x1), (int)(y2 - y1));
            
        }
    }
}
