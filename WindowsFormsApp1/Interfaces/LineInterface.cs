using System;
using System.Drawing;


namespace Lab5
{
    public interface ILineDraw
    {
        void DrawLine(Graphics g, Pen pen, bool isSolid);
        void SetLine(long x1, long y1, long x2, long y2);
    }
}

