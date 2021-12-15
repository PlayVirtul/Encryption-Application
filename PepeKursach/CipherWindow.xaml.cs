using System;
using System.Windows;
using Microsoft.Win32;
using System.IO;
using Microsoft.Office.Interop.Word;

namespace PepeKursach
{
    public partial class CipherWindow : System.Windows.Window
    {
        public CipherWindow()
        {
            InitializeComponent();
        }

        public void ShowCipherText(string text)
        {
            cipherText.Text = text;
        }

        private void SaveCipherText(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "txt files|*.txt|Word Documents|*.docx;*.docx|All files|*.*";
            if (saveFile.ShowDialog() == true)
            {
                if (Path.GetExtension(saveFile.FileName).Equals(".txt", StringComparison.InvariantCultureIgnoreCase))
                {
                    try
                    {
                        File.WriteAllText(saveFile.FileName, cipherText.Text);
                        MessageBox.Show("Файл успешно сохранён");
                    }
                    catch (Exception er)
                    {
                        MessageBox.Show(er.Message);
                    }
                }
                else if (Path.GetExtension(saveFile.FileName).Equals(".docx", StringComparison.InvariantCultureIgnoreCase) ||
                Path.GetExtension(saveFile.FileName).Equals(".doc", StringComparison.InvariantCultureIgnoreCase))
                {
                    try
                    {
                        Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
                        Document doc = app.Documents.Add();
                        doc.Content.Text = cipherText.Text;
                        app.ActiveDocument.SaveAs(saveFile.FileName);
                        app.Quit();
                        MessageBox.Show("Файл успешно сохранён");
                    }
                    catch (Exception ee)
                    {
                        MessageBox.Show(ee.Message);
                    }
                }
            }
        }

        private void CloseButton(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
