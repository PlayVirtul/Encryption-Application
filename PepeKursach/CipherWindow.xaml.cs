using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PepeKursach
{
    /// <summary>
    /// Interaction logic for CipherWindow.xaml
    /// </summary>
    public partial class CipherWindow : Window
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
            saveFile.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (saveFile.ShowDialog() == true)
            {
                try
                {
                    File.WriteAllText(saveFile.FileName, cipherText.Text);
                    MessageBox.Show("Файл успешно сохранён");
                }
                catch(Exception er)
                {
                    MessageBox.Show(er.Message);
                }
            }
        }

        private void CloseButton(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
