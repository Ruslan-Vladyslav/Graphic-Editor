


using System;
using System.Drawing;
using System.Windows.Forms;


namespace Lab5
{
    class RectEditor : Editor
    {
        private bool isDrawing = false;
        private Point center, end_p;

        public RectEditor(MainEditor editor) : base(editor) { }


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

                RectShape rectShape = new RectShape();

                Rectangle rect = GetRect(center, end_p);
                rectShape.Set(rect.X, rect.Y, rect.Width, rect.Height);

                editor.AddObject(rectShape);

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
                RectShape shape = new RectShape();

                using (Pen pen = CreatePen())
                {
                    Rectangle rect = GetRect(center, end_p);

                    shape.Set(rect.X, rect.Y, rect.Width, rect.Height);
                    shape.Show(g, pen);
                }
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
    }
}
