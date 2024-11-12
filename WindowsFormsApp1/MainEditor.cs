using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace Lab5
{
    class MainEditor
    {
        private const int MAX_OBJECTS = 105;
        private static List<Shape> shapeList;
        private Editor mainEditor;
        private static MainEditor instance;

        private long cord1;
        private long cord2;
        private long cord3;
        private long cord4;
        private string mainShape;

        public MainEditor()
        {
            shapeList = new List<Shape>();
        }

        public static MainEditor Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MainEditor();
                }

                return instance;
            }
        }



        public Editor StartEditor(Type type)
        {
            if (type == typeof(PointEditor))
            {
                mainEditor = new PointEditor(this);
                mainShape = "Point";
            }
            else if (type == typeof(LineEditor))
            {
                mainEditor = new LineEditor(this);
                mainShape = "Line";
            }
            else if (type == typeof(RectEditor))
            {
                mainEditor = new RectEditor(this);
                mainShape = "Rectangle";
            }
            else if (type == typeof(EllipseEditor))
            {
                mainEditor = new EllipseEditor(this);
                mainShape = "Ellipse";
            }
            else if (type == typeof(LineOOEditor))
            {
                mainEditor = new LineOOEditor(this);
                mainShape = "Line-circles";
            }
            else if (type == typeof(CubeEditor))
            {
                mainEditor = new CubeEditor(this);
                mainShape = "Cube";
            }

            return mainEditor;
        }

        public void FormPaint(Graphics e, Editor editor, Form form)
        {
            OnPaint(e);
            editor?.OnPaint(form, e);
        }

        public void FormMouseDown(MouseEventArgs e, Editor editor, Form form)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (editor != null)
                {
                    Cursor.Current = Cursors.Hand;
                    editor.OnLBdown(form);
                }
            }
        }

        public void FormMouseUp(MouseEventArgs e, Editor editor, Form form)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (editor != null)
                {
                    editor.OnLBup(form);
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        public void FormMouseMove(Editor editor, Form form)
        {
            editor?.OnMouseMove(form);
        }

        public void ClearObjects()
        {
            shapeList.Clear();
        }

        public void AddObject(Shape obj)
        {
            if (shapeList.Count < MAX_OBJECTS)
            {
                shapeList.Add(obj);
                SetCords(obj);
            }
        }

        public void OnPaint(Graphics g)
        {
            Pen pen = new Pen(Color.Black);

            foreach (var shape in shapeList)
            {
                shape.Show(g, pen);
            }

            pen.Dispose();
        }

        private void SetCords(Shape obj)
        {
            cord1 = obj.GetX1;
            cord2 = obj.GetY1;
            cord3 = obj.GetX2;
            cord4 = obj.GetY2;
        }

        public void GetTableData(out string objname,out long x1, out long y1, out long x2, out long y2)
        {
            objname = mainShape;
            x1 = cord1;
            y1 = cord2;
            x2 = cord3;
            y2 = cord4;
        }

        public void CreateNewLict(string name, long x1, long y1, long x2, long y2)
        {
            Shape newShape = CreateShape(name);

            if (newShape != null)
            {
                newShape.Set(x1, y1, x2, y2);
                AddObject(newShape);
            }
        }

        private Shape CreateShape(string name)
        {
            switch (name)
            {
                case "Point":
                    return new PointShape();
                case "Line":
                    return new LineShape();
                case "Rectangle":
                    return new RectShape();
                case "Ellipse":
                    return new EllipseShape();
                case "Line-circles":
                    return new LineOOShape();
                case "Cube":
                    return new CubeShape();
                default:
                    return null;
            }
        }
    }
}