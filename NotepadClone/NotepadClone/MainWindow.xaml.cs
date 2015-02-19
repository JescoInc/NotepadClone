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

namespace NotepadClone
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private const string fileFilter = "Text Files|*.txt|All Files|*.*";
        private string currentPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuFileLoad_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = currentPath;
            ofd.RestoreDirectory = true;
            ofd.DefaultExt = "*.txt";
            ofd.AddExtension = true;
            ofd.Filter = fileFilter;
            ofd.ShowDialog();

            try 
            {
                TxtBox.Text = System.IO.File.ReadAllText(ofd.FileName);
            }

            catch (ArgumentException)
            {
                // Do nothing
            } 
        }

        private void MenuFileSaveAs_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = "*.txt";
            sfd.Filter = fileFilter;
            sfd.AddExtension = true;
            sfd.InitialDirectory = currentPath;
            sfd.RestoreDirectory = true;
            sfd.OverwritePrompt = true;
            sfd.ShowDialog();

            if (sfd.ShowDialog() != true)
                return;

            else
                using (var stream = sfd.OpenFile())
                using (var writer = new StreamWriter(stream, Encoding.UTF8))
                {
                    writer.Write(TxtBox.Text);
                    writer.Close();
                }
            }

        private void MenuFileSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuFileExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
