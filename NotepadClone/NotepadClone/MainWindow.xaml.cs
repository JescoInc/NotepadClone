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

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuFileLoad_Click(object sender, RoutedEventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.DefaultExt = "*.txt";
            ofd.AddExtension = true;
            ofd.Filter = "Text|*.txt; *.cs; *.xml";
            ofd.InitialDirectory = "C:\\";
            ofd.RestoreDirectory = true;
            ofd.ShowDialog();

            if (ofd.ShowDialog() == DialogResult.HasValue)
                TxtBox.Text = System.IO.File.ReadAllText(ofd.FileName);

            // To do... Figure out a way to circumvent the exception being thrown
            // when you select the cancel button or press the exit button from dialog box
                


        }

        private void MenuFileSaveAs_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuFileSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuFileExit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
