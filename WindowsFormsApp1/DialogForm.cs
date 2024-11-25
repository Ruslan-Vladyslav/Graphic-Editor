
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    public partial class DialogForm : Form
    {
        public event Action<List<int>> RowsDeleted;
        public event Action<List<int>> RowsChosen;

        public int counter;

        public DialogForm()
        {
            InitializeComponent();
            InitializeToolStrip();
            InitializeDataGrid();

            this.TopMost = true;
        }

        private void InitializeDataGrid()
        {
            dataGrid.ReadOnly = true;
            dataGrid.MultiSelect = true;
            dataGrid.AllowUserToAddRows = false;
            dataGrid.AllowUserToDeleteRows = false;
            dataGrid.AllowUserToResizeRows = false;

            foreach (DataGridViewColumn column in dataGrid.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dataGrid.ScrollBars = ScrollBars.Vertical;
            dataGrid.SelectionChanged += DataGrid_SelectionChanged;
        }

        private void DataGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGrid.SelectedRows.Count > 0)
            {
                List<int> selectedIndx = dataGrid.SelectedRows
                    .Cast<DataGridViewRow>()
                    .Select(row => row.Index)
                    .ToList();

                RowsChosen?.Invoke(selectedIndx);
            }
            else
            {
                RowsChosen?.Invoke(new List<int>());
            }
        }


        private void InitializeToolStrip()
        {
            toolStrip2.ImageScalingSize = new Size(24, 24);

            foreach (ToolStripItem item in toolStrip2.Items)
            {
                item.Margin = new Padding(5);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("\nThis is main form objects list\n", "Information", MessageBoxButtons.OK);
        }


        public void AddShapeToTable(string shapeName, long x1, long y1, long x2, long y2)
        {
            dataGrid.Rows.Add(shapeName, x1, y1, x2, y2);
            dataGrid.Refresh();
        }

        public void ClearTable() 
        { 
            dataGrid.Rows.Clear();
        }

        public void toolBtn1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*",
                Title = "Save Objects list"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine("Objects name".PadRight(20) + "X1".PadRight(10) + "Y1".PadRight(10) + "X2".PadRight(10) + "Y2");

                    foreach (DataGridViewRow row in dataGrid.Rows)
                    {
                        if (row.IsNewRow) continue;

                        string line = $"{row.Cells[0].Value?.ToString().PadRight(20)}" +
                                      $"{row.Cells[1].Value?.ToString().PadRight(10)}" +
                                      $"{row.Cells[2].Value?.ToString().PadRight(10)}" +
                                      $"{row.Cells[3].Value?.ToString().PadRight(10)}" +
                                      $"{row.Cells[4].Value?.ToString()}";

                        writer.WriteLine(line);
                    }
                }
            }
        }

        private void toolBtn2_Click(object sender, EventArgs e)
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += PrintDocument_PrintPage;

            PrintDialog printDialog = new PrintDialog
            {
                Document = printDocument
            };

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }

        private void PrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int rowHeight = 20;
            int startX = 10; 
            int startY = 10;

            string[] columnHeaders = { "Object name", "X1", "Y1", "X2", "Y2" };
            int columnSpacing = 22;

            for (int i = 0; i < columnHeaders.Length; i++)
            {
                e.Graphics.DrawString(columnHeaders[i], new Font("Arial", 12), Brushes.Black, startX + (100 + columnSpacing) * i, startY);
            }

            startY += rowHeight;

            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                if (row.IsNewRow) continue;

                for (int i = 0; i < row.Cells.Count; i++)
                {
                    e.Graphics.DrawString(row.Cells[i].Value?.ToString(), new Font("Arial", 12), Brushes.Black, startX + (100 + columnSpacing) * i, startY);
                }
                startY += rowHeight;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolBtn1_Click(sender, e);
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolBtn2_Click(sender, e);
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (dataGrid.SelectedRows.Count > 0)
            {
                List<int> selectedIndx = dataGrid.SelectedRows
                    .Cast<DataGridViewRow>()
                    .Select(row => row.Index + 1)
                    .ToList();

                foreach (DataGridViewRow row in dataGrid.SelectedRows)
                {
                    dataGrid.Rows.Remove(row);
                }

                RowsDeleted?.Invoke(selectedIndx);
            }
            else
            {
                MessageBox.Show("No rows selected to delete.", "Information", MessageBoxButtons.OK);
            }
        }
    }
}
