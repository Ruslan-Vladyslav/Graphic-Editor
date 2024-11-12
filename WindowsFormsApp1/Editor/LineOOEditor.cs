


using System.Drawing;
using System.Windows.Forms;


namespace Lab5
{
    class LineOOEditor : Editor
    {
        private bool isDrawing = false;
        private long startX, startY;

        public LineOOEditor(MainEditor editor) : base(editor) { }

        public override void OnLBdown(Form window)
        {
            isDrawing = true;

            startX = window.PointToClient(Cursor.Position).X;
            startY = window.PointToClient(Cursor.Position).Y;
        }

        public override void OnLBup(Form window)
        {
            if (isDrawing)
            {
                var mainLine = new LineOOShape();
                mainLine.Set(startX, startY, window.PointToClient(Cursor.Position).X, window.PointToClient(Cursor.Position).Y);

                editor.AddObject(mainLine);

                isDrawing = false;
                window.Invalidate();
            }
        }

        public override void OnMouseMove(Form window)
        {
            if (isDrawing)
            {
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

                g.DrawLine(dashPen, startX, startY, window.PointToClient(Cursor.Position).X, window.PointToClient(Cursor.Position).Y);

                float[] pattern2 = { 3, 3 };
                dashPen.DashPattern = pattern2;

                DrawRubberCircle(g, startX, startY, dashPen);
                DrawRubberCircle(g, window.PointToClient(Cursor.Position).X, window.PointToClient(Cursor.Position).Y, dashPen);

                dashPen.Dispose();
            }
        }

        private void DrawRubberCircle(Graphics g, long x, long y, Pen pen)
        {
            const int radius = 7;

            using (Brush brush = new SolidBrush(Color.White))
            {
                g.FillEllipse(brush, x - radius, y - radius, 2 * radius, 2 * radius);
            }

            g.DrawEllipse(pen, x - radius, y - radius, 2 * radius, 2 * radius);
           
        }
    }
}
