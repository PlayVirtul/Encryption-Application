using System;
using System.IO;
using System.Windows;
using Microsoft.Office.Interop.Word;

namespace PepeKursach
{
    public static class FileHandler
    {
        public static string FilePath { get; set; }

        public static string FileText { get; private set; }

        public static void ReadTextFromFile()
        {
            if (Path.GetExtension(FilePath).Equals(".txt", StringComparison.InvariantCultureIgnoreCase))
            {
                try
                {
                    FileText = File.ReadAllText(FilePath);
                    MessageBox.Show("файл успешно считан");
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            else if(Path.GetExtension(FilePath).Equals(".docx", StringComparison.InvariantCultureIgnoreCase) ||
                Path.GetExtension(FilePath).Equals(".doc", StringComparison.InvariantCultureIgnoreCase))
            {
                try
                {
                    Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
                    Document doc = app.Documents.Open(FilePath);
                    FileText = doc.Content.Text;
                    app.Quit();
                    MessageBox.Show("файл успешно считан");
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }
    }
}
