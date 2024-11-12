
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;



namespace Lab5
{
    class MenuHandler
    {
        private readonly Form1 form;
        private readonly MainEditor objects;
        private readonly Editor currentEditor;
        private readonly Image mainIMG;
        private readonly PrintDocument printDoc = new PrintDocument();

        public MenuHandler(Form1 form, MainEditor objects, Editor currentEditor, Image mainIMG)
        {
            this.form = form;
            this.objects = objects;
            this.currentEditor = currentEditor;
            this.mainIMG = mainIMG;
        }


        public void SaveFile_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PNG Image|*.png";
                saveFileDialog.Title = "Saving in file";
                saveFileDialog.FileName = "new_file.png";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    SaveObjectsToPNG(filePath);
                }
            }
        }

        private void SaveObjectsToPNG(string filePath)
        {
            int width = form.ClientSize.Width;
            int height = form.ClientSize.Height;

            /*Size ScreenSize = Screen.PrimaryScreen.Bounds.Size;
            width = ScreenSize.Width;
            height = ScreenSize.Height;*/

            using (Bitmap bmp = new Bitmap(width, height))
            {
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.Clear(Color.White);

                    if (mainIMG != null)
                    {
                        g.DrawImage(mainIMG, 0, 0, mainIMG.Width, mainIMG.Height);
                    }

                    objects.OnPaint(g);
                    currentEditor?.OnPaint(form, g);
                }

                bmp.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
            }
        }

        public void Print_Click(object sender, EventArgs e)
        {
            printDoc.PrintController = new StandardPrintController();
            printDoc.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);

            using (PrintDialog printDialog = new PrintDialog())
            {
                printDialog.Document = printDoc;

                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDoc.Print();
                }
            }
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;

            if (mainIMG != null)
            {
                g.DrawImage(mainIMG, 0, 0, mainIMG.Width, mainIMG.Height);
            }

            objects.OnPaint(g);
            currentEditor?.OnPaint(form, g);

            e.HasMorePages = false;
        }
    }
}