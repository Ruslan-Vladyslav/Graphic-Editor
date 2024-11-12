

using System;
using System.Drawing;
using System.Windows.Forms;


namespace Lab5
{
    abstract class Editor
    {
        protected MainEditor editor;

        public Editor(MainEditor editor)
        {
            this.editor = editor;
        }


        protected Pen CreatePen()
        {
            Pen dashPen = new Pen(Color.FromArgb(0, 43, 255)); 

            dashPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash; 
            dashPen.DashPattern = new float[] { 5, 7 };

            return dashPen;
        }

        public abstract void OnLBdown(Form window);
        public abstract void OnLBup(Form window);
        public abstract void OnMouseMove(Form window);
        public abstract void OnPaint(Form window, Graphics g);
    }
}
