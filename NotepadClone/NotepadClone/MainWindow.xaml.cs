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
        SaveFileDialog sfd = new SaveFileDialog();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuFileLoad_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = @"C:\";
            ofd.RestoreDirectory = true;
            ofd.DefaultExt = "*.txt";
            ofd.AddExtension = true;
            ofd.Filter = "Text|*.txt; *.cs; *.xml";
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
            string path = @"C:\";
            sfd.DefaultExt = "*.txt";
            sfd.Filter = "Text|*.txt; *.cs; *.xml";
            sfd.AddExtension = true;
            sfd.InitialDirectory = path;
            sfd.RestoreDirectory = true;
            sfd.OverwritePrompt = true;
            sfd.ShowDialog();

            try
            {
                System.IO.File.WriteAllText(path,TxtBox.Text,Encoding.UTF8);     
            }

            catch (ArgumentException)
            {
                // Do nothing
            }    

            catch(UnauthorizedAccessException)
            {
                MessageBox.Show("Access Denied");
            }
        }

        private void MenuFileSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuFileExit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
