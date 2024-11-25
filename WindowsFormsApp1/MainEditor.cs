using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;


namespace Lab5
{
    class MainEditor
    {
        private const int MAX_OBJECTS = 105;
        private static List<Shape> shapeList;
        private static MainEditor instance;

        private long cord1;
        private long cord2;
        private long cord3;
        private long cord4;
        private string mainShape;
        private int curShape;
        
        private Point startPoint;
        private Point endPoint;
        private bool isDrawing;

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

        private Shape CreateShape(int objType)
        {
            switch (objType)
            {
                case 1: return new PointShape();
                case 2: return new LineShape();
                case 3: return new RectShape();
                case 4: return new EllipseShape();
                case 5: return new LineOOShape();
                case 6: return new CubeShape();
                default: return null;
            }
        }

        public Shape StartEditor(Type type)
        {
            if (type == typeof(PointShape))
            {
                mainShape = "Point";
                curShape = 1;
            }
            else if (type == typeof(LineShape))
            {
                mainShape = "Line";
                curShape = 2;
            }
            else if (type == typeof(RectShape))
            {
                mainShape = "Rectangle";
                curShape = 3;
            }
            else if (type == typeof(EllipseShape))
            {
                mainShape = "Ellipse";
                curShape = 4;
            }
            else if (type == typeof(LineOOShape))
            {
                mainShape = "Line-circles";
                curShape = 5;
            }
            else if (type == typeof(CubeShape))
            {
                mainShape = "Cube";
                curShape = 6;
            }

            return CreateShape(curShape);
        }

        public void DeleteShapesByIndices(List<int> indices)
        {
            indices.Sort((a, b) => b.CompareTo(a));

            foreach (int index in indices)
            {
                if (index - 1 >= 0 && index - 1 < shapeList.Count)
                {
                    shapeList.RemoveAt(index - 1);
                }
            }
        }

        public void MarkShapes(List<int> indices, Graphics g, bool mainColor)
        {

            Pen basePen = new Pen(Color.Black);
            Pen highlightPen = new Pen(Color.Red, 1.5f);
            bool isSolid = true;

            for (int i = 0; i < shapeList.Count; i++)
            {
                if (indices.Contains(i))
                {
                    shapeList[i].Show(g, highlightPen, isSolid);
                }
                else
                {
                    shapeList[i].Show(g, basePen, isSolid);
                }
            }

            basePen.Dispose();
            highlightPen.Dispose();
        }

        private Pen CreatePen(Color color)
        {
            Pen dashPen = new Pen(color);

            dashPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            dashPen.DashPattern = new float[] { 5, 7 };

            return dashPen;
        }

        public void FormPaint(Graphics e, Shape editor, Form form)
        {
            OnPaint(e);

            if (editor != null) {
                OnPaint_Action(form, e);
            }
        }

        public void OnPaint_Action(Form form, Graphics g)
        {
            bool isSolid = false;

            if (isDrawing)
            {
                endPoint = form.PointToClient(Cursor.Position);

                var mainShape = CreateShape(curShape);

                if (mainShape != null)
                {
                    using (Pen pen = CreatePen(Color.FromArgb(0, 43, 255)))
                    {
                        mainShape.Set(startPoint.X, startPoint.Y, endPoint.X, endPoint.Y);
                        mainShape.Show(g, pen, isSolid);
                    }
                }
            }
        }

        public void OnPaint(Graphics g)
        {
            Pen pen = new Pen(Color.Black);
            bool isSolid = true;

            foreach (var shape in shapeList)
            {
                shape.Show(g, pen, isSolid);
            }

            pen.Dispose();
        }

        public void FormMouseDown(MouseEventArgs e, Shape editor, Form form)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (editor != null)
                {
                    Cursor.Current = Cursors.Hand;
                    MouseDown_Action(form);
                }
            }
        }
        private void MouseDown_Action(Form form)
        {
            isDrawing = true;

            startPoint = form.PointToClient(Cursor.Position);
            form.Invalidate();
        }

        public void FormMouseUp(MouseEventArgs e, Shape editor, Form form)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (editor != null)
                {
                    MouseUp_Action(form);
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        private void MouseUp_Action(Form form)
        {
            if (isDrawing)
            {
                endPoint = form.PointToClient(Cursor.Position);

                isDrawing = false;

                var mainShape = CreateShape(curShape);
                mainShape.Set(startPoint.X, startPoint.Y, endPoint.X, endPoint.Y);

                AddObject(mainShape);

                form.Invalidate();
            }
        }

        public void FormMouseMove(Shape editor, Form form)
        {
            if (isDrawing)
            {
                MouseMove_Action(form);
            }
        }

        private void MouseMove_Action(Form form)
        {
            endPoint = form.PointToClient(Cursor.Position);
            form.Invalidate();
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
            var newShape = CreateShape(name);

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