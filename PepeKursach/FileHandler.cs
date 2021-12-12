using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PepeKursach
{
    public static class FileHandler
    {
        public static string filePath;

        public static string Text { get; private set; }

        public static void ReadTextFromFile()
        {
            try
            {
                Text = File.ReadAllText(filePath);
                MessageBox.Show("файл успешно считан");
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
