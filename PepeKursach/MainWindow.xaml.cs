using Microsoft.Win32;
using System.Windows;

namespace PepeKursach
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonOpenFileClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "txt files|*.txt|Word Documents|*.docx;*.docx|All files|*.*";

            if (fileDialog.ShowDialog() == true)
            {
                FileHandler.FilePath = fileDialog.FileName;
                FileHandler.ReadTextFromFile();
            }
        }

        private void DecodeButton(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(FileHandler.FileText))
            {
                MessageBox.Show("Файл ничего не содержит");
            }
            else
            {
                if (string.IsNullOrEmpty(codekeyLine.Text))
                {
                    MessageBox.Show("Ключ не указан");
                }
                else
                {
                    if (string.IsNullOrEmpty(decodekeyLine.Text))
                    {
                        MessageBox.Show("Ключ не указан");
                    }
                    else
                    {
                        Coderator coderator = new Coderator();
                        string decodeText = coderator.Decode(FileHandler.FileText, decodekeyLine.Text);
                        CipherWindow cipherWindow = new CipherWindow();
                        cipherWindow.Show();
                        cipherWindow.ShowCipherText(decodeText);
                    }
                }
            }
        }

        private void CodeButton(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(normalText.Text))
            {
                MessageBox.Show("Поле ничего не содержит");
            }
            else
            {
                if (string.IsNullOrEmpty(codekeyLine.Text))
                {
                    MessageBox.Show("Ключ не указан");
                }
                else
                {
                    Coderator coderator = new Coderator();
                    string decodeText = coderator.Encode(normalText.Text, codekeyLine.Text);
                    CipherWindow cipherWindow = new CipherWindow();
                    cipherWindow.Show();
                    cipherWindow.ShowCipherText(decodeText);
                }
            }
        }
    }
}
