using System;
using System.Drawing;


namespace Lab5
{
    public interface IEllipseDraw
    {
        void DrawEllipse(Graphics g, Pen pen, bool isSolid);
        void SetEllipse(long x1, long y1, long x2, long y2);
    }
}
