using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab5
{
    class CubeEditor : Editor
    {
        private bool isDrawing = false;
        private Point center, end_p;

        public CubeEditor(MainEditor editor) : base(editor) { }

        public override void OnLBdown(Form window)
        {
            isDrawing = true;
            center = window.PointToClient(Cursor.Position);
        }

        public override void OnLBup(Form window)
        {
            if (isDrawing)
            {
                end_p = window.PointToClient(Cursor.Position);

                CubeShape cubeShape = new CubeShape();

                Rectangle rect = GetRect(center, end_p);
                cubeShape.Set(rect.X, rect.Y, rect.Width, rect.Height);

                editor.AddObject(cubeShape);

                isDrawing = false;
                window.Invalidate();
            }
        }

        public override void OnMouseMove(Form window)
        {
            if (isDrawing)
            {
                end_p = window.PointToClient(Cursor.Position);
                window.Invalidate();
            }
        }

        public override void OnPaint(Form window, Graphics g)
        {
            if (isDrawing)
            {
                Pen dashPen = new Pen(Color.FromArgb(0, 43, 255));
                float[] pattern = { 5, 7 };

                dashPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                dashPen.DashPattern = pattern;

                Rectangle rect = GetRect(center, end_p);
                g.DrawRectangle(dashPen, rect);

                Rectangle backRect = new Rectangle(rect.X + 30, rect.Y - 30, rect.Width, rect.Height);
                g.DrawRectangle(dashPen, backRect);

                DrawConnectingLines(g, rect, backRect, dashPen);

                dashPen.Dispose();
            }
        }

        private Rectangle GetRect(Point start, Point end)
        {
            return new Rectangle(
                Math.Min(start.X, end.X),
                Math.Min(start.Y, end.Y),
                Math.Abs(start.X - end.X),
                Math.Abs(start.Y - end.Y)
            );
        }

        private void DrawConnectingLines(Graphics g, Rectangle rect1, Rectangle rect2, Pen pen)
        {
            g.DrawLine(pen, rect1.Left, rect1.Top, rect2.Left, rect2.Top);
            g.DrawLine(pen, rect1.Right, rect1.Top, rect2.Right, rect2.Top);
            g.DrawLine(pen, rect1.Left, rect1.Bottom, rect2.Left, rect2.Bottom);
            g.DrawLine(pen, rect1.Right, rect1.Bottom, rect2.Right, rect2.Bottom);
        }
    }
}