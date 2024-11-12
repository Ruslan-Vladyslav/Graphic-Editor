


using System;
using System.Drawing;
using System.Windows.Forms;


namespace Lab5
{
    class EllipseEditor : Editor
    {
        private bool isDrawing = false;
        private Point start_p, end_p;

        public EllipseEditor(MainEditor editor) : base(editor) { }

        public override void OnLBdown(Form window)
        {
            isDrawing = true;
            start_p = window.PointToClient(Cursor.Position);
        }

        public override void OnLBup(Form window)
        {
            if (isDrawing)
            {
                end_p = window.PointToClient(Cursor.Position);

                EllipseShape ellipse = new EllipseShape();

                Rectangle rect = GetRect(start_p, end_p);
                ellipse.Set(rect.X, rect.Y, rect.Width, rect.Height);

                editor.AddObject(ellipse);

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
                EllipseShape shape = new EllipseShape();

                using (Pen pen = CreatePen())
                {
                    Rectangle rect = GetRect(start_p, end_p);

                    shape.Set(rect.X, rect.Y, rect.Width, rect.Height);
                    shape.Show(g, pen);
                }
            }
        }

        private Rectangle GetRect(Point start, Point end)
        {
            int x = start_p.X - Math.Abs(end.X - start.X);
            int y = start_p.Y - Math.Abs(end.Y - start.Y);
            int width = Math.Abs(end.X - start_p.X) * 2;
            int height = Math.Abs(end.Y - start_p.Y) * 2;

            return new Rectangle(x, y, width, height);
        }
    }
}
