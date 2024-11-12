

using System;
using System.Collections.Generic;
using System.Drawing;



namespace Lab5
{
    abstract class Shape
    {
        protected long xs1, ys1, xs2, ys2;

        public long GetX1 { get {return xs1;} }
        public long GetY1 { get {return ys1;} }
        public long GetX2 { get {return xs2;} }
        public long GetY2 { get {return ys2;} }



        public void Set(long x1, long y1, long x2, long y2)
        {
            xs1 = x1;
            ys1 = y1;
            xs2 = x2;
            ys2 = y2;
        }

        public abstract void Show(Graphics graph, Pen pen);
    }
}
