
using System;
using System.Drawing;



namespace Lab5
{
    class CubeShape : RectShape
    {
        private const int offset = 30;

        public override void Show(Graphics graph, Pen pen)
        {
            RectShape rect1 = new RectShape();
            RectShape rect2 = new RectShape();

            rect1.Set(xs1, ys1, xs2, ys2);
            rect2.Set(xs1 + offset, ys1 - offset, xs2, ys2);

            rect2.Show(graph, pen);

            DrawConnectingLines(graph, pen, new Rectangle((int)xs1, (int)ys1, (int)xs2, (int)ys2),
                                       new Rectangle((int)xs1 + offset, (int)ys1 - offset, (int)xs2, (int)ys2));
            rect1.Show(graph, pen);
        }

        private void DrawConnectingLines(Graphics graph, Pen pen, Rectangle rect1, Rectangle rect2)
        {
            LineShape mainline = new LineShape();

            mainline.Set(rect1.Left, rect1.Top, rect2.Left, rect2.Top);
            mainline.Show(graph, pen);

            mainline.Set(rect1.Right, rect1.Top, rect2.Right, rect2.Top);
            mainline.Show(graph, pen);

            mainline.Set(rect1.Left, rect1.Bottom, rect2.Left, rect2.Bottom);
            mainline.Show(graph, pen);

            mainline.Set(rect1.Right, rect1.Bottom, rect2.Right, rect2.Bottom);
            mainline.Show(graph, pen);
        }
    }
}