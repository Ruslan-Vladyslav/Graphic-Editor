using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;


namespace Lab5
{
    class FileManager
    {
        private MainEditor editor = new MainEditor();

        public FileManager() { }


        public void WriteObjFile(string text, long x1, long y1, long x2, long y2, string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename, true))
            {
                int width = 20;
                int width2 = 10;

                string dataLine = $"{text.PadRight(width)}" +
                                  $"{x1.ToString().PadRight(width2)}" +
                                  $"{y1.ToString().PadRight(width2)}" +
                                  $"{x2.ToString().PadRight(width2)}" +
                                  $"{y2.ToString().PadRight(width2)}";

                writer.WriteLine(dataLine);
            }
        }

        public void RemoveLinesFromFile(string filename, List<int> indices)
        {
            List<string> allLines = File.ReadAllLines(filename).ToList();

            indices = indices.Where(i => i > 0 && i < allLines.Count).OrderByDescending(i => i).ToList();

            foreach (int index in indices)
            {
                allLines.RemoveAt(index);
            }

            File.WriteAllLines(filename, allLines);
        }

        public void ClearFile(string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename, false))
            {
                int width = 20;
                int width2 = 10;

                string header = $"{"Object name".PadRight(width)}" +
                                    $"{"X1".PadRight(width2)}" +
                                    $"{"Y1".PadRight(width2)}" +
                                    $"{"X2".PadRight(width2)}" +
                                    $"{"Y2".PadRight(width2)}";

                writer.WriteLine(header);
            }
        }

        public int LoadShapesFromFile(Action<string, long, long, long, long> func, string filename, bool allow, bool both)
        {
            int counter = 0;

            using (StreamReader reader = new StreamReader(filename))
            {
                string head = reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    var parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    if (parts.Length >= 5)
                    {
                        string shape = parts[0];

                        if (long.TryParse(parts[1], out long x1) &&
                            long.TryParse(parts[2], out long y1) &&
                            long.TryParse(parts[3], out long x2) &&
                            long.TryParse(parts[4], out long y2))
                        {
                            if (both)
                            {
                                func(shape, x1, y1, x2, y2);
                                editor.CreateNewLict(shape, x1, y1, x2, y2);
                            } else
                            {
                                if (allow is true)
                                {
                                    func(shape, x1, y1, x2, y2);
                                }
                                else
                                {
                                    editor.CreateNewLict(shape, x1, y1, x2, y2);
                                }
                            }

                            counter++;
                        }
                    }
                }
            }

            return counter;
        }

        public void CopyFile(string source, string newsource)
        {
            try
            {
                using (StreamReader reader = new StreamReader(source))
                {
                    using (StreamWriter writer = new StreamWriter(newsource))
                    {
                        string line;

                        while ((line = reader.ReadLine()) != null)
                        {
                            writer.WriteLine(line);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool FileCheck(string filename)
        {
            if (!File.Exists(filename))
            {
                return false;
            }

            string[] lines = File.ReadAllLines(filename);

            return lines.Length > 1;
        }
    }
}
