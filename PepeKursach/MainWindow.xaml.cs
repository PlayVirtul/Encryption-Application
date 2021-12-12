using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PepeKursach
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonOpenFileClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

            if (fileDialog.ShowDialog() == true)
            {
                FileHandler.filePath = fileDialog.FileName;
                FileHandler.ReadTextFromFile();
            }
        }

        private void decodeButton(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(FileHandler.Text))
            {
                MessageBox.Show("Файл ничего не содержит");
            }
            else
            {
                if (string.IsNullOrEmpty(keywordLine.Text))
                {
                    MessageBox.Show("Ключ не указан");
                }
                else
                {
                    Coderator coderator = new Coderator();
                    string decodeText = coderator.Decode(FileHandler.Text, keywordLine.Text);
                    CipherWindow cipherWindow = new CipherWindow();
                    cipherWindow.Show();
                    cipherWindow.ShowCipherText(decodeText);
                }
            }
        }
    }
}
