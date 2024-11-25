using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApp1;


namespace Lab5
{
    public partial class Form1 : Form
    {
        private static readonly MainEditor edit = MainEditor.Instance;
        private readonly MenuHandler handler;
        private readonly FileManager manager;
        private Shape mainShape;
        private readonly System.Drawing.Image mainIMG = null;
        private DialogForm dialog = null;
        private static List<int> delIndices;

        private static string FILENAME = "ShapesData.txt";
        private static int counter = 0;

        private const int MAXCOUNT = 105;


        public Form1()
        {
            InitializeComponent();
            InitializeToolStrip();

            this.Paint += Form1_Paint;
            this.MouseDown += Form1_MouseDown;
            this.MouseUp += Form1_MouseUp;
            this.MouseMove += Form1_MouseMove;
            this.DoubleBuffered = true;

            manager = new FileManager();
            handler = new MenuHandler(this, edit, mainIMG);
        }


        private void RowsDeleted(List<int> indices)
        {
            if (indices != null)
            {
                edit.DeleteShapesByIndices(indices);
                manager.RemoveLinesFromFile(FILENAME, indices);

                delIndices = indices;

                foreach (int i in indices)
                {
                    counter--;
                }
                dialog.label2.Text = counter.ToString();

                this.Invalidate();
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            if (manager.FileCheck(FILENAME))
            {
                counter = 0;

                if (MessageBox.Show("Last session data exists. Load last data?", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    counter = manager.LoadShapesFromFile(DialogAddTable, FILENAME, false, false);
                    if (dialog != null)
                    {
                        dialog.label2.Text = counter.ToString();
                    }
                    this.Invalidate();
                }
                else
                {
                    manager.ClearFile(FILENAME);
                }
            }
        }

        private void InitializeToolStrip() 
        {
            toolStrip1.ImageScalingSize = new Size(24, 24);

            foreach (ToolStripItem item in toolStrip1.Items)
            {
                item.Margin = new Padding(5);
            }
            toolBtn3.Margin = new Padding(20, 5, 5, 5);
            DialogBtn.Margin = new Padding(20, 5, 5, 5);

            toolBtn1.Click += SaveFile_Click;
            toolBtn2.Click += Print_Click;

            toolBtn3.Click += pointToolStripMenuItem_Click;
            toolBtn4.Click += lineToolStripMenuItem_Click;
            toolBtn5.Click += rectangleToolStripMenuItem_Click;
            toolBtn6.Click += ellipseToolStripMenuItem_Click;

            drawLineBtn.Click += lineWithCirclesToolStripMenuItem_Click;
            drawCubeBtn.Click += cubeToolStripMenuItem_Click;
        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            edit.FormPaint(e.Graphics, mainShape, this);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            edit.FormMouseDown(e, mainShape, this);
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            edit.FormMouseUp(e, mainShape, this);

            if (edit != null)
            {
                edit.GetTableData(out string text, out long x1, out long y1, out long x2, out long y2);

                if (!string.IsNullOrEmpty(text) && counter <= MAXCOUNT)
                {
                    manager.WriteObjFile(text, x1, y1, x2, y2, FILENAME);
                    counter++;

                    if (dialog != null && counter <= MAXCOUNT)
                    {
                        DialogAddTable(text, x1, y1, x2, y2);
                        dialog.label2.Text = counter.ToString();
                    }
                }
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            edit.FormMouseMove(mainShape, this);
        }

        private void toolBtn7_Click(object sender, EventArgs e)
        {
            edit.ClearObjects();
            dialog?.ClearTable();
            manager.ClearFile(FILENAME);
            this.Invalidate();

            if (dialog != null)
            {
                dialog.label2.Text = "0";
            }

            counter = 0;
        }

        private void SaveFile_Click(object sender, EventArgs e)
        {
            handler.SaveFile_Click(sender, e);
        }

        private void Print_Click(object sender, EventArgs e)
        {
            handler.Print_Click(sender, e);
        }

        private void saveAsPngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            handler.SaveFile_Click(sender, e);
        }

        private void saveAstxtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dialog == null || dialog.IsDisposed)
            {
                DialogBtn.Checked = false;

                dialog = new DialogForm
                {
                    Owner = this
                };

                manager.LoadShapesFromFile(DialogAddTable, FILENAME, true, false);

                dialog.FormClosed += Dialog_FormClosed;
                this.Invalidate();
                dialog.toolBtn1_Click(sender, e);
                dialog = null;
            }
            else
            {
                dialog.toolBtn1_Click(sender, e);
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            handler.Print_Click(sender, e);
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("\nThis is Graphic Editor program\n", "Information", MessageBoxButtons.OK);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dialog?.Close();
            this.Close();
        }

        private void listToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogBtn_Click(sender, e);
        }

        private void pointToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainShape = edit.StartEditor(typeof(PointShape));
            SetMenuChecked(mainShape);
        }

        private void lineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainShape = edit.StartEditor(typeof(LineShape));
            SetMenuChecked(mainShape);
        }

        private void rectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainShape = edit.StartEditor(typeof(RectShape));
            SetMenuChecked(mainShape);
        }

        private void ellipseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainShape = edit.StartEditor(typeof(EllipseShape));
            SetMenuChecked(mainShape);
        }

        private void lineWithCirclesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainShape = edit.StartEditor(typeof(LineOOShape));
            SetMenuChecked(mainShape);
        }

        private void cubeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainShape = edit.StartEditor(typeof(CubeShape));
            SetMenuChecked(mainShape);
        }

        private void SetMenuChecked(Shape shape)
        {
            pointToolStripMenuItem.Checked = false;
            lineToolStripMenuItem.Checked = false;
            rectangleToolStripMenuItem.Checked = false;
            ellipseToolStripMenuItem.Checked = false;
            lineWithCirclesToolStripMenuItem.Checked = false;
            cubeToolStripMenuItem.Checked = false;

            toolBtn3.Checked = false;
            toolBtn4.Checked = false;
            toolBtn5.Checked = false;
            toolBtn6.Checked = false;
            drawLineBtn.Checked = false;
            drawCubeBtn.Checked = false;

            if (shape is PointShape)
            {
                pointToolStripMenuItem.Checked = true;
                toolBtn3.Checked = true;
            }
            else if (shape is LineOOShape)
            {
                lineWithCirclesToolStripMenuItem.Checked = true;
                drawLineBtn.Checked = true;
            }
            else if (shape is LineShape)
            {
                lineToolStripMenuItem.Checked = true;
                toolBtn4.Checked = true;
            }
            else if (shape is CubeShape)
            {
                cubeToolStripMenuItem.Checked = true;
                drawCubeBtn.Checked = true;
            }
            else if (shape is RectShape)
            {
                rectangleToolStripMenuItem.Checked = true;
                toolBtn5.Checked = true;
            }
            else if (shape is EllipseShape)
            {
                ellipseToolStripMenuItem.Checked = true;
                toolBtn6.Checked = true;
            }
        }

        private void DialogBtn_Click(object sender, EventArgs e)
        {
            if (dialog == null || dialog.IsDisposed)
            {
                DialogBtn.Checked = true;

                dialog = new DialogForm();
                dialog.Owner = this;

                dialog.ClearTable();
                manager.LoadShapesFromFile(DialogAddTable, FILENAME, true, false);

                dialog.FormClosed += Dialog_FormClosed;
                dialog.RowsDeleted += RowsDeleted;
                dialog.RowsChosen += HighlightShapes;

                this.Invalidate();
                dialog.Show();
            }
            else
            {
                dialog.Focus();
            }
        }

        private void HighlightShapes(List<int> indices)
        {
            bool mainColor = true;

            if (dialog != null)
            {
                using (Graphics g = this.CreateGraphics())
                {
                    edit.MarkShapes(indices, g, mainColor);
                }
            } else {
                this.Invalidate();
            }
        }

        private void Dialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogBtn.Checked = false;
            dialog = null;

            delIndices?.Clear();
            this.Invalidate();
        }

        public void DialogAddTable(string name, long x1, long y1, long x2, long y2)
        {
            dialog.AddShapeToTable(name, x1, y1, x2, y2);
            dialog.label2.Text = counter.ToString();
        }

        private void OpenFileBtn_Click(object sender, EventArgs e)
        {
            if (counter == 0) 
            {
                OpenFileEvent();
            } else
            {
                DialogResult result = MessageBox.Show("Opening new file will delete current objects. Continue?", "Information",
                                                  MessageBoxButtons.OKCancel,
                                                  MessageBoxIcon.Question);

                if (result == DialogResult.OK)
                {
                    OpenFileEvent();
                }
            }
        }

        private void OpenFileEvent()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt",
                Title = "Select a Text File"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;

                edit.ClearObjects();

                manager.CopyFile(fileName, FILENAME);
                counter = 0;

                if (dialog == null || dialog.IsDisposed)
                {
                    counter = manager.LoadShapesFromFile(DialogAddTable, fileName, false, false);
                }
                else
                {
                    counter = manager.LoadShapesFromFile(DialogAddTable, fileName, true, true);
                    dialog.label2.Text = counter.ToString();
                    
                }

                this.Invalidate();
            }
        }

        private void OpenBtn_Click(object sender, EventArgs e)
        {
            OpenFileBtn_Click(sender, e);
        }
    }
}