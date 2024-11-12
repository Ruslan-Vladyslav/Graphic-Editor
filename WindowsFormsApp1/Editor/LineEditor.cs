


using System.Drawing;
using System.Windows.Forms;


namespace Lab5
{
    class LineEditor : Editor
    {
        private bool isDrawing = false;
        private long startX, startY;

        public LineEditor(MainEditor editor) : base(editor) { }

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
                var mainLine = new LineShape();
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
                LineShape shape = new LineShape();

                using (Pen pen = CreatePen()) 
                {
                    shape.Set(startX, startY, window.PointToClient(Cursor.Position).X, window.PointToClient(Cursor.Position).Y);
                    shape.Show(g, pen);
                }
            }
        }
    }
}
