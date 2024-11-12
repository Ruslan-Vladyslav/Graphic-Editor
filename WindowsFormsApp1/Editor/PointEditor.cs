


using System.Drawing;
using System.Windows.Forms;


namespace Lab5
{
    class PointEditor : Editor
    {
        private bool isDrawing = false;

        public PointEditor(MainEditor editor) : base(editor) { }


        public override void OnLBdown(Form window)
        {
            isDrawing = true;

            var mainPoint = new PointShape();
            mainPoint.Set(window.PointToClient(Cursor.Position).X, window.PointToClient(Cursor.Position).Y, 0, 0);

            editor.AddObject(mainPoint);
            window.Invalidate();
        }

        public override void OnLBup(Form window)
        {
            isDrawing = false;
            window.Invalidate();
        }

        public override void OnMouseMove(Form window) { }
        public override void OnPaint(Form window, Graphics g) { }
    }
}
