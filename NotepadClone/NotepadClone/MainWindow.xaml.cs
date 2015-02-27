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
    /// Magius96: so, back to the current file path...
    /// when you load the file, get the file name and path from the ofd, and store that at the class level -- DONE
    /// do the same in the saveas method -- DONE
    /// 3. then, copy the saving code from the saveas method to the save method,but remove the sfd 
    /// 3. instead, use the filename and path you stored to overwrite the existing file

    // I'm wondering what I should do to get started with what Magius says I should do. Any direction you could lead me in?

    public partial class MainWindow : Window
    {
        OpenFileDialog ofd = new OpenFileDialog();
        private const string fileFilter = "Text Files|*.txt|All Files|*.*";

        //Current path will store the path of the file + name?

        //But will it?

        //then whats the purpose of it?

        //oh, ok.

        // To set the default path of where the Initial path will be
        private string currentPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        private string filePathAndName;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuFileLoad_Click(object sender, RoutedEventArgs e)
        {
            ofd.InitialDirectory = currentPath;
            ofd.FileName = "*.txt";
            ofd.RestoreDirectory = true;
            ofd.DefaultExt = "*.txt";
            ofd.AddExtension = true;
            ofd.Filter = fileFilter;
            ofd.ShowDialog();

            try
            {
                filePathAndName = ofd.FileName;
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
            sfd.FileName = "*.txt";
            sfd.Filter = fileFilter;
            sfd.AddExtension = true;
            sfd.InitialDirectory = currentPath;
            sfd.RestoreDirectory = true;
            sfd.OverwritePrompt = true;

            if (sfd.ShowDialog() == true)
            {
                filePathAndName = sfd.FileName; 
                using (var stream = sfd.OpenFile())
                using (var writer = new StreamWriter(stream, Encoding.UTF8))
                {
                    writer.Write(TxtBox.Text);
                    writer.Close();
                }
            }

            else
            {
                return;
            }
        }

        private void MenuFileSave_Click(object sender, RoutedEventArgs e)
        {
          
          if(ofd.ShowDialog() == true)

          {
              filePathAndName = "";
          }

          else
          {

            var writer = new StreamWriter(filePathAndName, Encoding.UTF8);
              writer.Write(TxtBox.Text);
              writer.Close();

          }
        }

        private void MenuFileExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
