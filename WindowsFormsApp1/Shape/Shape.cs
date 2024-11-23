

using System;
using System.Collections.Generic;
using System.Drawing;



namespace Lab5
{
    public abstract class Shape
    {
        public abstract long GetX1 { get; }
        public abstract long GetY1 { get; }
        public abstract long GetX2 { get; }
        public abstract long GetY2 { get; }


        public abstract void Set(long x1, long y1, long x2, long y2);
        public abstract void Show(Graphics g, Pen pen, bool isSolid);
    }
}
