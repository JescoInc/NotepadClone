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
using System.Windows.Navigation;
using System.Windows.Forms;
using System.Drawing;

namespace NotepadClone
{

    public partial class MainWindow : Window
    {
        Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
        Microsoft.Win32.SaveFileDialog sfd = new Microsoft.Win32.SaveFileDialog();
        private const string fileFilter = "Text Files|*.txt|All Files|*.*";
        private string currentPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private string filePathAndName = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void NewFile_Click(object sender, RoutedEventArgs e)
        {

            MenuFileSaveAs_Click(sender, e);
        }

        private void MenuFileLoad_Click(object sender, RoutedEventArgs e)
        {
            ofd.InitialDirectory = currentPath;
            ofd.RestoreDirectory = true;
            ofd.DefaultExt = "*.txt";
            ofd.AddExtension = true;
            ofd.Filter = fileFilter;

            if (ofd.ShowDialog() == true)
            {
                filePathAndName = ofd.FileName;

                try
                {
                    TxtBox.Text = System.IO.File.ReadAllText(filePathAndName);
                }

                catch (Exception exception)
                {
                    System.Windows.MessageBox.Show(exception.Message);
                }
            }
        }

        private void MenuFileSaveAs_Click(object sender, RoutedEventArgs e)
        {
            sfd.DefaultExt = "*.txt";
            sfd.Filter = fileFilter;
            sfd.AddExtension = true;
            sfd.InitialDirectory = currentPath;
            sfd.RestoreDirectory = true;
            sfd.OverwritePrompt = true;

            if (sfd.ShowDialog() == true)
            {
                filePathAndName = sfd.FileName;
                var fileStream = new StreamWriter(filePathAndName, false);
                fileStream.Write(TxtBox.Text);
                fileStream.Close();
            }

            else
            {
                return;
            }
        }

        private void MenuFileSave_Click(object sender, RoutedEventArgs e)
        {
          
            if (string.IsNullOrEmpty(filePathAndName))
            {
                MenuFileSaveAs_Click(sender, e);
                return;
            }

            var fileStream = new StreamWriter(filePathAndName, false);
            fileStream.Write(TxtBox.Text);
            fileStream.Close();

        }

        private void MenuFileExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SpellCheck_Click(object sender, RoutedEventArgs e)
        {
                TxtBox.SpellCheck.IsEnabled = true;
        }

        private void FontType_Click(object sender, RoutedEventArgs e)
        {
            FontDialog fontbox = new FontDialog();

            if (fontbox.ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
            {
                System.Drawing.Font font = fontbox.Font;
                TxtBox.FontFamily = new System.Windows.Media.FontFamily(font.Name);
                TxtBox.FontSize = font.Size;
                TxtBox.FontWeight = font.Bold ? FontWeights.Bold : FontWeights.Regular;
                TxtBox.FontStyle = font.Italic ? FontStyles.Italic : FontStyles.Normal;
            }
        }

        private void WordWrap_Click(object sender, RoutedEventArgs e)
        {
            TxtBox.SpellCheck.IsEnabled = true;
        }
    }
}
